using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTransitionTrigger : MonoBehaviour
{
    public AudioMixerSnapshot snapshot_01;
    public AudioMixerSnapshot snapshot_02;

    public string tagToCompare = "Player";


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagToCompare))
        {
            snapshot_02.TransitionTo(1f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tagToCompare))
        {
            snapshot_01.TransitionTo(1f);
        }
    }
}
