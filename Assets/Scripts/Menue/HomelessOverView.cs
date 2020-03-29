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
        //aka play next round
        HomelessManager.Current.IncreaseHunger();

        var hasWon = HomelessManager.Current.IsLastLevelAndHasWon();
        if (hasWon)
        {
            SceneManager.LoadScene("WinScene");    
        }
        else
        {
            SceneManager.LoadScene(this.sceneNextClick);    
        }
        
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
