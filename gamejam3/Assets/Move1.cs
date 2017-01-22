using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1 : MonoBehaviour
{
    private float speed = 10f;
    private Rigidbody2D m_Rigidbody2D;  // For determining which way the player is currently facing.
    private float time;
    private float realTime;
    public int score = 0;
    public bool gotPoint = true;
    public int collisioncount = 0;
    public float direction = 1f;
    public bool colliding = false;
    public bool sloped = false;
    public float accerlation = 0.8f;
    public float negAcc = 0.1f;
    public float nextTime = 0;
    public float timeLeft = 1;
    public float upperBound;
    public float lowerBound;
    public bool moveAgain = true;
    public Transform trail;
    float interval = 0.5f;
    Vector3 gravity;
    public float lastY;
    public float current;
    public float average;
    public int counter = 0;
    public bool collided = false;
    public int nextGoal = 5;
    public Transform center;
    public Sprite normal, up, down;
    private Vector3 lastPos;
    private int spriteSwitchTime = 3;
    public int counter1 = 0;
    public Color color;
    public int playerColor = 0;
    public int lineColor = 1;
    private AudioSource a;
    public GM gm;

    private void Awake()
    {
        // Setting up references
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GM>();
        }
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        time = Time.time;
        realTime = time;
        lastPos = transform.position;


    }
    // Use this for initialization
    void Start()
    {
        a = GetComponent<AudioSource>();
        gravity = Physics.gravity;
        color = new Color(0f, 0f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

        int x = 1;
        gm.setHighScore(0);
        Physics.gravity = gravity;
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
            nextTime += interval;
            current = Mathf.Abs(Mathf.Abs(m_Rigidbody2D.velocity.y) - Mathf.Abs(lastY));
            lastY = m_Rigidbody2D.velocity.y;
            average = average + current;
            counter++;
            if (counter > 1)
            {

                if(counter1 > 3)
                {
                    counter1 = 0;
                }
                if (counter1 == 0)
                {
                    color = new Color(0f, 0f, 1f, 1f);
                }
                else if (counter1 == 1)
                {
                    color = new Color(0f, 1f, 0f, 1f);
                }
                else if (counter1 == 2)
                {
                    color = new Color(1f, 0.92f, 0.016f, 1f);
                }
                else if (counter1 == 3)
                {
                    color = new Color(1f, 0f, 0f, 1f);
                }
                counter1++;
                counter = 0;
                gotPoint = false;
            }


        }
        if (Time.time >= nextTime)
        {
            //do something here every interval seconds
            nextTime += interval;
            current = Mathf.Abs(Mathf.Abs(m_Rigidbody2D.velocity.y) - Mathf.Abs(lastY));
            lastY = m_Rigidbody2D.velocity.y;
            average = average + current;
            counter++;


        }
        //Debug.Log(average / counter);
        

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
        if (score >= nextGoal && current < (average / counter))
        {

            if (m_Rigidbody2D.gravityScale > 0)
            {
                m_Rigidbody2D.gravityScale = Random.Range(lowerBound, upperBound);
            }
            else if (m_Rigidbody2D.gravityScale < 0)
            {
                m_Rigidbody2D.gravityScale = Random.Range(-lowerBound, -upperBound);
            }

            counter = 0;
            average = 0;
            nextGoal = score + 5;
        }
    }
    public int getScore()
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




    void MakeTrail()
    {
        Vector3 myPos = transform.position;
        Vector3 tail = new Vector3(transform.position.x - 2, transform.position.y - 1, transform.position.z);
        Transform s = Instantiate(trail, tail, Quaternion.identity);
        s.GetComponent<SpriteRenderer>().color = color;
    }

}
