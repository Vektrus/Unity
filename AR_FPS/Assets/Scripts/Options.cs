using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.JSONSerializeModule;


public class Options : MonoBehaviour
{
    public Color pixel;
    public bool ifImageIsLoad = false;
   // public float H, S, V;
    public Texture2D texture;



    public void PickImage(int maxSize)
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create Texture from selected image
                texture = NativeGallery.LoadImageAtPath(path, maxSize);
               // pixel = texture.GetPixel(100, 100);
               // Color.RGBToHSV(pixel, out H, out S, out V);
               // PlayerData playerdata = new PlayerData();
               // playerdata.H = H;
               // string json = JsonUtility.ToJson(playerdata);
               // File.WriteAllText(Application.dataPath + "/saveFile.json", json);
                

                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    //ifImageIsLoad = false;
                    return;

                }
                
                
                    /*pixel = texture.GetPixel(100, 100);
                    Color.RGBToHSV(pixel, out H, out S, out V);*/
                   /* PlayerData playerdata = new PlayerData();
                    playerdata.H = H;
                    string json = JsonUtility.ToJson(playerdata);
                    File.WriteAllText(Application.dataPath + "/saveFile.json", json);*/
                
                //TextureFormat.EAC_RGB;
                // Assign texture to a temporary quad and destroy it after 5 seconds
                GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                 quad.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.5f;
                 quad.transform.forward = Camera.main.transform.forward;
                 quad.transform.localScale = new Vector3(1f, texture.height / (float)texture.width, 1f);

                 Material material = quad.GetComponent<Renderer>().material;
                 if (!material.shader.isSupported) // happens when Standard shader is not included in the build
                     material.shader = Shader.Find("Legacy Shaders/Diffuse");

                 material.mainTexture = texture;

                 Destroy(quad, 5f);
                ifImageIsLoad = true;

                // If a procedural texture is not destroyed manually, 
                // it will only be freed after a scene change
                Destroy(texture, 5f);
            }
        }, "Select a JPG image", "image/jpg", maxSize);

        Debug.Log("Permission result: " + permission);
    }
    
    
    /*private class PlayerData
    {
        public float H;
    }*/
    
}
