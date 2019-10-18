using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ColorInOptions : MonoBehaviour
{
    private Color pixell;
    //private PlayerData loadedPlayerData;
    private Texture2D texturee;
   // public float h;
    public float H, S, V;
    public GameObject optionsButton;
    private bool Readed;

    // Start is called before the first frame update
    void Start()
    {
        Readed = true;
    }
    void Update()
    {
        if (optionsButton.GetComponent<Options>().ifImageIsLoad && Readed)
        {
            texturee = optionsButton.GetComponent<Options>().texture;
            pixell = texturee.GetPixel(texturee.width / 2, texturee.height / 2);
            Color.RGBToHSV(pixell, out H, out S, out V);
            /*PlayerData playerdata = new PlayerData();
            playerdata.H = H;
            string json = JsonUtility.ToJson(playerdata);
            File.WriteAllText(Application.dataPath + "/saveFile.json", json);*/

            /*string json = File.ReadAllText(Application.dataPath + "/saveFile.json");
            loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);
            // pixell = Color.HSVToRGB(h, 1, 1);
            pixell = Color.HSVToRGB(loadedPlayerData.H, 1, 1);
            // GetComponent<Camera>().GetComponent<PhoneCamera>().H*/

            pixell = Color.HSVToRGB(H, 1, 1);
            GetComponent<Image>().color = pixell;
            Readed = false; 
        }
       

    }


   /* private class PlayerData
    {
        public float H;
    }**/
}
