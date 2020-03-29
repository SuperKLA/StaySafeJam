using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomelessOverviewManager : MonoBehaviour
{

    public HomelessPanel Liam;
    public HomelessPanel Gunner;
    public HomelessPanel Sarah;
    public HomelessPanel Gerthrud;


    private void Awake()
    {
        List<Homeless> AllHomeLess = FindObjectOfType<HomelessManager>()?.AllHomeLess;

        foreach (var homeless in AllHomeLess)
        {
            HomelessPanel panel = GetPanelByName(homeless.ID);
            if (panel != null)
                panel.hunger = homeless.currentHunger;
        }
    }

    private HomelessPanel GetPanelByName(string name)
    {
        if (name == "Homeless1")
            return Sarah;
        else if (name == "Homeless2")
            return Liam;
        else if (name == "Homeless3")
            return Gunner;
        else if (name == "Homeless4")
            return Gerthrud;
        else return null;
    }

}
