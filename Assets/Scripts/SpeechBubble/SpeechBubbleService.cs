using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class SpeechBubbleService : MonoBehaviour
{
    SpeechBubbleSelector selector;

    public void SpawnSpeechBubble(SpeechBubbleData data)
    {
        if (IsSelectorNull())
        {
            Debug.Log("SpeechBubbleSelector nicht gefunden");
            return;
        }

        FindSpeechBubble(data.speaker).ShowSpeechBubble(CheckGunnerText(data));
    }

    private SpeechBubble FindSpeechBubble(SpeechBubbleSpeaker speaker)
    {
        return selector.GetSpeechBubble(speaker);
    }

    private bool IsSelectorNull()
    {
        if (selector == null)
            selector = FindObjectOfType<SpeechBubbleSelector>();
        return selector == null;
    }

    private SpeechBubbleData CheckGunnerText(SpeechBubbleData data)
    {
        if (data.speaker == SpeechBubbleSpeaker.Gunner)
        {
            if (Random.Range(0, 100) > 50)
                data.text = "Wooooof!";
            else
                data.text = "Grrrrrrrt!";

        }
        return data;
    }
}
