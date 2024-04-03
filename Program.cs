

class Program
{
    public static void Main()
    {
        string[] words = new string[] { "volvo", "mazda", "piano", "chair", "shirt", "fives", "guess" }; //word list. Wil change later
        char[] ansPanel = { '_', '_', '_', '_', '_' };
        List<char> wrongPlace = new List<char>();
        string Guess;
        bool wordLength = false; //Loop around to make sure user input is valid
        bool notNum = false;

        //pick random word from the list
        int randPick = new Random().Next(words.Length);
        string chosenWord = words[randPick];
        Console.WriteLine(chosenWord); //Testing purposes

        //ask user for guess and check user input
        Console.WriteLine("Try to guess the random 5 letter word");

        //For loop here to allow multiple tries
        for (int tries = 0; tries < 5; tries++)
        {
            wrongPlace.Clear(); //Empties list of correct letters in the wrong place. Past lists still visible
            do
            {
                wordLength = false;
                notNum = false;
                Guess = Console.ReadLine().ToLower(); //Case matching
                if (Guess.Length == chosenWord.Length)
                {
                    wordLength = true;
                    notNum = Guess.All(c => (c >= 'a' && c <= 'z')); //Copy and pasted but know what it does, was just lazy to fugure it out myself https://www.techiedelight.com/check-if-string-contains-only-letters-in-csharp/
                    Console.WriteLine(notNum); //Testing purposes
                }
                else
                {
                    Console.WriteLine("Please pick a 5 letter word");
                }
            } while (wordLength == false || notNum == false);

            

            //Time to compare the guess vs word
            if (chosenWord == Guess)
            {
                Console.WriteLine("Congrats! You did it! The word was:");
                Console.WriteLine(chosenWord);
                break;
            }
            else
            {
                //Check to see if a letter is in the right place
                for (int pos = 0; pos < Guess.Length; pos++)
                {
                    if (Guess[pos] == chosenWord[pos])
                    {
                        ansPanel[pos] = chosenWord[pos];
                    }
                    else 
                    {
                        for (int Wpos2 = 0; Wpos2 < Guess.Length; Wpos2++)
                        {
                            if (Guess[pos] == chosenWord[Wpos2])
                            {
                                if (!wrongPlace.Contains(Guess[pos]))
                                {
                                    wrongPlace.Add(Guess[pos]);
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("The answer panel:");
                Console.WriteLine(ansPanel);

                char[] wrongPlaceArray = wrongPlace.ToArray();
                Console.WriteLine("Correct letters but wrong place:");
                Console.WriteLine(wrongPlaceArray);
            }
        }

    }
}