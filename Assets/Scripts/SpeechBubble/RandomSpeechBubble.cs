using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSpeechBubble : MonoBehaviour
{
    public float interval;

    List<string> List = new List<string>();
    SpeechBubbleService service;

    float timeSinceLastSpeechBubble;
    CurrentScene? currentScene;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = FindScene();
        service = FindObjectOfType<SpeechBubbleService>();
        InitLists();
        SetTimer();
        if (currentScene == CurrentScene.Start)
            SayHello();

    }

    // Update is called once per frame
    void Update()
    {
        if (service == null)
            service = FindObjectOfType<SpeechBubbleService>();


        if (timeSinceLastSpeechBubble < Time.time)
            SpawnSpeechBubble();
    }

    private void SpawnSpeechBubble()
    {
        string text = List[Random.Range(0, List.Count)];
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

    private CurrentScene? FindScene()
    {
        var _scene = SceneManager.GetSceneByName("StartMenue");
        if (_scene.IsValid())
            return CurrentScene.Start;
        _scene = SceneManager.GetSceneByName("EssenVerteilen");
        if (_scene.IsValid())
            return CurrentScene.EssenVerteilen;
        return null;
    }

    private void InitLists()
    {
        if (currentScene == CurrentScene.Start)
            List = new List<string>{
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

        else if (currentScene == CurrentScene.EssenVerteilen)
            List = new List<string>
            {
                "Hurry up! We are hungry!",
                "I am so hungry!",
                "I am starving!",
                "Is this vegan?",
                "Looks healthy!",
                "Do you need some help?",
                "This looks strange.",
                "This has a funny color.",
                "Is it enough?",
                "We don't have much. But we have us.",
                "This smells so good!",
                "Finally something to eat!",
                "I hope that’s not rotten.",
                "Do we have more than this?",
                "I bet we can split this up.",
                "My stomach is growling!",
                "I'm already hungry!",
                "What's this?",
                "Why do people waste so much?",
                "Wow! Who found that?",
                "I miss the days living in a house.",
                "How did i end up here?",
                "Send Noods pls!",
                "Do you ever wonder why we are here?",
                "Pasta la vista!",
                "Today is a great day for us, look!"
            };
    }

    public enum CurrentScene
    {
        Start,
        EssenVerteilen
    }
}
