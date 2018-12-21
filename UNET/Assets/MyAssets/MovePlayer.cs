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
      
        playerManager = GameObject.Find("Manager").GetComponent<PlayerManager>();
        playerManager.Connect(this);
        upCode = KeyCode.W;
        downCode = KeyCode.S;
        if (playerCount == 1)
        {
            moveVec = new Vector3(0, 0, 1);
            transform.position = new Vector3(-18.0f, -0.5f, 0.0f);
            transform.rotation = Quaternion.Euler(0,90,0);
            lives = GameObject.Find("Player1PointCollider").GetComponent<PlayerLives>();
        }
        if (playerCount == 2)
        {
            moveVec = new Vector3(0, 0, 1);
            transform.position = new Vector3(18.0f, -0.5f, 0.0f);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            rotDirection = -1;
            lives = GameObject.Find("Player2PointCollider").GetComponent<PlayerLives>();
        }
        if (playerCount == 3)
        {
            moveVec = new Vector3(1, 0, 0);
            transform.position = new Vector3(0.0f, -0.5f, -18.0f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rotDirection = -1;
            lives = GameObject.Find("Player3PointCollider").GetComponent<PlayerLives>();
        }
        if (playerCount == 4)
        {
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
            if(lives.ActualLives() == 0)
                Destroy(gameObject);
        }
        if (!isLocalPlayer) return;        


        if (Input.GetKey(upCode) && CheckPosition())
        {
            trans.position = trans.position + moveVec * Time.deltaTime * speed;
            trans.rotation = Quaternion.Lerp(trans.rotation, Quaternion.Euler(new Vector3(0, startAngleY - rotDirection * 45, 0)), Time.deltaTime * 6);
        }
        else if (Input.GetKey(downCode) && CheckPosition())
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
    bool CheckPosition()
    {
        if(playerCount == 1 || playerCount == 2)
        {
            Vector3 pos = transform.position;
            if (pos.z <= 14 && pos.z >= -14)
                return true;
            else
            {
                if (pos.z > 14.0f) pos.z = 14.0f;
                if (pos.z < -14.0f) pos.z = -14.0f;
                transform.position = pos;
                return false;
            }
        }

        if (playerCount == 3 || playerCount == 4)
        {
            Vector3 pos = transform.position;
            if (pos.x <= 14 && pos.x >= -14)
                return true;
            else
            {
                if (pos.x > 14.0f) pos.x = 14.0f;
                if (pos.x < -14.0f) pos.x = -14.0f;

                transform.position = pos;
                return false;
            }
        }
        return true;
    }

}
