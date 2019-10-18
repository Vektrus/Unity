using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instant;

    // Start is called before the first frame update
    void Start()
    {
        instant = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.players.Count > 1)
        {
            GetComponent<TransferManager>().Winn();
        }
        
    }

    public void OnShootToRPC(int i)
    {
        GetComponent<TransferManager>().OnShoot(i);
    }

    public void ONHColorTaked(float h)
    {
        var player = Player.myPlayer;
        GetComponent<TransferManager>().OnHTaked(player.pp, h);
    }
    

    /* public void ColorIsTaked(float h, string nick)
     {
         if (PhotonNetwork.isMasterClient)
         {
             //photonView.RPC("AddHForPlayer", PhotonTargets.AllBuffered,h,nick );
         }
     }


     [PunRPC]
     void AddHForPlayer(float h, string nick)
     {
         var player = Player.FindPlayerByNick(nick);
         player.H = h;
         player.health = 100;
     }*/
}
