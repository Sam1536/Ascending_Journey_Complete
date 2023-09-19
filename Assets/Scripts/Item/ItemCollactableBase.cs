using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemCollactableBase : MonoBehaviour
{
    [Header("Sounds")]
    public AudioSource audioSource;

    public Animator anim;
    public string compareTag = "Player";
    public ParticleSystem particleSystem;
    public float particlesTimeCoin = 3f;
    public GameObject graphicCoin;


    private void Awake()
    {
        //if (particleSystem != null)
        //{
        //    particleSystem.transform.SetParent(null);
        //}


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(compareTag))
        {
            Collect();
            
        }

        
    }

   

    protected virtual void Collect()
    {
        if(graphicCoin != null)
        {
            graphicCoin.SetActive(false);
           
            
        }
        Invoke("HiderObject", particlesTimeCoin);
      
        OnCollect();
        
    }

    private void HiderObject()
    {
        // Debug.Log("pegou");
        gameObject.SetActive(false);
        

    }


    protected virtual void OnCollect()
    {
        if (particleSystem != null)
        {  
            particleSystem.Play();
        }

        if(audioSource != null)
        {
            audioSource.Play();
        }

    }
    

    
    
        

    
}

