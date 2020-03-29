using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SpeechBubbleData
{
    public string text;
    public float LifeTime;
    public SpeechBubbleSpeaker speaker;

    public SpeechBubbleData(string text, float lifeTime, SpeechBubbleSpeaker speaker)
    {
        this.text = text;
        LifeTime = lifeTime;
        this.speaker = speaker;
    }
}

public enum SpeechBubbleSpeaker
{
    Liam,
    Sarah,
    Gerthrud,
    Gunner
}

