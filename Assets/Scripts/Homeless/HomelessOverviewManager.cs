using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomelessOverviewManager : MonoBehaviour
{

    public HomelessPanel homeless1;
    public HomelessPanel homeless2;
    public HomelessPanel homeless3;
    public HomelessPanel homeless4;


    private void Awake()
    {
        List<Homeless> AllHomeLess = FindObjectOfType<HomelessManager>().AllHomeLess;

        foreach (var homeless in AllHomeLess)
        {
            HomelessPanel panel = GetPanelByName(homeless.name);
            if (panel != null)
                panel.hunger = homeless.currentHunger;
        }
    }

    private HomelessPanel GetPanelByName(string name)
    {
        if (name == "Hausmann")
            return homeless1;
        else if (name == "Doggo")
            return homeless2;
        else if (name == "MuetzenFrau")
            return homeless3;
        else if (name == "Babuschka")
            return homeless4;
        else return null;
    }

}
