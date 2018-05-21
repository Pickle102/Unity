using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    // True to have a bot play perfectly for us
    public bool autoPlay = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (autoPlay)
        {
            AutoPlay();
        }
        else
        {
            MoveWithMouse();
        }
    }

    private void MoveWithMouse()
    {
        Vector3 paddlePosition = new Vector3(0.5f, this.transform.position.y, 0.0f);

        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        paddlePosition.x = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);

        this.transform.position = paddlePosition;
    }

    private void AutoPlay()
    {
        Ball ball = FindObjectOfType<Ball>();

        Vector3 paddlePosition = new Vector3(0.5f, this.transform.position.y, 0.0f);
        paddlePosition.x = Mathf.Clamp(ball.transform.position.x, 0.5f, 15.5f);

        this.transform.position = paddlePosition;
    }
}
