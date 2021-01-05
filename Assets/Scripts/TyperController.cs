using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TyperController : MonoBehaviour
{
    // You need a word bank.
    public WordBank wordBank = null;
    public Text wordOutput = null;

    private string remainingWord = string.Empty;
    // private string currentWord = "Muffins";
    private string currentWord = string.Empty;

    private void Start()
    {
        SetCurrentWord();
    }

    private void SetCurrentWord()
    {
        // Get bank word.
        currentWord = wordBank.GetWord();

        SetRemainingWord(currentWord);
    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        
        // yg diketikin di text hirarki
        wordOutput.text = remainingWord;
    }

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if(Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if(keysPressed.Length == 1)
            {
                EnterLetter(keysPressed);
            }
            
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if(isCorrectLetter(typedLetter))
        {
            RemoveLetter();

            if(IsWordComplete())
            {
                SetCurrentWord();
            }
        }
    }

    private bool isCorrectLetter(string letter)
    {
        // return false;
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete()
    {
        // return false;
        return remainingWord.Length == 0;
    }
}
