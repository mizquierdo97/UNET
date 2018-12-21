using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesText : MonoBehaviour {

    Text livesText;
    public PlayerLives livesScript;
	// Use this for initialization
	void Start () {
        livesText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        livesText.text = livesScript.ActualLives().ToString();
	}
}