using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var inputData = DisjointSet.InputDataFormatted();
            var set = new DisjointSet(inputData);
            set.Realisation();
        }
    }
}