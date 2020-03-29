using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpeechBubble : MonoBehaviour
{
    public float interval;

    List<string> startMenue = new List<string>();
    SpeechBubbleService service;

    float timeSinceLastSpeechBubble;

    // Start is called before the first frame update
    void Start()
    {
        service = FindObjectOfType<SpeechBubbleService>();
        InitList();
        SetTimer();
        SayHello();

    }

    // Update is called once per frame
    void Update()
    {
        if (timeSinceLastSpeechBubble < Time.time)
            SpawnSpeechBubble();
    }

    private void SpawnSpeechBubble()
    {
        string text = startMenue[Random.Range(0, startMenue.Count)];
        service.SpawnSpeechBubble(new SpeechBubbleData(text, 3, (SpeechBubbleSpeaker)Random.Range(0, 4)));
        SetTimer();
    }


    private void SayHello()
    {
        service.SpawnSpeechBubble(new SpeechBubbleData("Hello", 3, (SpeechBubbleSpeaker)Random.Range(0, 4)));
    }

    private void SetTimer()
    {
        timeSinceLastSpeechBubble = Time.time + interval;
    }

    private void InitList()
    {
        startMenue = new List<string>
       {

            "I am hungry!",
            "Where is this food?",
            "I’ve found something!",
            "There’s some bread!",
            "Here is something!",
            "They are wasting everything!",
            "I think i am getting a cold.",
            "Thats looks delicious!",
            "Over here!",
            "Hey, what’s this?",
            "I found it first!",
            "Hopefully we can find something to eat!",
            "Let's eat!",
            "Where's the knife?",
            "It's cold today!",
            "These are bad times for all of us.",
            "At least we have each other!",
            "Yumm!",
        };

    }
}
