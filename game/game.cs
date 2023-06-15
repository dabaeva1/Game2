using System;

namespace MathGame
{
    class Game
    {
        private TaskGenerator taskGenerator;
        private TaskSolver taskSolver;
        private AnswerChecker answerChecker;

        public Game()
        {
            taskGenerator = new TaskGenerator();
            taskSolver = new TaskSolver();
            answerChecker = new AnswerChecker();
        }

        public void Start()
        {
            Console.WriteLine("Игра на сложение чисел.");

            int totalTasks = 5;
            int correctAnswersCount = 0;
            int attempts = 3; // оставшиеся попытки у пользователя

            for (int i = 0; i < totalTasks; i++)
            {
                // Генерируем задание
                Task task = taskGenerator.GenerateTask();

                // Выводим задание на экран
                Console.WriteLine($"Задание {i + 1}:");
                Console.WriteLine($"Сложите два числа: {task.Number1} + {task.Number2}");

                // Получаем ответ от пользователя
                int userAnswer = GetUserAnswer();

                // Решаем задачу
                int correctAnswer = taskSolver.SolveTask(task);

                // Проверяем ответ
                bool isAnswerCorrect = answerChecker.CheckAnswer(userAnswer, correctAnswer);

                if (isAnswerCorrect)
                {
                    Console.WriteLine("Ответ правильный.");
                    correctAnswersCount++;
                }
                else
                {
                    attempts--;
                    Console.WriteLine("Ответ неправильный.");
                    if (attempts == 0)
                    {
                        Console.WriteLine("Игра окончена. Попробуйте еще раз.");
                        return; // Завершение игры
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Игра окончена. Правильных ответов: {correctAnswersCount}/{totalTasks}.");
        }

        private int GetUserAnswer()
        {
            Console.Write("Ваш ответ: ");
            return int.Parse(Console.ReadLine());
        }
    }
}
