using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
   
    public GameObject menuButton;
    
    public void MenuPaused()
    {
        menuButton.SetActive(true);
        //Time.timeScale = 0;
        Debug.Log(Time.timeScale);
       
  
    }
     
    public void BackMenuPaused()
    {
        menuButton.SetActive(false);
       // Time.timeScale = 1;
        Debug.Log(Time.timeScale);


    }


}
