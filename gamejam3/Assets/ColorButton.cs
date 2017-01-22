using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorButton : MonoBehaviour {
    public Transform player;
    public Move a;
    public int color;
    // Use this for initialization
    void Start () {
        Debug.Log("here");
        a = player.GetComponent<Move>();
        if (Application.platform != RuntimePlatform.Android)
            Destroy(gameObject);
    }

    // Update is called once per frame
    public void change()
    {


            Debug.Log("here");
            a.setLineColor(color);

    }
}
