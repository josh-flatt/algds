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
        private HashNode deletedHashNode = new HashNode();
        public int Size { get; private set; }

        public CustomHashTable(int capacity)
        {
            arr = new HashNode[capacity];
        }

        private int Hash(int key, int probeDepth)
        {
            return (key + probeDepth) % arr.Length;
        }

        private int FindHashIndex(int key, bool findNextEmpty = false)
        {
            int hashIndex = this.Hash(key, 0);
            int probeDepth = 1;
            while (arr[hashIndex] != null)
            {
                if (arr[hashIndex].Key == key && arr[hashIndex] != deletedHashNode)
                {
                    if (findNextEmpty) { return this.Hash(hashIndex, probeDepth + 1); }
                    return hashIndex;
                }
                hashIndex = this.Hash(hashIndex, probeDepth);
                probeDepth++;
            }
            return findNextEmpty ? hashIndex : -1;
        }

        public void Insert(int key, int val)
        {
            int hashIndex = FindHashIndex(key, true);
            arr[hashIndex] = new HashNode() { Key = key, Val = val };
        }

        public bool DeleteKey(int key)
        {
            int hashIndex = FindHashIndex(key);
            if (hashIndex == -1) { return false; }
            arr[hashIndex] = this.deletedHashNode;
            return true;
        }

        public int PopKey(int key)
        {
            int hashIndex = FindHashIndex(key);
            if (hashIndex == -1) { throw new KeyNotFoundException(); }
            int value = arr[hashIndex].Val;
            arr[hashIndex] = this.deletedHashNode;
            return value;
        }

        public int Find(int key)
        {
            int hashIndex = FindHashIndex(key);
            if (hashIndex == -1) { throw new KeyNotFoundException(); }
            return arr[hashIndex].Val;
        }
    }
}
