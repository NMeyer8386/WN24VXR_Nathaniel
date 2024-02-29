using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioSource epicSound;

    private void OnEnable()
    {
        StoneSocket.OnAllStonesPlaced += PlayEpicSound;
    }

    private void OnDisable()
    {
        StoneSocket.OnAllStonesPlaced -= PlayEpicSound;
    }

    void PlayEpicSound()
    {
        epicSound.Play();
    }
}
