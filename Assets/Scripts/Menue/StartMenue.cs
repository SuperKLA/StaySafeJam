using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenue : MenueWithAudio
{
    public string scenePlayClick;
    public GameObject MainMusic;

    private Animator animator;

    new void Start()
    {
        base.Start();
        this.animator = GetComponent<Animator>();
        this.StartBackgroundMusik();
        MainMusic.gameObject.SetActive(false);
    }

    public void PlayBtnCLick()
    {
        MainMusic.gameObject.SetActive(true);
        animator.SetTrigger("LoadScene");
    }

    public void ExitBtnClick()
    {
        Application.Quit();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(scenePlayClick);
    }
}