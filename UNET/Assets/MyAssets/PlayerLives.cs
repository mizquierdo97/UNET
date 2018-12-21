using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour {

    public int maxLives = 5;
    int lives = 5;
	// Use this for initialization
	void Start () {
		
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
    }
}
