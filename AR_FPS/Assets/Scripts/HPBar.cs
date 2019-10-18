using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPBar : MonoBehaviour
{
    public int LastHealthNumber;
    public RawImage bg;
    
    void Start()
    {
        var myplayer = Player.myPlayer;
        LastHealthNumber = myplayer.health;
    }

    
    // Update is called once per frame
    void Update()
    {
        bg.color = Color.white;
        var myplayer = Player.myPlayer;
        gameObject.GetComponent<TextMesh>().text = myplayer.health.ToString();
        if(LastHealthNumber > myplayer.health)
        {
            Hit();
        }
        LastHealthNumber = myplayer.health;
    }

    void Hit()
    {
        bg.color = Color.red;
    }
}
