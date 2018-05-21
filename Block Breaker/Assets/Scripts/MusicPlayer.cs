using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer _instance;

    public void Awake()
    {
        // Make the music player a singleton
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;

            // We will play this music in all scenes
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
