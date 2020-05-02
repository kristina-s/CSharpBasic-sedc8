using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections.Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Non-generic collections

            // ArrayList
            Console.WriteLine("-------------------- ArrayList ---------------");

            ArrayList arrList = new ArrayList() { 1, true, "turlitava" };
            foreach (var item in arrList)
            {
                Console.WriteLine(item);
            }
            arrList.Add(new int[] { 3, 5, 12 });
            Console.WriteLine($"Count of arr list {arrList.Count}");

            // Generic Collections
            // We can make instance of those classes with different types, they get they type when we initialise them to be of certain type
            Console.WriteLine("-------------------- List ---------------");

            List<int> numbersList = new List<int> { 1, 2, 3 };
            Console.WriteLine($"Count of numbers list - initial: {numbersList.Count}");
            numbersList.Add(4);
            numbersList.Add(5);
            Console.WriteLine($"Count of numbers list - after Add: {numbersList.Count}");
            List<int> numsToAdd = new List<int> { 6, 7, 8, 9, 10 };
            numbersList.AddRange(numsToAdd);
            Console.WriteLine($"Count of numbers list - after AddRange: {numbersList.Count}");
            numbersList.Remove(10);

            // If I try to remove non-existing member, nothing happens
            numbersList.Remove(11);
            Console.WriteLine($"Count of numbers list - after Remove: {numbersList.Count}");

            Console.WriteLine("-------------------- Dictionary ---------------");
            Dictionary<int, string> memberDictionary = new Dictionary<int, string>()
            {
                {1, "Dejan" },
                {2, "Kristina" }
            };

            // check value of a key
            Console.WriteLine("Member with key 1 is: {0}", memberDictionary[1]);
            // 1 is not the index, it is the key []

            //Console.WriteLine("Member with key 5 is: {0}", memberDictionary[5]);
            // this will throw an exception, key is not found
            // safe way with TryGetValue
            var memberExists = memberDictionary.TryGetValue(5, out string value5);
            Console.WriteLine(memberExists ? value5 : "No such key in the dictionary");

            // we can add values, but the couldn't be duplicate
            //memberDictionary.Add(2, "Bob");
            memberDictionary.Add(3, "John");

            // change the value of an existing key
            memberDictionary[2] = "Bob";
            foreach (var item in memberDictionary)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            };

            memberDictionary.Remove(3);

            // if we try to remove key that doesn't exist, nothing happens
            memberDictionary.Remove(5);

            Console.WriteLine("-------------------- Queue ---------------");
            Queue<string> bankQueue = new Queue<string>();
            // we cannot fill it immediately
            bankQueue.Enqueue("Ace");
            bankQueue.Enqueue("Bojana");
            foreach (var item in bankQueue)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("First served is {0}", bankQueue.Peek());
            bankQueue.Dequeue();
            bankQueue.Dequeue();


            // now the queue is empty
            //bankQueue.Peek();
            // bankQueue.Dequeue();

            // these will throw an exception
            // safe way
            var queueNotEmpty = bankQueue.TryPeek(out string person);
            Console.WriteLine(queueNotEmpty ? person : "Queue is empty!");






            Console.ReadLine();
        }
    }
}
