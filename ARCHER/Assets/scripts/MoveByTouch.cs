using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    public float moveSpeed;
    public float distanceToJump;
    public float jumpHight;
    private float distance;
    private bool movetor, movetol, FacingRight;
    public Transform cornerCheckLeft, cornerCheckRight;
    public float cornerCheckradius;
    public LayerMask WhatIsCorner;
    private bool isItLeftCorner, isItRightCorner;
    public Transform GroundCheckLeft, GroundCheckRight;
    public LayerMask WhatIsGround;
    public float GroundCheckRadious;
    private bool Grounded, Jumped;

    void Start()
    {
        movetol = false;
        movetor = false;
        FacingRight = true;
        Jumped = false;
    }

    void FixedUpdate()
    {
        if((Physics2D.OverlapCircle(GroundCheckLeft.position, GroundCheckRadious, WhatIsGround)) || (Physics2D.OverlapCircle(GroundCheckRight.position, GroundCheckRadious, WhatIsGround))){
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }
        
        isItLeftCorner = Physics2D.OverlapCircle(cornerCheckLeft.position, cornerCheckradius, WhatIsCorner);
        isItRightCorner = Physics2D.OverlapCircle(cornerCheckRight.position, cornerCheckradius, WhatIsCorner);
        if (cornerCheckLeft.position.x < cornerCheckRight.position.x)
        {
            FacingRight = true;
        }
        else
        {
            FacingRight = false;
        }
        if (Input.touchCount == 0)
        {
            Jumped = false;
        }

    }

    void move(float x, float y)
    {
        if (Grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);
        }
        
    }
    void Flip()
    {
        
        transform.Rotate(0f, 180f, 0f);
    }
    void distanceCheck()
    {

        distance = transform.position.x;
    }
    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Rigidbody2D>().velocity.x == 0)
        {
            distanceCheck();
            
        }
        if(isItRightCorner == false && isItLeftCorner == true && (distanceToJump < Mathf.Abs(distance - transform.position.x) || Jumped)) ///SKAKANIE
        {
            move(GetComponent<Rigidbody2D>().velocity.x, jumpHight);
            Jumped = true;

        }
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if( touchPosition.x < -4 && touchPosition.x < 0)
            {
                if (movetol == false)
                {
                    distanceCheck();
                }
                movetol = true;
                movetor = false;
                if(FacingRight== true)
                {
                    Flip();
                }
                move(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            else if (touchPosition.x > -4 && touchPosition.x < 0)
            {
                if (movetor == false)
                {
                    distanceCheck();
                }
                movetol = false;
                movetor = true;
                if (FacingRight == false)
                {
                    Flip();
                }
                move(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
        }





    }
}
