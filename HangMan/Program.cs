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
            Console.WriteLine("---- HANGMAN ----");
            Console.WriteLine(" Whats your name?");

            HangMan();

            Console.ReadKey();
        }
        //hangmanfunction
        static void HangMan()
        {
            string input = Console.ReadLine();

            //this is the big loop to reset the game
            bool looping = true;
            while (looping)
            {
                Console.WriteLine();
                Console.WriteLine("Welcome, " + input + ", to HangMan."); //"/n" means start a new line
                Console.WriteLine("RULES:\n-----\nHere are the rules, you will be guessing a letter that you \nthink is found within the word.\nYou have only so many guesses before you lose.\nYou win, if you reveal the word through your guesses or if you guess the word itself.");
                Console.WriteLine("\n");

                //set the while loop variables
                bool looping2 = true;
                int loopCount = 0;
                int guessCount = 7;
                

                //word bank
                List<string> wordBank = new List<string> { "apple", "bears", "catfish", "doomed", "eagles", "fungus" };

                Random randNumGen = new Random();
                int randNum = randNumGen.Next(0, wordBank.Count - 1);

                // set the word and list variables to parse              
                string theWord = wordBank[randNum].ToUpper();
                List<char> theWordChar = new List<char> { };
                List<char> undScores = new List<char> { };

                string temp = "";
                string lettersGuessed = "";

                for (int i = 0; i < theWord.Length; i++)
                {
                    temp += "_ ";
                }
                Console.Write("|  ");
                Console.Write(temp);
                Console.WriteLine("  |");
                Console.WriteLine();

               
                while (looping2)
                {
                    //count the tries
                    loopCount++;

                    //get user input and compile into a list
                    string input2 = Console.ReadLine().ToUpper();
                    Console.WriteLine();

                    
                    if (input2.Length == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("please type in an answer.");
                    }
                    else if (input2.Length == 1)
                    {
                        int errorCount = 0;

                        //compile letters guessed for user reference                                            
                        if (lettersGuessed.Contains(Convert.ToChar(input2)))
                        {
                            Console.WriteLine("you have already guesed that letter please pick a new one.");

                        }
                        else
                        {
                            lettersGuessed += input2 + ", ";

                            Console.Write("|  ");
                            for (int i = 0; i < theWord.Length; i++)
                            {

                                //check to see what letter goes where
                                if (Convert.ToChar(input2) != theWord[i])
                                {
                                    errorCount++;

                                }
                                else if (Convert.ToChar(input2) == theWord[i])
                                {
                                    temp = temp.Insert(i * 2, input2 + " ").Remove((i * 2 + 2), 2);
                                }

                            }


                            //decrement for making a wrong guess
                            if (errorCount == theWord.Length)
                            {
                                guessCount--;
                            }

                            Console.Write(temp);
                            Console.WriteLine("  |");
                            Console.WriteLine();
                            Console.WriteLine("Letters Guessed: " + lettersGuessed);
                            Console.WriteLine("Chances Left: " + guessCount);
                            Console.WriteLine();
                        }

                        string revealed = temp.Replace(" ", "");

                        if (revealed == theWord)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Congrats! you win.");
                            Console.WriteLine("It took you " + loopCount + " guesses.");
                            Console.WriteLine("\nWould you like to play again?\nYes or No?\n");
                            input2 = Console.ReadLine().ToUpper();
                            if (input2 == "Y" || input2 == "YES")
                            {
                                looping2 = false;
                            }
                            else
                            {
                                looping = false;
                                looping2 = false;
                            }

                        }

                    }
                    else
                    {
                        if (theWord == input2)
                        {
                            Console.WriteLine("yes" + input + ", is the right anser!");
                            Console.WriteLine("It took you " + loopCount + "guesses.");
                            Console.WriteLine("\n\nwant to play again?\nYes or No?");
                            input2 = Console.ReadLine().ToUpper();
                            if (input2 == "Y" || input2 == "YES")
                            {
                                looping2 = false;
                            }
                            else
                            {
                                looping = false;
                                looping2 = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("No that is not the word.");
                            guessCount--;
                            Console.WriteLine("guesses left: " + guessCount);
                        }
                    }
                    if (guessCount == 0)
                    {
                        Console.WriteLine("you have lost.");
                        Console.WriteLine("want to play again? yes or no.");
                        if (input2 == "Y" || input2 == "YES")
                        {
                            looping2 = false;
                        }
                        else
                        {
                            looping = false;
                            HangMan();
                        }

                           
                    }
                    
                }
            }
        }
    }
}