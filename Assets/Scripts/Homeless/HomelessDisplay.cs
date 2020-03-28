using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class HomelessDisplay : MonoBehaviour
{
    public HomelessPanel HomelessPanel;

    public Image homelessPortrait;
    public Text homelessName;
    public Slider homelessHunger;

    // Start is called before the first frame update
    void Start()
    {
        homelessPortrait.sprite = HomelessPanel.portrait;
        homelessName.text = HomelessPanel.homelessName;
        homelessHunger.value = HomelessPanel.hunger;
    }
}
