﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscMovement : MonoBehaviour {

    Rigidbody rigid;
    public float speed = 5;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = transform.right * speed;
        //rigid.AddForce(transform.right*50);
	}
	
	// Update is called once per frame
	void Update () {
        //transform.position += transform.right * Time.deltaTime;
	}
}
