namespace Algds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomHashTable hashTable = new CustomHashTable(10);
            hashTable.Insert(65, 1); // 'a' = 65
            hashTable.Insert(75, 2);
            hashTable.DeleteKey(65);
            int findResult = hashTable.PopKey(75);
            Console.WriteLine(findResult);
        }
    }
}