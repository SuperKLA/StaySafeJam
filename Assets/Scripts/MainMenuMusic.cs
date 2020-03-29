using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    public static MainMenuMusic Current;
    public FMOD.Studio.EventInstance AUDIO_MainMusic;
    public FMOD.Studio.Bus MASTER;
    public static bool InitDone;

    void Start()
    {
        Current = this;

        if (InitDone)
        {
            return;
        }
        
        this.MASTER = FMODUnity.RuntimeManager.GetBus("bus:/Master");
        
        this.AUDIO_MainMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Music/music_main_loop");
        this.AUDIO_MainMusic.start();

        InitDone = true;

        this.SetVolume(0.2f);
    }

    public void SetBadMood(float val)
    {
        if (!InitDone) return;
        
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("gameplay_bad", val);
    }
    
    public void SetVolume(float val)
    {
        if (!InitDone) return;

        this.MASTER.setVolume(val);
    }

    public void Stop()
    {
        if (!InitDone) return;

        this.AUDIO_MainMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}