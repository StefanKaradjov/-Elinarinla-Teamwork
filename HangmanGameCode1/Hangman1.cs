using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Hangman1
    {

public void Play()
{
    string guessed_FoundLetters = new List<string>();
 
    for (int i = 0; i < PickedWord.WordLength; i++)
    // Add underscore to the guessed and found string collection
    {
        guessed_FoundLetters.Add(" _ ");
    }
 
    for (int i = 0; i < PickedWord.WordLength; i++)
    {
        string letter = PickedWord.Content.Substring(i, 1);
        if (GuessedLetters.Count > 0)
        {
            foreach (string guessedLetter in this.GuessedLetters)
            {
                if (letter.Equals(guessedLetter.Trim().ToUpper()))
                // If the guessed letter is found from the picked
                // word then replace underscore with the letter
                {
                    guessed_FoundLetters.RemoveAt(i);
                    guessed_FoundLetters.Insert(i, " " + letter + " ");
                }
            }
        }
    }
    drawHangMan();
    Console.WriteLine(buildString(guessed_FoundLetters, false));
    Console.WriteLine();
}
        }

