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
        Time.timeScale = 0f;
        Debug.Log(Time.timeScale);

    }
     
    public void BackMenuPaused()
    {
        menuButton.SetActive(false);
        gameTitle.TitleGameON();
        Time.timeScale = 1f;
        Debug.Log(Time.timeScale);

    }


}
