using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeZ : MonoBehaviour {
    private float direction =1f;
    private float x = 45;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (direction > 0)
        {
            x = x + 0.1f;
        }
        else if (direction < 0)
        {
            x -= 0.1f;
        }
        if(x > 60 || x < 30)
        {
            direction = direction * -1f;
        }

        transform.rotation = Quaternion.Euler(0,0, x);
    }
}
