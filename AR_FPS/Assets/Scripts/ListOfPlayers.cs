using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player
{
    
    static public Player myPlayer;
    public Team WhoWin;
    public string nick = "";
    public PhotonPlayer pp;
    public float H;
    public Team team;
    public int health;
    public static List<Player> players = new List<Player>();

    public static void DebugListOfPlayers()
    {
        string dbgS = "Debug list of players, number of players: " + players.Count + " all players:\n";
        int i = 0;
        foreach (var player in players) 
        {
            dbgS += "ID: "+ i + ", Nick: " + player.nick + ", HP: " + player.health.ToString() +", H: " + player.H + ", team: " + player.team + "\n";
            i++;
        }
        Debug.Log(dbgS);
    }

    public static Player FindPlayer(PhotonPlayer pp)
    {
        for(int i = 0; i < players.Count; i++)
        {
            if (players[i].pp == pp)
            {
                return players[i];
            }
            
        }
        return null;
    }

    public static Player FindPlayerByNick(string nick)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].nick == nick)
            {
                return players[i];
            }


        }
        return null;
    }

    public static bool CheckHit(float h, Team team)
    {
        float AccuracyOfCheckingHit = 12;
        for (int i = 0; i < players.Count; i++)
        {
            if(team != players[i].team)
            {
                float hh = players[i].H;
                if (hh == h)
                {
                    Hit(i);
                    return true;
                }
                else if (hh - AccuracyOfCheckingHit < 0 && (h - 360) > hh - AccuracyOfCheckingHit)
                {


                    Hit(i);
                    return true;

                }
                else if (hh + AccuracyOfCheckingHit > 360 && (h + 360) < hh + AccuracyOfCheckingHit)
                {

                    Hit(i);
                    return true;

                }
                else
                {
                    if (hh - AccuracyOfCheckingHit < h && h < hh + AccuracyOfCheckingHit)
                    {
                        Hit(i);
                        return true;
                    }
                }
            }
            

        }
        return false;
    }

    static void Hit(int i)
    {
        players[i].health = players[i].health - Random.Range(2, 5);
        
        if (players[i].health < 0)
        {
            players[i].health = 0;
        }
        GameManager.instant.OnShootToRPC(i);


    }

    
    
}

public enum Team {RED, BLUE}

/*public class Nick
{
    public static string ourNick;
}*/




