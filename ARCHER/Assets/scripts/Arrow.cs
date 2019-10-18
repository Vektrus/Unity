using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float Arrowspeed;
    public Rigidbody2D rb;
    private int tik;
    private float[] pozycja1=new float[2], pozycja2 = new float[2];

    // Start is called before the first frame update
    void Start()
    {
        tik = 0;
        rb.velocity = transform.right * Arrowspeed;
        
    }

    void OnTriggerEnter2D()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        if(tik == 0)
        {
            pozycja1[1] = transform.position.x;
            pozycja1[2] = transform.position.y;
            tik++;
        }
        else if (tik == 1)
        {
            pozycja2[1]= transform.position.x;
            pozycja2[2] = transform.position.y;
            transform.Rotate(0f, 0f, 10f);
            pozycja1[1] = pozycja2[1];
            pozycja1[2] = pozycja2[2];
        }
    }
    
}
