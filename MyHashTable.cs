using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALG_LAB2
{
    public abstract class MyHashTable
    {
        public abstract double Put(string key, double value);
        public abstract double? Get(string key);
        public abstract bool Contains(string key);
        public abstract int operationsCount { get; set; }
    }
}