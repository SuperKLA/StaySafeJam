using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenueWithAudio : MonoBehaviour
{

    protected AudioFiles audioFiles;
    protected AudioSource audioSource;

    protected bool AudioFilesAndSourceNotNull { get { return (audioFiles != null && audioSource != null); } }


    // Start is called before the first frame update
    public void Start()
    {
        audioFiles = FindObjectOfType<AudioFiles>();
        audioSource = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void StartBackgroundMusik()
    {
        if (!AudioFilesAndSourceNotNull)
        {
            LogAudioError();
            return;
        }

        audioSource.clip = audioFiles.startMenueBackgroundSound;
        audioSource.loop = true;
        audioSource.Play();
    }


    public void PlayClickSound()
    {
        if (!AudioFilesAndSourceNotNull)
        {
            LogAudioError();
            return;
        }

        audioSource.PlayOneShot(audioFiles.clickSound);
    }


    protected void LogAudioError()
    {
        Debug.Log("AudioSource oder AudioFile ist null");
    }
}
