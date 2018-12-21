using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour {

    public int maxLives = 5;
    int lives = 5;
    public GameObject wall;
	// Use this for initialization
	void Start () {
        lives = maxLives;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int ActualLives()
    {
        return lives;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "disk") 
            lives--;
        if(lives == 0)
        {
            wall.SetActive(true);
        }
    }
}
