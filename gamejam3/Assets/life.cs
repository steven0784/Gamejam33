using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : MonoBehaviour {
    public Transform player;
    public Move Moves;
    public int number;
	// Use this for initialization
	void Start () {
        if (Moves == null)
        {
            Moves = player.GetComponent<Move>();
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (Moves.getLife()< number)
        {
            Destroy(gameObject);
        }
	}
}
