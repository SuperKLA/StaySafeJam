using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public bool SetText;
    public string Text;
    public float LifeTime;

    public SpeechBubble bubbleToTest;

    // Update is called once per frame
    void Update()
    {
        if(SetText)
        {
            SetText = false;
            bubbleToTest.ShowSpeechBubble(new SpeechBubbleData(Text, LifeTime, SpeechBubblePosition.Bottom));
        }
    }
}
