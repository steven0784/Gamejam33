using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveleft : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-Time.deltaTime*5, 0, 0);
        if(transform.position.x < -30)
        {
            Destroy(gameObject);
        }
    }
}
