using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    public static MainMenuMusic Current;
    public FMOD.Studio.EventInstance AUDIO_MainMusic;

    void Start()
    {
        Current = this;

        this.AUDIO_MainMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Music/music_main_loop");
        this.AUDIO_MainMusic.start();
    }

    public void SetBadMood(float val)
    {
        if (this.AUDIO_MainMusic == null) return;
        
        this.AUDIO_MainMusic.setParameterByName("gameplay_bad", val);
    }
}