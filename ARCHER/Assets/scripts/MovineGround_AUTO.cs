using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovineGround_AUTO : MonoBehaviour
{
    public float StartingX, StartingY, TargetX, TargetY, speed_of_change, acceleration;
    private string Direction_of_change_x, Direction_of_change_y;
    private bool moving_x, moving_y, MoveFirst;
    private float k, w;

    // Start is called before the first frame update
    void Start()
    {
        MoveFirst = true;
        w = 3.5f;
        k = 1;
        moving_y = false;
        moving_x = false;
        if (Mathf.Round(transform.position.x) > TargetX)
        {
            moving_x = true;
            Direction_of_change_x = "Left";
        }
        else if (Mathf.Round(transform.position.x) < TargetX)
        {
            moving_x = true;
            Direction_of_change_x = "Right";
        }
        if (Mathf.Round((transform.position.y + w)) > TargetY)
        {
            moving_y = true;
            Direction_of_change_y = "Down";
        }
        else if (Mathf.Round((transform.position.y + w)) < TargetY)
        {
            moving_y = true;
            Direction_of_change_y = "Up";
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (MoveFirst)
        {
            if (moving_x)
            {
                if (transform.position.x + speed_of_change * k > TargetX && Direction_of_change_x == "Right")
                {
                    transform.Translate(TargetX - transform.position.x + 0.5f, 0f, 0f);
                    moving_x = false;
                    MoveFirst = false;
                }
                else if (transform.position.x + speed_of_change * -k < TargetX && Direction_of_change_x == "Left")
                {
                    transform.Translate(TargetX - transform.position.x + 0.5f, 0f, 0f);
                    moving_x = false;
                    MoveFirst = false;
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
                if (transform.position.y + w + speed_of_change * k > TargetY && Direction_of_change_y == "Up")
                {
                    transform.Translate(0f, TargetY - (transform.position.y + w), 0f);
                    moving_y = false;
                    MoveFirst = false;
                }
                else if (transform.position.y + w + speed_of_change * -k < TargetY && Direction_of_change_y == "Down")
                {
                    transform.Translate(0f, TargetY - (transform.position.y + w), 0f);
                    moving_y = false;
                    MoveFirst = false;
                }
                else if (Direction_of_change_y == "Down")
                {
                    transform.Translate(0f, speed_of_change * -k, 0f);
                }
                else if (Direction_of_change_y == "Up")
                {
                    transform.Translate(0f, speed_of_change * k, 0f);
                }
            }
            k = k + acceleration;
        }
        if (!MoveFirst)
        {

            if (!moving_x)
            {
                if (transform.position.x + speed_of_change * k > StartingX && Direction_of_change_x == "Left")
                {
                    transform.Translate(StartingX - transform.position.x + 0.5f, 0f, 0f);
                    moving_x = true;
                    MoveFirst = true;
                }
                else if (transform.position.x + speed_of_change * -k < StartingX && Direction_of_change_x == "Right")
                {
                    transform.Translate(StartingX - transform.position.x + 0.5f, 0f, 0f);
                    moving_x = true;
                    MoveFirst = true;
                }
                else if (Direction_of_change_x == "Right")
                {
                    transform.Translate(speed_of_change * -k, 0f, 0f);
                }
                else if (Direction_of_change_x == "Left")
                {
                    transform.Translate(speed_of_change * k, 0f, 0f);
                }
            }
            if (!moving_y)
            {
                if (transform.position.y + w + speed_of_change * k > StartingY && Direction_of_change_y == "Down")
                {
                    transform.Translate(0f, StartingY - (transform.position.y + w), 0f);
                    moving_y = true;
                    MoveFirst = true;
                }
                else if (transform.position.y + w + speed_of_change * -k < StartingY && Direction_of_change_y == "Up")
                {
                    transform.Translate(0f, StartingY - (transform.position.y + w), 0f);
                    moving_y = true;
                    MoveFirst = true;
                }
                else if (Direction_of_change_y == "Up")
                {
                    transform.Translate(0f, speed_of_change * -k, 0f);
                }
                else if (Direction_of_change_y == "Down")
                {
                    transform.Translate(0f, speed_of_change * k, 0f);
                }
            }
            k = k + acceleration;
        }

    }
}
       

