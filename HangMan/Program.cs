using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            //gamestart
            HangMan();
            Console.ReadKey();
        }
        //hangmanfunction
        static void HangMan()
        {
            Console.WriteLine("---- HANGMAN ----");
            Console.WriteLine(" Whats your name?");
            // holds player name
            string playerName = Console.ReadLine();                 //"\n" means start a new line within the text
            Console.WriteLine("Hello " + playerName + " this is hangman\nyou have to guess the right letters to form the word \nor just guess the whole word.");
            Console.WriteLine("guess wrong 7 times and you lose");
            Console.WriteLine("by the way this is your hanging good luck.");
            //boolean for continuing the game or not
            bool playing = true;
            int lives = 7;//number of guesses
            //create our word bank
            List<string> wordBank = new List<string>() { "apples", "honeybees", "caterpillar" };
            Random rng = new Random();//make a new rng
            //select a random number between 0 and the #
            // of things in our wordBank list
            int randomNumber = rng.Next(0, wordBank.Count());
            //chosse a randome item from our wordBank list
            string wordToGuess = wordBank[randomNumber].ToUpper();
            //need to track letters they've guessed
            //force it to uppercase
            string lettersGuessed = string.Empty;
            //start game
            while (playing)
            {
                //1. show the masked word
                Console.WriteLine(MaskedWord(wordToGuess, lettersGuessed));
                //2. tell them how many lives you have left
                Console.WriteLine("you have " + lives + " lives left");
                //3.ask for input
                Console.WriteLine("enter a guess");
                //4.get input
                string input = Console.ReadLine().ToUpper();
                //determie if its a letter or a word guess
                if (input.Length == 1)
                {
                    lettersGuessed += input;
                    if (wordToGuess.Contains(input))
                    {
                        //corect guess
                        Console.WriteLine("good job");
                        if (AllLettersGuessed(MaskedWord(wordToGuess, lettersGuessed)))
                        {
                            playing = false;
                            Console.WriteLine("you have been spared " + playerName + " you win!");                          
                        }
                    }
                    else
                    {
                        //incorect guess
                        Console.WriteLine("that is not one of the letters.");
                        lives--;
                        Console.WriteLine("guesses left " + lives);
                    }
                }
                else
                {
                    //word guess
                    if (wordToGuess == input)
                    {
                        //they won
                        Console.WriteLine("you have been spared " + playerName + " you win!");
                        playing = false;
                    }
                    else
                    {
                        //lose a life
                        Console.WriteLine("that is the incorect word");
                        lives--;
                    }
                }
                //check for loss because of life
                if (lives == 0)
                {
                    playing = false;
                    Console.WriteLine("you have been hanged " + playerName + " You lose.");

                }
            }
        }

        static string MaskedWord(string wordToGuess, string lettersGuessed)
        {
            //a string to return our masked word.
            // ex: a_ _ l _
            string returnString = "";

            //loop over the string to examine each character
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                //get a character fom wordToGuess by using
                // the index i
                char letter = wordToGuess[i];

                //if the letter in the wordToGuess
                // has been guessed by the user
                //using char.ToUpper() to make sure its uppercase
                if (lettersGuessed.ToUpper().Contains(char.ToUpper(letter)))
                {
                    //they've guessed the letter, so print the letter
                    // not the underscore
                    returnString += letter + " ";
                    //returnString = returnString + letter; is the same
                }
                else
                {
                    //did not guess the letter, add an underscore
                    // to our return string
                    returnString += "_" + " ";
                }

            }
            //return the returnString
            return returnString;
        }

        static bool AllLettersGuessed(string maskedWord)
        {


            //determine if the user has guesed all the letters of the word
            if (maskedWord.Contains("_"))
            {
                return false;
            }
            else
            {
                return true;
            }
            //one line solution: not maskedWord contains 
            //
        }
    }
}