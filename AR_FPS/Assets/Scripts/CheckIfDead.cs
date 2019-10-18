using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CheckIfDead : MonoBehaviour
{
    public GameObject ReloadButton, AimButton, FireButton, Text;
    public RawImage bg;


    // Update is called once per frame
    void Update()
    {
        var player = Player.myPlayer;
        if (player.health == 0)
        {
            Dead();
        }
        /*if(player.WhoWin == Team.RED)
        {
            Text.SetActive(true);
            Text.GetComponent<TextMesh>().text = "RED WIN!";
        }
        else if (player.WhoWin == Team.BLUE)
        {
            Text.SetActive(true);
            Text.GetComponent<TextMesh>().text = "BLUE WIN!";
        }*/
    }

    void Dead()
    {
        ReloadButton.SetActive(false);
        AimButton.SetActive(false);
        FireButton.SetActive(false);
        bg.color = Color.red;
    }
}
