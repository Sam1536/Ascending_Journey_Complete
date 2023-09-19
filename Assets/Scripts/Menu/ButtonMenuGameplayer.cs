using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMenuGameplayer : MonoBehaviour
{
   
    public GameObject menuButton;
    public GameTitle gameTitle;
    

    public void MenuPaused()
    {
        menuButton.SetActive(true);
        gameTitle.TitleGameOFF();
        Time.timeScale = 0;
        Debug.Log(menuButton);
  
    }
     
    public void BackMenuPaused()
    {
        menuButton.SetActive(false);
        gameTitle.TitleGameON();
        Time.timeScale = 1;
        Debug.Log(menuButton);
  
    }


}
