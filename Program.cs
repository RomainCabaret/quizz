using System;

namespace FirstProgramme
{
    class Program
    {
        enum e_Operator
        {
            ADDITION = 1,
            MULTIPLICATION = 2,
            SOUSTRACTION = 3,

        }

        static bool StartQuizz(int min, int max, int question)
        {
            Random rnd = new Random();
            int userAnswerInt = 0;

            int randomIntOne = rnd.Next(min, max + 1);
            int randomIntTwo = rnd.Next(min, max + 1);
            e_Operator randomOperator = (e_Operator)rnd.Next(1, 4);

            int correctcalc;
            while (true)
            {
                switch (randomOperator)
                {
                    case e_Operator.ADDITION:
                        Console.Write($"{randomIntOne} + {randomIntTwo} = ");
                        correctcalc = randomIntOne + randomIntTwo;
                        break;
                    case e_Operator.MULTIPLICATION:
                        Console.Write($"{randomIntOne} * {randomIntTwo} = ");
                        correctcalc = randomIntOne * randomIntTwo;
                        break;
                    case e_Operator.SOUSTRACTION:
                        Console.Write($"{randomIntOne} - {randomIntTwo} = ");
                        correctcalc = randomIntOne - randomIntTwo;
                        break;
                    default:
                        Console.Write("ERREUR : opérateur inconnu");
                        return false;
                }
                string userAnswerStr = Console.ReadLine();
                try
                {
                    userAnswerInt = int.Parse(userAnswerStr);
                    break;
                }
                catch
                {
                    Console.WriteLine("ERREUR : vous devez rentrer un nombre");
                }
            }

            if (userAnswerInt == correctcalc)
            {
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            const int NUMBER_MIN = 1;
            const int NUMBER_MAX = 10;
            const int NB_QUESTION = 5;

            int score = 0;

            for (int i = 0;i < NB_QUESTION; i++)
            {
                Console.WriteLine($"Question n°{i+1}/{NB_QUESTION}");

                bool GoodAnswer = StartQuizz(NUMBER_MIN, NUMBER_MAX, NB_QUESTION);

                if (GoodAnswer)
                {
                    Console.WriteLine("Bonne réponse\n");
                    score++;
                }
                else
                {
                    Console.WriteLine("Mauvaise réponse\n");
                }
            }

            Console.WriteLine($"Nombre de points : {score}/{NB_QUESTION}");

            const int avg = (NB_QUESTION / 2);

            if (score == NB_QUESTION)
            {
                Console.WriteLine("Excellent");
            }
            else if (score == 0)
            {
                Console.WriteLine("Révisez vos maths !");
            }
            else if (score > avg) 
            {
                Console.WriteLine("Pas mal !");
            }
            else
            {
                Console.WriteLine("Peut mieux faire.");
            }
            
        }

    }
}