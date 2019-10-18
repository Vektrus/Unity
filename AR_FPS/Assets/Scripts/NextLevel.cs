using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    
    
    //public GameObject optionsButton;

    void Start()
    {
        
    }

    public void lvlChange (string NameOfNextLvl)
    {
        // if (optionsButton.GetComponent<Options>().ifImageIsLoad)
        // {
        
       SceneManager.LoadScene(NameOfNextLvl);
       // }
        
    }
           
        
        
    


    
}
