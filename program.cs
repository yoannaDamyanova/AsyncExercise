using System;

namespace SortQueue
{
    internal class Program
    {

        static async Task Main()
        {
            Queue<Person> peopleQueue = new Queue<Person>();
            await Console.Out.WriteLineAsync("Enter number of people:");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                peopleQueue.Enqueue(new Person(input[0], int.Parse(input[1])));
            }

            Task<Queue<Person>> sortQueueTask = SortQueueAsync(peopleQueue);
            Queue<Person> sortedQueue = await sortQueueTask;

            Console.WriteLine("Sort Queue by Age:");
    
            foreach (Person person in sortedQueue)
            {
                Console.WriteLine($"{person.Name} - {person.Age} years old");
            }
        }
        static async Task<Queue<Person>> SortQueueAsync(Queue<Person> queue)
        {
            Queue<Person> sortedQueue = new Queue<Person>(queue.OrderBy(p => p.Age));
            return sortedQueue;
        }
    }
}
