using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AudioFile : MonoBehaviour
{
    public AudioSource audioSource;

    public Slider progressBar;

    public GameObject playButton;
    public GameObject pauseButton;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        pauseButton.SetActive(false);

    }

    void Update()
    {
        if (audioSource.isPlaying)
        {
            float progress = audioSource.time / audioSource.clip.length;

            progressBar.value = progress;

        }

    }

    public void Play()
    {
       
        audioSource.Play();
        playButton.SetActive(false);
        pauseButton.SetActive(true);
 
        
    }

    public void Pause()
    {
        audioSource.Pause();
        playButton.SetActive(true);
        pauseButton.SetActive(false);

    }

    public void Restart()
    {
        audioSource.Stop();
        
    }
}
