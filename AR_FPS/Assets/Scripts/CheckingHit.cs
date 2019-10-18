using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CheckingHit : MonoBehaviour
{
    public GameObject Kamera;
    public float h;
    //public float hh;
    private Color pixell;
    //public AudioSource hitMarker;
    public GameObject colorr;
    //public float AccuracyOfCheckingHit;
    public RawImage HitMarker;
   // public GameObject FireButton;
    public bool Fire;
    

    void Start()
    {
        
        
    }
    
    
    
    void Update()
    {
        
        //hh = colorr.GetComponent<color>().h;
        //hh = hh * 360;
        h = Kamera.GetComponent<PhoneCamera>().H;
        pixell = Color.HSVToRGB(h, 1, 1);
        h = h * 360;
        HitMarker.enabled = false;
        if (Fire)
        {
            var player = Player.myPlayer;
            if(Player.CheckHit(h, player.team))
                Hit();
            
        }
        



        
        GetComponent<Image>().color = pixell;
        //CheckHit();
        


    }

    /*public void CheckHit()
    {
        if (Fire)
        {
            if(hh == h)
            {
                Hit();
            }
            else if (hh - AccuracyOfCheckingHit < 0 && (h - 360) > hh - AccuracyOfCheckingHit)
            {


                Hit();

            }
            else if (hh + AccuracyOfCheckingHit > 360 && (h + 360) < hh + AccuracyOfCheckingHit)
            {

                Hit();

            }
            else
            {
                if (hh - AccuracyOfCheckingHit < h && h < hh + AccuracyOfCheckingHit)
                {
                    Hit();
                }
            }
        }*/

       /* if (Fire)
        {

            if (hh - AccuracyOfCheckingHit < 0 && (h - 360) > hh - AccuracyOfCheckingHit)
            {


                Hit();

            }
            else if (hh + AccuracyOfCheckingHit > 360 && (h + 360) < hh + AccuracyOfCheckingHit)
            {

                Hit();

            }
            else
            {
                if (hh - AccuracyOfCheckingHit < h && h < hh + AccuracyOfCheckingHit)
                {
                    Hit();
                }
            }
        }*/
   // }

    void Hit()
    {
        //hitMarker.Play();
        HitMarker.enabled = true;
        Fire = false;

    }
    
}
