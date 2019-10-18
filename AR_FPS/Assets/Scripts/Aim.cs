using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    public bool aim;
   public void SetText()
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        if(txt.text == "Start Aim")
        {
            txt.text = "Stop Aim";
            aim = true;
        }
        else
        {
            txt.text = "Start Aim";
            aim = false;
        }
    }

}
