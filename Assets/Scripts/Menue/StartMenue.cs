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

        if (this.MainMusic == null && MainMenuMusic.Current != null)
        {
            this.MainMusic = MainMenuMusic.Current.gameObject;
        }
        
        MainMusic.gameObject.SetActive(false);
        
        var master = FMODUnity.RuntimeManager.GetBus("bus:/Master");
        master.setVolume(0.2f);
    }

    public void PlayBtnCLick()
    {
        if (this.MainMusic == null && MainMenuMusic.Current != null)
        {
            this.MainMusic = MainMenuMusic.Current.gameObject;
        }
        
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