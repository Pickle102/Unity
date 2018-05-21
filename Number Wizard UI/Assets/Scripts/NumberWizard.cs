using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // SceneManagement
using UnityEngine.UI; // Text

public class NumberWizard : MonoBehaviour {

    public int maxGuessesAllowed;
    public int maxNumber;
    public int minNumber;

    public Text guessText;

    private int max;
    private int min;
    private int guess;

    // Use this for initialization
    void Start ()
    {
        StartGame();
    }

    void StartGame()
    {
        guessText.text = "Welcome to Number Wizard\n";
        guessText.text += "Print a number in your head, but don't tell me!\n";

        max = maxNumber;
        min = minNumber;
        guess = Random.Range(min, max+1);

        guessText.text += "The highest number you can pick is " + max + "\n";
        guessText.text += "The lowest number you can pick is " + min + "\n";

        guessText.text += "Is the number higher or lower than " + guess + "?\n";
    }

    void NextGuess()
    {
        guess = Random.Range(min, max+1);
        guessText.text = "Higher or lower than " + guess + "?";

        --maxGuessesAllowed;

        if (maxGuessesAllowed <= 0)
        {
            SceneManager.LoadScene("Win");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void GetHigher()
    {
        min = guess;
        NextGuess();
    }

    public void GetLower()
    {
        max = guess;
        NextGuess();
    }

    public void GetEqual()
    {
        SceneManager.LoadScene("Lose");
    }
}
