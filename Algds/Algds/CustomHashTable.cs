using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algds
{
    public class HashNode
    {
        public int Key { get; set; }
        public int Val { get; set; }
    }
    public class CustomHashTable
    {
        private HashNode[] arr;
        public int Size { get; private set; }

        public CustomHashTable(int capacity)
        {
            arr = new HashNode[capacity];
        }

        private int Hash(int key, int probeDepth)
        {
            return (key + probeDepth) % arr.Length;
        }

        public void Insert(int key, int val)
        {
            int hashIndex = this.Hash(key, 0);
            int probeDepth = 0;
            while (arr[hashIndex] != null && arr[hashIndex].Key != key)
            {
                hashIndex = this.Hash(hashIndex, probeDepth);
                probeDepth++;
            }
            arr[hashIndex] = new HashNode() { Key = key, Val = val };
        }

        public int DeleteKey(int key)
        {
            throw new NotImplementedException();
        }

        public int Find(int key)
        {
            throw new NotImplementedException();
        }
    }
}
