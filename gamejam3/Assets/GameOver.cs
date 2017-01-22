using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    // Use this for initialization
    public GM gm;
    void Start () {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GM>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        gm.setPhrase("High Score: " + gm.getHighScore());
	}
}
