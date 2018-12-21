using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DiscMovement : NetworkBehaviour
{

    Rigidbody rigid;
    public float speed = 7;
    bool wait = false;
    float disableTimer = 0.0f;
    // Use this for initialization
    Collider playerCollider;
    SphereCollider discCollider;
    public PlayerManager manager;
    bool start = false;

    [SyncVar(hook = "SyncVelocityChanged")]
    public Vector3 velocity = Vector3.zero;

    void Start () {
        rigid = GetComponent<Rigidbody>();
        discCollider = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {

        if(manager.playerCount == 4 && !start)
        {
            rigid.velocity = transform.right * speed;
            start = true;
        }
        if(hasAuthority)
        {
            SyncVelocityChanged(rigid.velocity);
        }

        if (wait)
        {
            disableTimer += Time.deltaTime;
            Physics.IgnoreCollision(discCollider, playerCollider, true);
            if (disableTimer >= 0.2f)
            {
                Physics.IgnoreCollision(discCollider, playerCollider, false);
                wait = false;
                disableTimer = 0.0f;
            }
        }

        if(!hasAuthority)
        {
            transform.position = transform.position + velocity * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerCollider = collision.collider;
            wait = true;
            rigid.velocity = rigid.velocity * 1.1f;
        }
        else if(collision.gameObject.tag == "pointCollider")
        {
            transform.position = new Vector3(0, -0.9f, 0);
            rigid.velocity = transform.right * speed;
        }
    }
    void SyncVelocityChanged(Vector3 vel) { velocity = vel; }
}
