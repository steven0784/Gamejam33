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
    public float direction = -1f;
    public bool colliding = false;
    public bool sloped = false;
    public float accerlation = 0.8f;
    public float negAcc = 0.1f;
    public float nextTime = 0;
    public float timeLeft = 1;
    public bool moveAgain = true;
    public Transform trail;
    int interval = 1;
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

    }

    // Update is called once per frame
    void Update()
    {
        int x = 1;
        //Debug.Log(Time.deltaTime);
        time = Time.deltaTime;
        float TotalSpeed = speed + score;
        if (!moveAgain)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                moveAgain = true;
                
            }
            else
            {
                TotalSpeed = 0f;
            }
        }
        m_Rigidbody2D.velocity = new Vector2(0, direction * (TotalSpeed)); //*accerlation);
        //if (Input.GetKeyDown("a") && collisioncount == 0)
        //{
        //    score = score - 1;
        //}
        Instantiate(trail, transform.position, Quaternion.identity);
        if (Time.time >= nextTime)
        {
            //do something here every interval seconds
            nextTime += interval;
            Debug.Log(negAcc);
            if((accerlation + negAcc) < 1 && (accerlation + negAcc) > 0.5)
            { 
                //if(sloped && negAcc < 0)
                //{
                //    x = 2;
                //}
                accerlation = accerlation + (negAcc * x);
                //x = 1;
            }

        }
        if (direction > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 20);
        }
        else if(direction < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -20);
        }
        if(!moveAgain)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    public int getScore ()
    {
        return score;
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        //Debug.Log(coll.gameObject.tag);
        if (coll.gameObject.tag == "ground")
        {
            if (moveAgain)
                moveAgain = false;
            direction = direction * -1f;
            negAcc = negAcc * -1;
            sloped = false;
        }
        if (!gotPoint && score != 0)
        {
            score = score - 1;
            gotPoint = true;
        }
        collisioncount++;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Slope")
        {

            time = 0.1f;
            sloped = true;
            if (Input.GetKeyDown("a") && !gotPoint)
            {
                score = score + 1;
                gotPoint = true;
            }
        }
        if (other.gameObject.tag == "reset")
        {
            gotPoint = false;
            negAcc = negAcc * -1;
            timeLeft = 1;


        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        collisioncount--;
    }
}
