using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed = 10f;
    private Rigidbody2D m_Rigidbody2D;  // For determining which way the player is currently facing.
    private float time;
    private float realTime;
    public int score = 0;
    public bool gotPoint = false;
    public int collisioncount = 0;
    public float direction = 1f;
    public bool colliding = false;
    public bool sloped = false;
    public float accerlation = 0.8f;
    public float negAcc = 0.1f;
    public float nextTime = 0;
    public float timeLeft = 1;
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
    public int counter1 = 0;
    public Color color;
    private void Awake()
    {
        // Setting up references
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        time = Time.time;
        realTime = time;


    }
    // Use this for initialization
    void Start()
    {
        gravity = Physics.gravity;
    }

    // Update is called once per frame
    void Update()
    {

        int x = 1;
        Physics.gravity = gravity;
        //Debug.Log(Time.deltaTime)
        //m_Rigidbody2D.velocity = new Vector2(0, direction * (TotalSpeed)); //*accerlation);
        //if (Input.GetKeyDown("a") && collisioncount == 0)
        //{
        //    score = score - 1;
        //}
        //Debug.Log(gravity.y);
        Transform s = Instantiate(trail, transform.position, Quaternion.identity);
        s.GetComponent<SpriteRenderer>().color = color;
        if (Time.time >= nextTime)
        {
            //do something here every interval seconds
            nextTime += interval;
            current = Mathf.Abs(Mathf.Abs(m_Rigidbody2D.velocity.y) - Mathf.Abs(lastY));
            lastY = m_Rigidbody2D.velocity.y;
            average = average + current;
            counter++;
            if (counter1 > 3)
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


        }
        Debug.Log(average / counter);
        if (Input.GetKeyDown("a"))
        {
            current = Mathf.Abs(Mathf.Abs(m_Rigidbody2D.velocity.y) - Mathf.Abs(lastY));
            lastY = m_Rigidbody2D.velocity.y;
            average = average + current;
            counter++;
            if (!gotPoint && current < (average / counter))
            {
                score = score + 1;
                gotPoint = true;
            }
        }
        if (transform.position.y > center.transform.position.y && m_Rigidbody2D.gravityScale < 0)
        {
            m_Rigidbody2D.gravityScale = m_Rigidbody2D.gravityScale * -1f;
            gotPoint = false;
        }
        else if (transform.position.y < center.transform.position.y && m_Rigidbody2D.gravityScale > 0)
        {
            m_Rigidbody2D.gravityScale = m_Rigidbody2D.gravityScale * -1f;
            gotPoint = false;
        }
        if (score >= nextGoal && current < (average / counter))
        {
            if (m_Rigidbody2D.gravityScale > 0)
            {
                m_Rigidbody2D.gravityScale = Random.Range(1, 3);
            }
            else if (m_Rigidbody2D.gravityScale < 0)
            {
                m_Rigidbody2D.gravityScale = Random.Range(-1, -3);
            }

            counter = 0;
            average = 0;
            nextGoal = score + 5;
        }
    }
    public int getScore ()
    {
        return score;
    }
    
    


}
