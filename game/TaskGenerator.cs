using System;

namespace MathGame
{
    class TaskGenerator
    {
        private Random random;
        private int maxNumber;

        public TaskGenerator()
        {
            random = new Random();
            maxNumber = 100;
        }

        public Task GenerateTask()
        {
            int num1 = GenerateRandomNumber(1, maxNumber);
            int num2 = GenerateRandomNumber(1, maxNumber);

            return new Task { Number1 = num1, Number2 = num2 };
        }

        private int GenerateRandomNumber(int min, int max)
        {
            return random.Next(min, max + 1);
        }
    }
}
