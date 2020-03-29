using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class SpeechBubbleService : MonoBehaviour
{
    GameObject SpeechBubblePrefab;

    List<SpeechBubble> activeSpeechBubbles = new List<SpeechBubble>();


    // Update is called once per frame
    void Update()
    {

    }

    //public void SpawnSpeechBubble(SpeechBubble bubble)
    //{
    //    GameObject newSpeechBubble = Instantiate(SpeechBubblePrefab, new Vector3(bubble.spawnPosition.x, 0, bubble.spawnPosition.y), Quaternion.identity);
    //    newSpeechBubble.AddComponent(typeof(SpeechBubble));
    //    newSpeechBubble.GetComponent<SpeechBubble>().
    //}


    //private SpeechBubble GetPrefab(SpeechBubble bubble)
    //{

    //}


}
