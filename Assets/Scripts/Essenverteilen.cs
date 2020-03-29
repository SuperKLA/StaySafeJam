using UnityEngine;
using UnityEngine.SceneManagement;

public class Essenverteilen : MonoBehaviour
{
    public void Start()
    {
        SetMood();
    }

    void SetMood()
    {
        var allHomeLess = HomelessManager.Current.AllHomeLess;
        var currentLevel = 0f;

        for (int c = 0; c < allHomeLess.Count; c++)
        {
            var homeless = allHomeLess[c];
            currentLevel += homeless.currentHunger;
        }

        currentLevel /= allHomeLess.Count;
        
        if(currentLevel < 35)
            MainMenuMusic.Current.SetBadMood(1);
        else
            MainMenuMusic.Current.SetBadMood(0);
    }
}