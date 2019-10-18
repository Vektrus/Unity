using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    
            
           // GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
           // transform.position = new Vector3 (stratingX, startingY, startingZ);
            
        
    
}
