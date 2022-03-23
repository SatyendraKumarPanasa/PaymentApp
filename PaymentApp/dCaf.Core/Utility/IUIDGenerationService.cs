namespace dCaf.Core.Utility
{
    public interface IUIDGenerationService
    {
        string GenerateUID(ulong root, ulong subRoot);
    }
}
