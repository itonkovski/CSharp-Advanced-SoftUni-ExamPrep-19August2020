using System;
using System.Linq;
using System.Collections.Generic;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] secondInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> lilliesStack = new Stack<int>(firstInput);
            Queue<int> rosesQueue = new Queue<int>(secondInput);

            int wreathsCounter = 0;
            int storredFlowers = 0;

            while (lilliesStack.Any() && rosesQueue.Any())
            {
                int currentLillies = lilliesStack.Peek();
                int currentRoses = rosesQueue.Peek();
                int flowersSum = currentLillies + currentRoses;

                if (flowersSum == 15)
                {
                    wreathsCounter++;
                    lilliesStack.Pop();
                    rosesQueue.Dequeue();
                }
                else if (flowersSum > 15)
                {
                    lilliesStack.Pop();
                    lilliesStack.Push(currentLillies - 2);
                    continue;
                }
                else if (flowersSum < 15)
                {
                    storredFlowers += flowersSum;
                    lilliesStack.Pop();
                    rosesQueue.Dequeue();
                }
            }

            int storredResult = storredFlowers / 15;
            if (wreathsCounter + storredResult >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCounter + storredResult} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - (wreathsCounter + storredResult)} wreaths more!");
            }
        }
    }
}
