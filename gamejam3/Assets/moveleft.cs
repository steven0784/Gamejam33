using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveleft : MonoBehaviour {
    private SpriteRenderer renderer;
    float interval = 0.5f;
    public float nextTime = 0;
    public int counter = 0;
    // Use this for initialization
    void Start () {
        renderer = transform.GetComponent<SpriteRenderer>();
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
