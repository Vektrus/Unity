using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamShow : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        var player = Player.myPlayer;
        string team = "Team: " + player.team;
        gameObject.GetComponent<TextMesh>().text = team;
    }


    
}
