using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTrees : MonoBehaviour {
    public Sprite tree1, tree2, tree3;
    // Use this for initialization
    void Start () {
        int x = Random.Range(0, 4);
        if (x == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = tree1;
        }
        else if(x == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = tree2;
        }
        else if (x == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = tree3;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
