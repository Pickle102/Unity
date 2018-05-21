using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public AudioClip crack;
    public ParticleSystem smoke;

    private int timesHit;

    private LevelManager levelManager;

    private bool isBreakable;

    // Use this for initialization
    void Start () {
        timesHit = 0;

        levelManager = FindObjectOfType<LevelManager>();

        isBreakable = (this.tag == "Breakable");

        if (isBreakable)
        {
            ++breakableCount;
        }

        if (crack == null)
        {
            Debug.LogWarning("Crack audio clip is missing!");
        }

        if (smoke == null)
        {
            Debug.LogWarning("Smoke is missing!");
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Brick can break and the sound can keep playing
        AudioSource.PlayClipAtPoint(crack, transform.position);

        if (isBreakable)
        {
            HandleHits();
        }
    }

    private void HandleHits()
    {
        int maxHits = hitSprites.Length + 1;

        ++timesHit;

        // Destroy this game object
        if (timesHit >= maxHits)
        {
            --breakableCount;
            levelManager.BrickDestroyed();
            ParticleSystem smokeObj = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
            smokeObj.startColor = gameObject.GetComponent<SpriteRenderer>().color;
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    private void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }


    private void LoadSprites()
    {
        int spriteIndex = timesHit - 1;

        if (hitSprites[spriteIndex] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogWarning("Brick sprite missing!");
        }
    }
}
