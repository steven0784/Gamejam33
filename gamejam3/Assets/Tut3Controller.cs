using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tut3Controller : MonoBehaviour {

    public Sprite normal,droid;

    // Update is called once per frame
    void Awake () {
        if (Application.platform != RuntimePlatform.Android) {
            gameObject.GetComponent<SpriteRenderer>().sprite = normal;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = droid;
        }

    }
}
