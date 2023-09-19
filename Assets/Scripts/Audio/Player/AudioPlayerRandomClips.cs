using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerRandomClips : MonoBehaviour
{
    public List<AudioClip> audioClipsList;

    public List <AudioSource> audioSourceList;

    private int _index = 0;

    public void PlayerRandom()
    {
        if(_index >= audioSourceList.Count - 1)
        
            _index = 0;

            var audioSource = audioSourceList[_index];

            audioSource.clip = audioClipsList[Random.Range(0, audioClipsList.Count)];
            audioSource.Play();

            _index++;
        

        
    }
}
