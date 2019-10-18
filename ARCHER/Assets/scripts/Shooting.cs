using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject Arrow;
    private bool FacingRight;
    private Vector3 touchMovedPosition, touchBeganPosition, touchEndedPosition;
    public Transform cornerCheckLeft, cornerCheckRight;
    void Start()
    {
        FacingRight = true;
    }
    void FixedUpdate()
    {

        if (cornerCheckLeft.position.x < cornerCheckRight.position.x)
        {
            FacingRight = true;
        }
        else
        {
            FacingRight = false;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if(touchPosition.x > 0)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        touchBeganPosition = Camera.main.ScreenToWorldPoint(touch.position);
                        break;
                    case TouchPhase.Moved:
                        touchMovedPosition = Camera.main.ScreenToWorldPoint(touch.position);

                        if(touchBeganPosition.x > touchMovedPosition.x && !FacingRight)
                        {
                            Flip();
                        }
                        else if (touchBeganPosition.x < touchMovedPosition.x && FacingRight)
                        {
                            Flip();
                        }

                        break;
                    case TouchPhase.Ended:
                        touchEndedPosition = Camera.main.ScreenToWorldPoint(touch.position);
                        if (FacingRight)
                        {
                            FirePoint.transform.Rotate(0f, 0f, Mathf.Atan2(touchBeganPosition.y - touchEndedPosition.y, touchBeganPosition.x - touchEndedPosition.x) * Mathf.Rad2Deg);
                            Shoot();
                            FirePoint.transform.Rotate(0f, 0f, -Mathf.Atan2(touchBeganPosition.y - touchEndedPosition.y, touchBeganPosition.x - touchEndedPosition.x) * Mathf.Rad2Deg);
                        }
                        else
                        {
                            FirePoint.transform.Rotate(0f, 0f, -Mathf.Atan2( touchEndedPosition.y -touchBeganPosition.y, touchEndedPosition.x - touchBeganPosition.x) * Mathf.Rad2Deg);
                            Shoot();
                            FirePoint.transform.Rotate(0f, 0f, Mathf.Atan2(touchEndedPosition.y - touchBeganPosition.y, touchEndedPosition.x - touchBeganPosition.x) * Mathf.Rad2Deg);
                        }

                        break;
                }
            }
        }

    }

    void Shoot()
    {
       

            Instantiate(Arrow, FirePoint.position, FirePoint.rotation);
        
    }

    void Flip()
    {
        
        transform.Rotate(0f, 180f, 0f);
    }
}
