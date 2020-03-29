using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;   

public class HomelessDisplay : MonoBehaviour
{
    public HomelessPanel HomelessPanel;

    public Image homelessPortrait;
    public TMP_Text homelessName;
    public Slider homelessHunger;
    public Image homlessHungerBar;

    Color red = new Color(249 / 255f, 158 / 255f, 184 / 255f);
    Color orange = new Color(255 / 255f, 206 / 255f, 162 / 255f);
    Color yellow = new Color(255 / 255f, 254 / 255f, 153 / 255f);
    Color green = new Color(153 / 255f, 253 / 255f, 153 / 255f);

    
    // Start is called before the first frame update
    void Start()
    {
        homelessName.text = HomelessPanel.homelessName;
        SetHunger(HomelessPanel.hunger);
    }

    private void SetHunger(float value)
    {
        homelessHunger.value = value;
        ChangeHungerBarColor();
        ChangePortrait();
    }

    private void ChangeHungerBarColor()
    {
        if (homelessHunger.value >= 90)
            homlessHungerBar.color = yellow;
        else if (homelessHunger.value >= 75)
            homlessHungerBar.color = green;
        else if (homelessHunger.value >= 50)
            homlessHungerBar.color = yellow;
        else if (homelessHunger.value >= 25)
            homlessHungerBar.color = orange;
        else
            homlessHungerBar.color = red;
    }
    
    private void ChangePortrait()
    {
        if (homelessHunger.value >= 90)
            homelessPortrait.sprite = HomelessPanel.portrait[3];
        else if (homelessHunger.value >= 50)
            homelessPortrait.sprite = HomelessPanel.portrait[2];
        else if (homelessHunger.value >= 25)
            homelessPortrait.sprite = HomelessPanel.portrait[1];
        else
            homelessPortrait.sprite = HomelessPanel.portrait[0];
    }

}
