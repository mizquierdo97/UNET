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
    int rotDirection = 1;
    Vector3 moveVec;
    Vector3 startPos;
    float startAngleY;
    PlayerLives lives;

    void Start () {
      
        playerManager = GameObject.Find("NetworkManager").GetComponent<PlayerManager>();
        playerManager.Connect(this);

        if (playerCount == 1)
        {
            upCode = KeyCode.W;
            downCode = KeyCode.S;
            moveVec = new Vector3(0, 0, 1);
            transform.position = new Vector3(-18.0f, -0.5f, 0.0f);
            transform.rotation = Quaternion.Euler(0,90,0);
            lives = GameObject.Find("Player1PointCollider").GetComponent<PlayerLives>();
        }
        if (playerCount == 2)
        {
            upCode = KeyCode.R;
            downCode = KeyCode.F;
            moveVec = new Vector3(0, 0, 1);
            transform.position = new Vector3(18.0f, -0.5f, 0.0f);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            rotDirection = -1;
            lives = GameObject.Find("Player2PointCollider").GetComponent<PlayerLives>();
        }
        if (playerCount == 3)
        {
            upCode = KeyCode.Y;
            downCode = KeyCode.H;
            moveVec = new Vector3(1, 0, 0);
            transform.position = new Vector3(0.0f, -0.5f, -18.0f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rotDirection = -1;
            lives = GameObject.Find("Player3PointCollider").GetComponent<PlayerLives>();
        }
        if (playerCount == 4)
        {
            upCode = KeyCode.I;
            downCode = KeyCode.K;
            moveVec = new Vector3(1, 0, 0);
            transform.position = new Vector3(0.0f, -0.5f, 18.0f);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            lives = GameObject.Find("Player4PointCollider").GetComponent<PlayerLives>();
        }
        trans = GetComponent<Transform>();
        startPos = trans.position;
        startAngleY = trans.rotation.eulerAngles.y;
    }
	
	// Update is called once per frame
	void Update () {

        if(hasAuthority)
        {
            if(lives.ActualLives() == 4)
                Destroy(gameObject);
        }
        if (!isLocalPlayer) return;        

        if (Input.GetKey(upCode))
        {
            trans.position = trans.position + moveVec * Time.deltaTime * speed;
            trans.rotation = Quaternion.Lerp(trans.rotation, Quaternion.Euler(new Vector3(0, startAngleY - rotDirection * 45, 0)), Time.deltaTime * 6);
        }
        else if (Input.GetKey(downCode))
        {
            trans.position = trans.position - moveVec * Time.deltaTime * speed;
            trans.rotation = Quaternion.Lerp(trans.rotation, Quaternion.Euler(new Vector3(0, startAngleY + rotDirection * 45, 0)), Time.deltaTime * 6);
        }
        else
        {
            trans.rotation = Quaternion.Lerp(trans.rotation, Quaternion.Euler(new Vector3(0, startAngleY, 0)), Time.deltaTime * 10);
        }

    }

    public void Connected(int num)
    {
        playerCount = num;
    }
}
