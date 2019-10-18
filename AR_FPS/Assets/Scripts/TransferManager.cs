using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Skrypt odpowiadający za łączenie się z sewerem(oraz rozłączanie się i utraatę połączeń)
/// </summary>
public class TransferManager : Photon.MonoBehaviour
{

    NextLevel nexlvl;
    public InputField IfNick;
    public int RedAlive, BlueAlive, RedPlayer, BluePlayer;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        nexlvl = GetComponent<NextLevel>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Player.DebugListOfPlayers();
        }

    }



    public void Connect()
    {
        if (IfNick.text.Length >= 4)
        {
            PhotonNetwork.playerName = IfNick.text;
            //Nick.ourNick = IfNick.text;
            PhotonNetwork.ConnectUsingSettings("AR_FPS_0.4");
        }


    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 300, 20), PhotonNetwork.connectionStateDetailed.ToString());
    }

    void OnJoinedLobby()
    {
        nexlvl.lvlChange("ColorOfTShirtTaking");

        //Debug.Log("Hellow Word!");
    }

    void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null);
    }

    void OnLevelWasLoaded(int level)
    {
        if (level != 0)
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }

    void OnPhotonPlayerConnected(PhotonPlayer pp)
    {
        if (PhotonNetwork.isMasterClient)
        {
            int team;
            if (Player.players[Player.players.Count - 1].team == Team.RED)
                team = 1;
            else
                team = 0;
            photonView.RPC("PlayerIn", PhotonTargets.AllBuffered, pp, team);
        }
    }

    void OnPhotonPlayerDisconnected(PhotonPlayer pp)
    {
        if (PhotonNetwork.isMasterClient)
        {
            photonView.RPC("PlayerOut", PhotonTargets.AllBuffered, pp);
        }
    }

    [PunRPC]
    void PlayerIn(PhotonPlayer pp, int team)
    {
        Player player = new Player();
        player.nick = pp.NickName;
        player.pp = pp;
        player.health = 100;
        player.H = 0;
        player.team = (Team)team;
        Player.players.Add(player);
        if (pp == PhotonNetwork.player)
        {
            Player.myPlayer = player;
        }
    }

    [PunRPC]
    void PlayerOut(PhotonPlayer pp)
    {
        var outPlayer = Player.FindPlayer(pp);
        if (outPlayer != null)
        {
            Player.players.Remove(outPlayer);
        }
    }

    [PunRPC]
    void HRPC(PhotonPlayer pp, float h)
    {
        var player = Player.FindPlayer(pp);
        player.H = h;
    }

    [PunRPC]
    void PlayerHit(PhotonPlayer pp, int health)
    {
        var player = Player.FindPlayer(pp);
        player.health = health;
    }

    [PunRPC]
    void Win(Team team)
    {
        var player = Player.myPlayer;
        player.WhoWin = team;
    }


    void OnCreatedRoom()
    {
        int team = Random.Range(0, 2);
        photonView.RPC("PlayerIn", PhotonTargets.AllBuffered, PhotonNetwork.player, team);
    }

    public void OnHTaked(PhotonPlayer pp, float h)
    {
        photonView.RPC("HRPC", PhotonTargets.AllBuffered, pp, h);
    }

    public void OnShoot(int i)
    {
        photonView.RPC("PlayerHit", PhotonTargets.AllBuffered, Player.players[i].pp, Player.players[i].health);
    }

    public void Winn()
    {
        

        for (int i = 0; i < Player.players.Count; i++)
        {
            if (Player.players[i].health > 0)
            {
                if(Player.players[i].team == Team.RED)
                {
                    RedAlive++;
                    RedPlayer = i;
                    
                }
                else
                {
                    BlueAlive++;
                    BluePlayer = i;
                }
            }

        }
        if(RedAlive == 0)
        {
            photonView.RPC("Win", PhotonTargets.AllBuffered, Player.players[BluePlayer].team);
        }
        else if (BlueAlive == 0)
        {
            photonView.RPC("Win", PhotonTargets.AllBuffered, Player.players[RedPlayer].team);
        }
        RedAlive = 0;
        BlueAlive = 0;
    }
}
//