using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public bool SetText;
    public string Text;
    public float LifeTime;
    public SpeechBubbleSpeaker speaker;


    // Update is called once per frame
    void Update()
    {
        if(SetText)
        {
            SetText = false;
            FindObjectOfType<SpeechBubbleService>().SpawnSpeechBubble(new SpeechBubbleData(Text, LifeTime, speaker));
        }
    }
}
