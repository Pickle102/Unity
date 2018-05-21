using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {

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
        print("========================");
        print("Welcome to Number Wizard");
        print("Print a number in your head, but don't tell me!");

        max = 1000;
        min = 1;
        guess = (max + min) / 2;

        print("The highest number you can pick is " + max);
        print("The lowest number you can pick is " + min);

        print("Is the number higher or lower than " + guess + "?");
        print("Up arrow for higher, down arrow for lower, return for equal.");
    }

    void NextGuess()
    {
        print("Higher or lower than " + guess + "?");
        print("Up arrow for higher, down arrow for lower, return for equal.");
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Handle user input
		if (Input.GetKeyDown("up"))
        {
            min = guess;
            guess = (int)(((float)max + min) / 2 + 0.5);
            NextGuess();
        }
        else if (Input.GetKeyDown("down"))
        {
            max = guess;
            guess = (max + min) / 2;
            NextGuess();
        }
        else if (Input.GetKeyDown("return"))
        {
            print("You won!");
            StartGame();
        }
	}
}
