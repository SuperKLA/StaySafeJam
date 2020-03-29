using UnityEngine.SceneManagement;
using UnityEngine;

public class EndScreen : MenueWithAudio
{
    public string sceneBackClick;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        StartBackgroundMusik();
        HomelessManager.Current.ResetHomeless();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene()
    {
        //MainMenuMusic.Current.PlayLoseSound();
        SceneManager.LoadScene(sceneBackClick);
    }

    protected override void StartBackgroundMusik()
    {
        if (!AudioFilesAndSourceNotNull)
        {
            LogAudioError();
            return;
        }

        audioSource.clip = audioFiles.endScreenBackgroundSound;
        audioSource.loop = true;
        audioSource.Play();
    }

}
