using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerManager : MonoBehaviour {

    public int playerCount { get; private set; }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Connect(MovePlayer go)
    {
        playerCount++;
        go.Connected(playerCount);
    }
}
