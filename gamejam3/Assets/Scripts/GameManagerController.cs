using UnityEngine;
using System.Collections;

public class GameManagerController : MonoBehaviour {

    public Transform text;
    public Transform text2;
    private CanvasGroup underText;
    public float nextTime = 0;
    float interval = 0.5f;
    public static int HighScore;
    public string phrase = "";

    // Use this for initialization
    void Start()
    {
        underText = text2.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(player.getScore());
        text.SendMessage("updateText", phrase);

    }
    public void gameOver(int highScore)
    {
        HighScore = highScore;
        Application.LoadLevel("GameOver");
    }
    public void setPhrase(string phrases)
    {
        phrase = phrases;
    }
}
