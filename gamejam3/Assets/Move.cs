using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed = 10f;
    private Rigidbody2D m_Rigidbody2D;  // For determining which way the player is currently facing.
    private float time;
    public int score = 0;
    public bool gotPoint = true;
    public float nextTime = 0;
	public float upperBound;
	public float lowerBound;
    public Transform trail;
    float interval = 0.5f;
    public int nextGoal = 5;
    public Transform center;
	public Sprite normal, up, down;
    private Vector3 lastPos;
    private int spriteSwitchTime = 3;
    public int counter1 = 0;
    public Color color;
    public int playerColor = 0;
    public int lineColor = 1;
    public float changeTime = 5;
    public int highScore = 0;
    public AudioSource a;
    public GM gm;
    public AudioSource b;
    public AudioSource c;
    public AudioSource d;
    public AudioSource e;
    public AudioSource f;

    private void Awake()
    {
        // Setting up reference
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GM>();
        }
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        time = Time.time;
        lastPos = transform.position;


    }
    // Use this for initialization
    void Start()
    {
        transform.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(Time.deltaTime)
        //m_Rigidbody2D.velocity = new Vector2(0, direction * (TotalSpeed)); //*accerlation);
        //if (Input.GetKeyDown("a") && collisioncount == 0)
        //{
        //    score = score - 1;
        //}
        //Debug.Log(gravity.y);
		MakeTrail();
        FindPos();
        if (spriteSwitchTime == 3)
        {
            lastPos = transform.position;
        }
        spriteSwitchTime--;
        //transform.GetComponent<SpriteRenderer>().color = new Color(1f, 0.92f, 0.016f, 1f);
        if (Time.time >= nextTime)
        {
            //do something here every interval seconds
            counter1++;
            nextTime =Time.time + interval;
            Debug.Log(counter1);
            if (counter1 > changeTime)
            {
                int g = 0;
                while (true)
                {
                    g = Random.Range(0, 4);
                    if(lineColor != g)
                    {
                        break;
                    }
                }
                playerColor = g;

                Debug.Log(playerColor);
                
                if (playerColor == 0)
                {
                    transform.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1f, 1f);
                    b.Play();
                }
                else if (playerColor == 1)
                {
                    transform.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 1f);
                    c.Play();
                }
                else if (playerColor == 2)
                {
                    transform.GetComponent<SpriteRenderer>().color = new Color(1f, 0.92f, 0.016f, 1f);
                    d.Play();
                }
                else if (playerColor == 3)
                {
                    transform.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);
                    e.Play();
                }
                if(!gotPoint)
                {
                    score--;
                }
                counter1 = 0;
                gotPoint = false;
            }


        }
        //Debug.Log(average / counter);
        if (!gotPoint)
        {
            if (Input.GetKeyDown("q"))
            {
                lineColor = 0;
                checkScore();
                b.Play();
            }
            if (Input.GetKeyDown("w"))
            {
                lineColor = 1;
                checkScore();
                c.Play();
            }
            if (Input.GetKeyDown("e"))
            {
                lineColor = 2;
                checkScore();
                d.Play();
            }
            if (Input.GetKeyDown("r"))
            {
                lineColor = 3;
                checkScore();
                e.Play();
            }
        }
        if (lineColor == 0)
        {
            color = new Color(0f, 0f, 1f, 1f);
        }
        else if (lineColor == 1)
        {
            color = new Color(0f, 1f, 0f, 1f);
        }
        else if (lineColor == 2)
        {
            color = new Color(1f, 0.92f, 0.016f, 1f);
        }
        else if (lineColor == 3)
        {
            color = new Color(1f, 0f, 0f, 1f);
        }
        //Debug.Log(gotPoint);

        //if (Input.GetKeyDown("a"))
        //{
        //    current = Mathf.Abs(Mathf.Abs(m_Rigidbody2D.velocity.y) - Mathf.Abs(lastY));
        //    lastY = m_Rigidbody2D.velocity.y;
        //    average = average + current;
        //    counter++;
        //    if (!gotPoint && current < (average / counter))
        //    {
        //        score = score + 1;
        //        a.Play();
        //        gotPoint = true;
        //    }
        //}

        if (transform.position.y > center.transform.position.y && m_Rigidbody2D.gravityScale < 0)
        {
            m_Rigidbody2D.gravityScale = m_Rigidbody2D.gravityScale * -1f;
            //gotPoint = false;
        }
        else if (transform.position.y < center.transform.position.y && m_Rigidbody2D.gravityScale > 0)
        {
            m_Rigidbody2D.gravityScale = m_Rigidbody2D.gravityScale * -1f;
			//gotPoint = false;
        }
        Vector3 thisPos = transform.position;
        if (score >= nextGoal && Mathf.Abs(thisPos.y - lastPos.y) < 0.05)
        {
            float q = 0;
            while (true)
            {
                if (m_Rigidbody2D.gravityScale > 0)
                {
                    q = Random.Range(lowerBound, upperBound);
                }
                else if (m_Rigidbody2D.gravityScale < 0)
                {
                    q = Random.Range(-lowerBound, -upperBound);
                }
                if (q != m_Rigidbody2D.gravityScale)
                {
                    m_Rigidbody2D.gravityScale = q;
                    break;
                }
            }

            Debug.Log(m_Rigidbody2D.gravityScale);
            nextGoal = score + 5;
            
            if(changeTime-1 <= 0)
            {
                changeTime = changeTime - 0.1f;
                if(changeTime - 0.1f <=0)
                {
                    changeTime = 0.1f; 
                }
            }
            else
            {
                changeTime--;
            }
        }
        gm.setPhrase("Score :" + getScore().ToString());
        if(score<-5)
        {
            gm.gameOver(getHighScore());
        }
	}
    public int getScore ()
    {
        return score;
    }

    void FindPos()
    {
        Vector3 thisPos = transform.position;
        if (spriteSwitchTime <= 0)
        {
            if (thisPos.y > lastPos.y && (Mathf.Abs(thisPos.y - lastPos.y) > 0.05))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = up;
            }
            else if (thisPos.y < lastPos.y && (Mathf.Abs(thisPos.y - lastPos.y) > 0.05))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = down;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = normal;
            }
            spriteSwitchTime = 3;
        }
    }


    

    void MakeTrail(){
		Vector3 myPos = transform.position;
		Vector3 tail = new Vector3 (transform.position.x - 2, transform.position.y - 1, transform.position.z);
        Transform s = Instantiate(trail, tail, Quaternion.identity);
        s.GetComponent<SpriteRenderer>().color = color;
    }
    public int getHighScore()
    {
        return highScore;
    }
    void checkScore()
    {
        if (lineColor == playerColor && !gotPoint)
        {
            score = score + 1;
            if (score > highScore)
                highScore = score;
            //a.Play();
            
        }
        else if(lineColor != playerColor && !gotPoint)
        {
            score--;
            f.Play();
        }
        gotPoint = true;
    }

}
