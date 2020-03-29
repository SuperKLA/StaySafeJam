using UnityEngine.SceneManagement;
using UnityEngine;

public class HomelessOverView : MenueWithAudio
{

    public string sceneNextClick;

    new void Start()
    {
        base.Start();
        StartBackgroundMusik();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneNextClick);
    }

    protected override void StartBackgroundMusik()
    {
        if (!AudioFilesAndSourceNotNull)
        {
            LogAudioError();
            return;
        }

        audioSource.clip = audioFiles.homelessOverviewBackgroundSound;
        audioSource.loop = true;
        audioSource.Play();
    }
}
