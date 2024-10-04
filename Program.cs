using System;
using System.Collections.Generic; // Allows you to use lists
using static System.Random;
using System.Text;

namespace Hangman;

internal class Program
{
    private static void printHangman(int wrong) 
    {
        if(wrong == 0)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine("    |");
            Console.WriteLine("    |");
            Console.WriteLine("    |");
            Console.WriteLine("   ===");

        }
        else if (wrong == 1)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine("    |");
            Console.WriteLine("    |");
            Console.WriteLine("    |");
            Console.WriteLine("   ===");
        }
        else if (wrong == 2)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine("    |");
            Console.WriteLine("|   |");
            Console.WriteLine("    |");
            Console.WriteLine("   ===");
        }
        else if (wrong == 3)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine(" O  |");
            Console.WriteLine("/|  |");
            Console.WriteLine("    |");
            Console.WriteLine("   ===");
        }
        else if (wrong == 4)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine(" O  |");
            Console.WriteLine("/|\\ |");
            Console.WriteLine("    |");
            Console.WriteLine("   ===");
        }
        else if (wrong == 5)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine(" O  |");
            Console.WriteLine("/|\\ |");
            Console.WriteLine("/   |");
            Console.WriteLine("   ===");
        }
        else if (wrong == 6)
        {
            Console.WriteLine("\n+---+");
            Console.WriteLine(" O   |");
            Console.WriteLine("/|\\  |");
            Console.WriteLine("/ \\|");
            Console.WriteLine("   ===");
        }
    }

    private static int printWord(List<char>guessedLetters, String randomWord)
    {
        int counter = 0;
        int rightLetters = 0;
        Console.WriteLine("\r\n");
        foreach (char c in randomWord)
        {
            if(guessedLetters.Contains(c))
            {
                Console.WriteLine(c + " ");
                rightLetters++;
            }
            else
            {
                Console.WriteLine(" ");
            }
            counter++;
        }
        return rightLetters;
    }

    private static void printLines(String randomWord)
    {
        Console.WriteLine("\r");
        foreach(char c in randomWord)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.Write("\u0305 ");
        }
    }




    static void Main(string[] args)
    {
        Console.WriteLine("Welcome To Hangman!");
        Console.WriteLine("---------------------------------------------------");

        Random random = new Random();
        List<string> wordDictionary = new List<string> {"sunflower", "house", "diamond", "memes", "tequila", "banana", "chiquita"};
        int index = random.Next(wordDictionary.Count);
        String randomWord = wordDictionary[index];

        foreach (char x in randomWord)
        {
            Console.Write("_ ");
        }

        int lenghtOfWordToGuess = randomWord.Length;
        int amountOfTimesWrong = 0;
        List<char> currentLettersGuessed = new List<char>();
        int currentLettersRight = 0;

        while(amountOfTimesWrong != 6 && currentLettersRight != lenghtOfWordToGuess)
        {
            Console.Write("\nLetters guesses so far: ");
            foreach(char letter in currentLettersGuessed)
            {
                Console.Write(letter + " ");
            }
            //prompt user for input
            Console.Write("\nGuess a letter:"); 
            char letterGuessed = Console.ReadLine()[0];
            //check if letter have been used
            if(currentLettersGuessed.Contains(letterGuessed))
            {
                Console.Write("\r\nYou have allready guessed that letter.");
                printHangman(amountOfTimesWrong);
                currentLettersRight = printWord(currentLettersGuessed, randomWord);
                printLines(randomWord);
            }
            else
            {
                //check if letter is in the word
                bool right = false;
                for ( int i = 0; i < randomWord.Length; i++) { if (letterGuessed == randomWord[i]) {right = true; }
                 }

                if(right)
                {
                    printHangman(amountOfTimesWrong);
                    currentLettersGuessed.Add(letterGuessed);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                    Console.Write("\r\n");
                    printLines(randomWord);
                }
                else
                {
                    amountOfTimesWrong++;
                    currentLettersGuessed.Add(letterGuessed);
                    printHangman(amountOfTimesWrong);
                    currentLettersRight = printWord(currentLettersGuessed, randomWord);
                    Console.Write("\r\n");
                    printLines(randomWord);

                }
            }


        }
        Console.WriteLine("\r\nGame is over, Thank you for playing.");
    }
 }