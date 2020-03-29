using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static DontDestroyOnLoad Current;
    
    void Awake()
    {
        if (Current != null)
        {
            MainMenuMusic.Current.Stop();
            gameObject.SetActive(false);
            MonoBehaviour.Destroy(gameObject);
            return;
        }
        
        Current = this;
        DontDestroyOnLoad(this.gameObject);
    }

}
