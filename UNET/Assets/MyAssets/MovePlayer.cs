using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MovePlayer : NetworkBehaviour {

    public int playerCount = 0;
    KeyCode upCode;
    KeyCode downCode;
    Transform trans;
    public float speed = 6;
    public PlayerManager playerManager;
    // Use this for initialization
    Vector3 moveVec;
    void Start () {

        playerManager = GameObject.Find("NetworkManager").GetComponent<PlayerManager>();
        playerManager.Connect(this);

        if (playerCount == 1)
        {
            upCode = KeyCode.W;
            downCode = KeyCode.S;
            moveVec = new Vector3(0, 0, 1);
            transform.position = new Vector3(-5.0f, -0.5f, 0.0f);
            transform.rotation = Quaternion.Euler(0,90,0);
        }
        if (playerCount == 2)
        {
            upCode = KeyCode.R;
            downCode = KeyCode.F;
            moveVec = new Vector3(0, 0, -1);
            transform.position = new Vector3(5.0f, -0.5f, 0.0f);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (playerCount == 3)
        {
            upCode = KeyCode.Y;
            downCode = KeyCode.H;
            moveVec = new Vector3(1, 0, 0);
            transform.position = new Vector3(0.0f, -0.5f, -5.0f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (playerCount == 4)
        {
            upCode = KeyCode.I;
            downCode = KeyCode.K;
            moveVec = new Vector3(-1, 0, 0);
            transform.position = new Vector3(0.0f, -0.5f, 5.0f);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        trans = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer) return;

        if (Input.GetKey(upCode))
        {
            trans.position = trans.position + moveVec * Time.deltaTime * speed;
        }
        if (Input.GetKey(downCode))
        {
            trans.position = trans.position - moveVec * Time.deltaTime * speed;
        }

    }
    public void Connected(int num)
    {
        playerCount = num;
    }
}
