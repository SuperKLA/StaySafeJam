using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    public static MainMenuMusic Current;
    public FMOD.Studio.EventInstance AUDIO_MainMusic;
    public FMOD.Studio.Bus MASTER;
    public bool InitDone;

    void Start()
    {
        Current = this;

        if (this.InitDone) return;
        
        this.MASTER = FMODUnity.RuntimeManager.GetBus("bus:/Master");
        
        this.AUDIO_MainMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Music/music_main_loop");
        this.AUDIO_MainMusic.start();

        this.InitDone = true;

        this.SetVolume(0.3f);
    }

    public void SetBadMood(float val)
    {
        if (!this.InitDone) return;
        
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("gameplay_bad", val);
    }
    
    public void SetVolume(float val)
    {
        if (!this.InitDone) return;

        this.MASTER.setVolume(val);
    }
}