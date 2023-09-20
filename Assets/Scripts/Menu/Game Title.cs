using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTitle : MonoBehaviour
{
    public GameObject titleGame;


    public void TitleGameOFF()
    {
        titleGame.SetActive(false);
      
    }

    public void TitleGameON()
    {
        titleGame.SetActive(true);
        
    }
}
