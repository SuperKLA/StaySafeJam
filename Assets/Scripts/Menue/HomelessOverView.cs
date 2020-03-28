using UnityEngine.SceneManagement;
using UnityEngine;

public class HomelessOverView : MonoBehaviour
{

    public string sceneNextClick;
    AudioFiles audioFiles;
    AudioSource audioSource;

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(audioFiles.clickSound);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneNextClick);
    }


    private void StartBackgroundMusik()
    {
        audioFiles = FindObjectOfType<AudioFiles>();
        audioSource = FindObjectOfType<AudioSource>();

        audioSource.clip = audioFiles.homelessOverviewBackgroundSound;
        audioSource.loop = true;
        audioSource.Play();
    }
}
