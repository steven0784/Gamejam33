﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill : MonoBehaviour {
    private float speed = 5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-Vector3.right * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Collider>().gameObject.layer == 10)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                Destroy(gameObject);

        }
    }
    
}
