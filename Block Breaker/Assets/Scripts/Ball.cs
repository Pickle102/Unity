using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;

    private Vector3 paddleToBallVector;
    private bool hasStarted;

	// Use this for initialization
	void Start () {
        paddle = FindObjectOfType<Paddle>();
        
        paddleToBallVector =  this.transform.position - paddle.transform.position;

    }
	
	// Update is called once per frame
	void Update () {

        // Keep the ball on the paddle until the player clicks to start the game
        if (!hasStarted)
        {
            // Lock ball to the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButton(0))
            {
                // Launch
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2.0f, 10.0f);
                hasStarted = true;
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioSource audio = GetComponent<AudioSource>();

            if (audio != null)
            {
                audio.Play();
            }
            else
            {
                Debug.LogWarning("Ball audio source is missing!");
            }

            // Add random velocity to stop ball hit looping error
            Vector2 tweak = new Vector2(Random.Range(0.0f, 0.2f), (Random.Range(0.0f, 0.2f)));
            this.GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
