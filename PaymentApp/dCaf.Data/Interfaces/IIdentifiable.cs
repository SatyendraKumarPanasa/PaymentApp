using System;
using System.Collections.Generic;
using System.Text;

namespace dCaf.Data
{
    public interface IIdentifiable<T> where T : IEquatable<T>
    {
        T Id { get; set; }
    }
}
