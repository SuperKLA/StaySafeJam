using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenue : MonoBehaviour
{
    public string scenePlayClick;

    private AudioFiles audioFiles;
    private AudioSource audioSource;
    private Animator animator;

    void Start()
    {
        StartBackgroundMusik();
        animator = GetComponent<Animator>();
    }

    public void PlayBtnCLick()
    {
        animator.SetTrigger("LoadScene");
    }

    public void ExitBtnClick()
    {
        Application.Quit();
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(audioFiles.clickSound);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(scenePlayClick);
    }

    private void StartBackgroundMusik()
    {
        audioFiles = FindObjectOfType<AudioFiles>();
        audioSource = FindObjectOfType<AudioSource>();

        audioSource.clip = audioFiles.startMenueBackgroundSound;
        audioSource.loop = true;
        audioSource.Play();
    }
}
