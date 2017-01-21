using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {
    public Transform text;
    public static Move player;
    // Use this for initialization
    void Start () {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Move>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(player.getScore());
        text.SendMessage("updateText","score: " +player.getScore().ToString() );
    }
}
