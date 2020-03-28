using UnityEngine.SceneManagement;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public string sceneBackClick;
    AudioFiles audioFiles;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
       // StartBackgroundMusik();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(audioFiles.clickSound);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneBackClick);
    }

    private void StartBackgroundMusik()
    {
        audioFiles = FindObjectOfType<AudioFiles>();
        audioSource = FindObjectOfType<AudioSource>();

        audioSource.clip = audioFiles.endScreenBackgroundSound;
        audioSource.loop = true;
        audioSource.Play();
    }
}
