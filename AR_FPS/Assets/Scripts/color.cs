using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class color : MonoBehaviour
{

    private Color pixell;
   // private PlayerData loadedPlayerData;
    public float h;
    public GameObject Kamera;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        /*string json = File.ReadAllText(Application.dataPath + "/saveFile.json");
        loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);
        // pixell = Color.HSVToRGB(h, 1, 1);
        pixell = Color.HSVToRGB(loadedPlayerData.H, 1, 1);
        // GetComponent<Camera>().GetComponent<PhoneCamera>().H*/
    }
    void Update()
    {
        if (button.GetComponent<Fireing>().buttonPressed)
        {
            pixell = Color.HSVToRGB(Kamera.GetComponent<PhoneCamera>().H, 1, 1);
            h = Kamera.GetComponent<PhoneCamera>().H;
            GetComponent<Image>().color = pixell;
        }
        
    }

    public void ColorTaked()
    {
        h = h * 360;
        GameManager.instant.ONHColorTaked(h);
    }

    
   /* private class PlayerData
    {
        public float H;
    }*/
}
