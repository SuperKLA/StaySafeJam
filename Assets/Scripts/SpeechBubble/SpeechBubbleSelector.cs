using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubbleSelector : MonoBehaviour
{
    public SpeechBubble Gerthrud;
    public SpeechBubble Gunner;
    public SpeechBubble Liam;
    public SpeechBubble Sarah;


    public SpeechBubble GetSpeechBubble(SpeechBubbleSpeaker position)
    {
        switch (position)
        {
            case SpeechBubbleSpeaker.Gerthrud:
                return Gerthrud;
            case SpeechBubbleSpeaker.Gunner:
                return Gunner;
            case SpeechBubbleSpeaker.Liam:
                return Liam;
            case SpeechBubbleSpeaker.Sarah:
                return Sarah;
            default:
                return null;
        }
    }
}
