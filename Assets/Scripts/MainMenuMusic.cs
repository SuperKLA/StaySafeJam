using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    public static MainMenuMusic Current;
    public FMOD.Studio.EventInstance AUDIO_MainMusic;
    public FMOD.Studio.Bus MASTER;
    public FMOD.Studio.Bus SFX;
    public static bool InitDone;
    public bool IsRunning;

    void Start()
    {
        Current = this;

        if (InitDone)
        {
            if (!this.IsRunning)
            {
                this.IsRunning = true;
                this.AUDIO_MainMusic.start();
            }
            return;
        }
        
        this.MASTER = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        this.SFX = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
        
        this.AUDIO_MainMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Music/music_main_loop");
        this.AUDIO_MainMusic.start();

        InitDone = true;
        this.IsRunning = true;

        this.SetVolume(0.2f);
        this.SetVolumeSFX(0.6f);
    }

    public void SetBadMood(float val)
    {
        if (!InitDone) return;
        
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("gameplay_bad", val);
    }
    
    public void PlayLoseSound()
    {
        if (!InitDone) return;
        
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("gameover", 1);
    }
    
    public void PlayWinSound()
    {
        if (!InitDone) return;
        
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("victory", 1);
    }

    public void StopWinLoseSound()
    {
        if (!InitDone) return;
        
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("gameover", 0);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("victory", 0);
    }
    
    public void SetVolume(float val)
    {
        if (!InitDone) return;

        this.MASTER.setVolume(val);
    }
    
    public void SetVolumeSFX(float val)
    {
        if (!InitDone) return;

        this.SFX.setVolume(val);
    }

    public void Stop()
    {
        if (!InitDone) return;

        this.IsRunning = false;
        this.AUDIO_MainMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
    
    public void Play()
    {
        if (!InitDone) return;
        if (IsRunning) return;

        this.IsRunning = true;
        this.AUDIO_MainMusic.start();
    }
}