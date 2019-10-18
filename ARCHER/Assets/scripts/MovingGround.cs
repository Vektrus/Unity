using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    
    public Transform Target;
    public float x, y, speed_of_change, acceleration;
    public LayerMask WhatActivet;
    public float targetCheckRadious;
    private bool activet, moving_x, moving_y, g;
    private string Direction_of_change_x, Direction_of_change_y;
    private float k,w;
    


    void Start()
    {
        w = 3.5f;
        k = 1;
        moving_y = false;
        moving_x = false;
        if (Mathf.Round(transform.position.x) > x)
        {
            moving_x = true;
            Direction_of_change_x = "Left";
        }
        else if (Mathf.Round(transform.position.x) < x)
        {
            moving_x = true;
            Direction_of_change_x = "Right";
        }
        if (Mathf.Round((transform.position.y + w)) > y)
        {
            moving_y = true;
            Direction_of_change_y = "Down";
        }
        else if (Mathf.Round((transform.position.y + w)) < y)
        {
            moving_y = true;
            Direction_of_change_y = "Up";
        }
        
        
    }

    void FixedUpdate()
    {
       
        
        
        activet = Physics2D.OverlapCircle(Target.position, targetCheckRadious, WhatActivet);
        if (activet)
        {
            g = true;
        }
        

    }
    // Update is called once per frame
    void Update()
    {
        if (g)
        {

            if (moving_x)
            {
                if (transform.position.x + speed_of_change * k > x && Direction_of_change_x == "Right")
                {
                    transform.Translate(x - transform.position.x + 0.5f, 0f, 0f);
                    moving_x = false;
                }
                else if (transform.position.x + speed_of_change * -k < x && Direction_of_change_x == "Left")
                {
                    transform.Translate(x - transform.position.x + 0.5f, 0f, 0f);
                    moving_x = false;
                }
                else if (Direction_of_change_x == "Left")
                {
                    transform.Translate(speed_of_change * -k, 0f, 0f);
                }
                else if (Direction_of_change_x == "Right")
                {
                    transform.Translate(speed_of_change * k, 0f, 0f);
                }
            }
            if (moving_y)
            {
                if (transform.position.y+w + speed_of_change * k > y && Direction_of_change_y == "Up")
                {
                    transform.Translate(0f, y - (transform.position.y+w), 0f);
                    moving_y = false;
                }
                else if (transform.position.y+w + speed_of_change * -k < y && Direction_of_change_y == "Down")
                {
                    transform.Translate(0f, y - (transform.position.y+w), 0f);
                    moving_y = false;
                }
                else if (Direction_of_change_y == "Down")
                {
                    transform.Translate( 0f, speed_of_change * -k, 0f);
                }
                else if (Direction_of_change_y == "Up")
                {
                    transform.Translate(0f, speed_of_change * k, 0f);
                }
            }
        }
        k = k + acceleration;
    }
}





/* if (g)
        {
            
            if (moving_x)
            {
                if(transform.position.x + speed_of_change * k > x && Direction_of_change_x == "Right" )
                {
                    transform.Translate(x- transform.position.x, 0, 0);
                    moving_x = false;
                }
                else if(transform.position.x + speed_of_change * -k < x && Direction_of_change_x == "Left")
                {
                    transform.Translate(x + transform.position.x, 0, 0);
                    moving_x = false;
                }
                else if(Direction_of_change_x == "Left")
                {
                    transform.Translate(speed_of_change * -k, 0, 0); 
                }
                else if (Direction_of_change_x == "Right")
                {
                    transform.Translate(speed_of_change * k, 0, 0);
                }

            }
            if (moving_y)
            {
                if(transform.position.y + speed_of_change * k < y && Direction_of_change_y == "Up")  
                {
                    transform.Translate(0, y- transform.position.y, 0);
                    
                    moving_y = false;
                }
                else if(transform.position.y + speed_of_change * -k > y && Direction_of_change_y == "Down")
                {
                    transform.Translate(0, y + transform.position.y, 0);

                    moving_y = false;
                }
                else
                {
                    transform.Translate(0, speed_of_change * k, 0); 
                }
            }
            
            k = k + acceleration;
        }*/
