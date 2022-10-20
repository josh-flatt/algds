namespace Algds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomHashTable hashTable = new CustomHashTable(10);
            hashTable.Insert(65, 1); // 'a' = 65
            int findResult = hashTable.Find(65);
            Console.WriteLine(findResult);
        }
    }
}