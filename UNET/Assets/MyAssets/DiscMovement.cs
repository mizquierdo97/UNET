using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DiscMovement : NetworkBehaviour
{

    Rigidbody rigid;
    public float speed = 5;
    bool wait = false;
    float disableTimer = 0.0f;
    // Use this for initialization
    Collider playerCollider;
    SphereCollider discCollider;

    [SyncVar(hook = "SyncVelocityChanged")]
    public Vector3 velocity = Vector3.zero;

    void Start () {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.right * speed;
        //rigid.AddForce(transform.right*50);
        discCollider = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {

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
        }           
    }
    void SyncVelocityChanged(Vector3 vel) { velocity = vel; }
}
