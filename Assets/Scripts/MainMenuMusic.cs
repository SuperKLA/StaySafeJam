using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    public static MainMenuMusic Current;
    public FMOD.Studio.EventInstance AUDIO_MainMusic;
    public bool InitDone;

    void Start()
    {
        Current = this;

        if (this.InitDone) return;
        
        this.AUDIO_MainMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Music/music_main_loop");
        this.AUDIO_MainMusic.start();

        this.InitDone = true;
    }

    public void SetBadMood(float val)
    {
        if (!this.InitDone) return;
        
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("gameplay_bad", val);
    }
}