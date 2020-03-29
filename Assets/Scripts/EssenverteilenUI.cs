using UnityEngine;
using UnityEngine.SceneManagement;

public class EssenverteilenUI : MonoBehaviour
{
    public void NextClick()
    {
        var allCups = CupComeCloserManager.Current.Cups;
        for (int c = 0; c < allCups.Count; c++)
        {
            var cup = allCups[c];
            cup.FeedYourHomeless();
        }

        if (HomelessManager.Current.IsSomeDead())
        {
            SceneManager.LoadScene("EndScene");
        }
        else
        {
            SceneManager.LoadScene("HungerScene");    
        }
    }
    
}