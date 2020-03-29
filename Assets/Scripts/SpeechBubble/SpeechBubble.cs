using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    bool iAmActive = false;

    float TimeToDestroy;
    public TMP_Text myText;
    public Image myImage;

    public void ShowSpeechBubble(SpeechBubbleData data)
    {
        if (iAmActive)
            return;

        iAmActive = true;
        TimeToDestroy = Time.time + data.LifeTime;
        myText.text = data.text;
        myImage.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (iAmActive)
            if (Time.time > TimeToDestroy)
            {
                myText.text = null;
                myImage.enabled = false;
                iAmActive = false;
            }
    }
}
