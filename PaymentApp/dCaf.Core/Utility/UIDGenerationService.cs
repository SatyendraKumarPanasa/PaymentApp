using System;
using System.Globalization;
using System.Net.NetworkInformation;

namespace dCaf.Core.Utility
{
    public class UIDGenerationService : IUIDGenerationService
    {
        private static Random? rand;
        private static object locker = new object();

        /// <summary>
        /// Private string representation of a UID
        /// </summary>
        private string? uid;

        /// <summary>
        /// Preface UID generation with the USA ISO (1.2.840) and DICOM (1008) root 1.2.840.1008.
        /// Default = false
        /// </summary>
        private static bool UseDICOMRoot = false;

        /// <summary>
        /// Because some vendors will send nothing that looks like a Uid.
        /// Default is false=Do not enforce digit and period form
        /// </summary>
        private static bool EnforceDigitDot = false;

        /// <summary>
        /// The actual hash as a string
        /// </summary>
        private static string? hash = null;

        /// <summary>
        /// maxGenerationLength
        /// </summary>
        private static int maxGenerationLength = 64;

        /// <summary>
        /// MAXIMUM Generation Length for a Unique Instance ID. Default = 54 due to known legacy systems.
        /// </summary>
        private static int MaxGenerationLength
        {
            get
            {
                return maxGenerationLength;
            }
            set
            {
                maxGenerationLength = value;
            }
        }

        /// <summary>
        /// Generate a new UID based on a root and sub-root pair.
        /// Although it is statistically extremely difficult to generate duplicates using our method it still is not impossible.
        /// Always check uniqueness with a centralized authority such as your database!
        /// We do not absolutely positively guarantee universal uniqueness for all time everywhere in the multi-verse.
        /// Generation Method (each item is separated by a dot='.'):
        /// [Optional DICOM ROOT] = if UseDICOMRoot = true = default
        /// root
        /// sub-root
        /// MACID as hash if available otherwise machine-name-as-hash
        /// random numbers [1..n] until filled to Max length of 63..64 characters
        /// </summary>
        /// <remarks>
        /// Some root providers distribute sub-roots from their root
        /// </remarks>
        /// <param name="root">Root Authority</param>
        /// <param name="subRoot">Sub-Root Assignment</param>
        /// <returns>New Unique Instance ID</returns>
        /// <exception cref="Exception">If impossible to create via given values exceed maximum UID Length</exception>
        public string GenerateUID(ulong root, ulong subRoot)
        {
            lock (locker)
            {
                if (rand == null)
                {
                    rand = new Random();
                }
                if (hash == null || hash.Length == 0)
                {
                    NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                    foreach (NetworkInterface adapter in nics)
                    {
                        if (adapter.OperationalStatus == OperationalStatus.Up)
                        {
                            PhysicalAddress a = adapter.GetPhysicalAddress();
                            int ahash = a.GetHashCode();
                            if (ahash == 0)
                            {
                                ahash = adapter.Id.GetHashCode();
                            }
                            decimal thash = System.Math.Abs(ahash);
                            hash = decimal.ToInt32(thash).ToString(CultureInfo.InvariantCulture);
                            break;
                        }
                    }

                    #region Use Machine Name as hash if NO MAC-ID
                    if (hash == null || hash.Length == 0)
                    {
                        decimal thash = System.Math.Abs(System.Environment.MachineName.GetHashCode());
                        hash = decimal.ToInt32(thash).ToString(CultureInfo.InvariantCulture);
                    }
                    #endregion
                }

                System.Text.StringBuilder b;

                if (UseDICOMRoot)
                {
                    b = new System.Text.StringBuilder("1.2.840.10008.");
                }
                else
                {
                    b = new System.Text.StringBuilder();
                }
                b.Capacity = maxGenerationLength;
                ulong threadId = System.Convert.ToUInt64(System.Threading.Thread.CurrentThread.GetHashCode());
                b.AppendFormat(CultureInfo.InvariantCulture, "{0}.{1}.{2}.{3}", root, subRoot, hash, threadId);
                if (b.ToString().Length > maxGenerationLength - 4)
                {
                    throw new Exception("Impossible to derive new UID. Try smaller values for root, sub-root, MACID or machine-name, and disable UseDICOMRoot flag");
                }
                while (b.ToString().Length <= maxGenerationLength - 1)
                {
                    int upperBound = maxGenerationLength - (b.ToString().Length);//number of characters remaining
                    if (upperBound <= 1) break;
                    --upperBound;//for the dot
                    b.Append(".");
                    string temp = "9";
                    for (int lcv = 1; lcv < upperBound; ++lcv)
                    {
                        Int64 sizeT = Int64.Parse(temp + "9", CultureInfo.InvariantCulture);
                        if (sizeT > int.MaxValue)
                        {
                            break;
                        }
                        temp = temp + "9";
                    }
                    Int64 sizeCheck = Int64.Parse(temp, CultureInfo.InvariantCulture);
                    if (sizeCheck > int.MaxValue)
                    {
                        upperBound = int.MaxValue;
                    }
                    else
                    {
                        upperBound = int.Parse(temp, CultureInfo.InvariantCulture);
                    }
                    if (upperBound > 1)
                    {
                        upperBound = rand.Next(1, upperBound);//this will cause random lengths
                    }
                    int x = rand.Next(1, upperBound);
                    b.Append(x);
                    if (b.ToString().Length >= maxGenerationLength - 1)//not enough for the dot
                        break;
                }
                //return new DialcareUIDGenerationService(b.ToString());
                Validate(b.ToString());
                return b.ToString(); 
            }
        }

        /// <summary>
        /// Standard constructor
        /// </summary>
        /// <param name="uid">Uid</param>
        private void Validate(string uid)
        {
            if (uid == null)
            {
                throw new ArgumentNullException("uid");
            }
            this.uid = uid.Trim();
            if (this.uid.Length == 0)
            {
                return;
            }

            if (this.uid[this.uid.Length - 1] == 0)
            {// Handle case of padding with extra zero null terminator for strings
                this.uid = this.uid.Substring(0, this.uid.Length - 1);
            }

            if (this.uid.Length > 64)
            {
                throw new Exception(uid + ">64");
            }

            if (this.uid.Length == 0)
            {
                throw new Exception(uid + " has zero length");
            }

            if (EnforceDigitDot)
            {

                //			char previousChar = '.';// We will need this to check for leading and orphaned periods
                foreach (char c in this.uid)
                {
                    if ((!System.Char.IsDigit(c)) && (c != '.'))
                    {
                        throw new Exception(uid + " has invalid char " + c);
                    }
                }

            }
        }
    }
}
