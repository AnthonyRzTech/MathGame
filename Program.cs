using System;

class Program
{
    static void Main(string[] args)
    {
        MathGame.RunGameMenu();
    }
}

public class MathGame
{
    private static Random random = new Random();
    private static int score = 0;

    public static void RunGameMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Jeu de Mathématiques ===");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Soustraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Voir les scores");
            Console.WriteLine("6. Quitter");
            Console.Write("Choisissez une option (1-6) : ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Vous avez choisi l'addition.");
                    (int x, int y) = Level();
                    Addition(x, y);
                    break;
                case "2":
                    Console.WriteLine("Vous avez choisi la soustraction.");
                    (x, y) = Level();
                    Soustraction(x, y);
                    break;
                case "3":
                    Console.WriteLine("Vous avez choisi la multiplication.");
                    (x, y) = Level();
                    Multiplication(x, y);
                    break;
                case "4":
                    Console.WriteLine("Vous avez choisi la division.");
                    (x, y) = Level();
                    Division(x, y);
                    break;
                case "5":
                    Console.WriteLine($"Votre score actuel est : {score}");
                    break;
                case "6":
                    Console.WriteLine("Merci d'avoir joué ! Au revoir.");
                    return;
                default:
                    Console.WriteLine("Option non valide. Veuillez réessayer.");
                    break;
            }

            Console.WriteLine("\nAppuyez sur une touche pour continuer...");
            Console.ReadKey();
        }
    }

    public static void Addition(int x, int y)
    {
        Console.WriteLine($"{x} + {y} = ?");
        int correctAnswer = x + y;
        CheckAnswer(correctAnswer);
    }

    public static void Soustraction(int x, int y)
    {
        Console.WriteLine($"{x} - {y} = ?");
        int correctAnswer = x - y;
        CheckAnswer(correctAnswer);
    }

    public static void Multiplication(int x, int y)
    {
        Console.WriteLine($"{x} * {y} = ?");
        int correctAnswer = x * y;
        CheckAnswer(correctAnswer);
    }

    public static void Division(int x, int y)
    {
        // Assurons-nous que la division soit possible
        int product = x * y;
        Console.WriteLine($"{product} / {y} = ?");
        int correctAnswer = x;
        CheckAnswer(correctAnswer);
    }

    public static void CheckAnswer(int correctAnswer)
    {
        Console.Write("Votre réponse : ");
        if (int.TryParse(Console.ReadLine(), out int userAnswer))
        {
            if (userAnswer == correctAnswer)
            {
                Console.WriteLine("Correct ! +1 point");
                score++;
            }
            else
            {
                Console.WriteLine($"Incorrect. La bonne réponse était {correctAnswer}.");
            }
        }
        else
        {
            Console.WriteLine("Réponse invalide. Aucun point accordé.");
        }
    }

    public static (int, int) Level()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Niveau de difficulté ===");
            Console.WriteLine("1. Facile");
            Console.WriteLine("2. Moyen");
            Console.WriteLine("3. Difficile");
            Console.Write("Choisissez un niveau (1-3) : ");
            string choice = Console.ReadLine();

            int x = 0, y = 0;
            switch (choice)
            {
                case "1":
                    x = 1; y = 10;
                    break;
                case "2":
                    x = 11; y = 50;
                    break;
                case "3":
                    x = 51; y = 100;
                    break;
                default:
                    Console.WriteLine("Option non valide. Veuillez réessayer.");
                    continue;
            }

            int num1 = random.Next(x, y + 1);
            int num2 = random.Next(x, y + 1);
            return (num1, num2);
        }
    }
}