using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public string tagToCompare = "Player";

    public GameObject EndGameUi;

    //public AudioSource winGame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagToCompare))
        {
            CallEndGamer();
        }
    } 
    
    public void CallEndGamer()
    {
        EndGameUi.SetActive(true);
        Time.timeScale = 0;

        
       // winGame.Play();

    }
}
