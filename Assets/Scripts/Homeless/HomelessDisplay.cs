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
    public Image homlessHungerBar;

    Color red = new Color(249 / 255f, 158 / 255f, 184 / 255f);
    Color orange = new Color(255 / 255f, 206 / 255f, 162 / 255f);
    Color yellow = new Color(255 / 255f, 254 / 255f, 153 / 255f);
    Color green = new Color(153 / 255f, 253 / 255f, 153 / 255f);

    
    // Start is called before the first frame update
    void Start()
    {
        homelessPortrait.sprite = HomelessPanel.portrait;
        homelessName.text = HomelessPanel.homelessName;
        float hunger = HomelessPanel.hunger;
        homelessHunger.value = hunger;
        ChangeHungerBarColor(hunger);
    }

    private void ChangeHungerBarColor(float hunger)
    {
        if (hunger >= 75)
            homlessHungerBar.color = green;
        else if (hunger >= 50)
            homlessHungerBar.color = yellow;
        else if (hunger >= 25)
            homlessHungerBar.color = orange;
        else
            homlessHungerBar.color = red;
    }
}
