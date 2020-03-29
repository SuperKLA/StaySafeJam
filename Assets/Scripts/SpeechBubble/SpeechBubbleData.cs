using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SpeechBubbleData
{
    public string text;
    public float LifeTime;
    public SpeechBubblePosition position;

    public SpeechBubbleData(string text, float lifeTime, SpeechBubblePosition position)
    {
        this.text = text;
        LifeTime = lifeTime;
        this.position = position;
    }
}

public enum SpeechBubblePosition
{
    Top,
    Bottom,
    Left,
    Right
}

