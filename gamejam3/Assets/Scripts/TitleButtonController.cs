using UnityEngine;
using System.Collections;

public class TitleButtonController : MonoBehaviour {

    public void StartGame()
    {
        Application.LoadLevel("firstscene");
    }
}
