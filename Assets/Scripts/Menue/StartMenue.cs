﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenue : MenueWithAudio
{
    public string scenePlayClick;
    public GameObject MainMusic;

    private Animator animator;

    new void Start()
    {
        base.Start();
        this.animator = GetComponent<Animator>();
        this.StartBackgroundMusik();

        if (this.MainMusic == null && MainMenuMusic.Current != null)
        {
            this.MainMusic = MainMenuMusic.Current.gameObject;
        }
        
        // if (MainMenuMusic.Current != null)
        // {
        //     MainMenuMusic.Current.StopWinLoseSound();
        // }
        
        MainMusic.gameObject.SetActive(false);
        
        var master = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        master.setVolume(0.2f);
    }

    public void PlayBtnCLick()
    {
        if (this.MainMusic == null && MainMenuMusic.Current != null)
        {
            this.MainMusic = MainMenuMusic.Current.gameObject;
        }
        
        MainMusic.gameObject.SetActive(true);
        animator.SetTrigger("LoadScene");
    }

    public void ExitBtnClick()
    {
        Application.Quit();
    }

    public void CreditsBtnClick()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadScene()
    {
        if (MainMenuMusic.Current != null)
        {
            MainMenuMusic.Current.Play();
        }
        
        SceneManager.LoadScene(scenePlayClick);
    }
}