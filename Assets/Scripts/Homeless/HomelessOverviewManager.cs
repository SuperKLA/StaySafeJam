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
        // List<Homeless> AllHomeLess = FindObjectOfType<HomelessManager>().AllHomeLess;

        //foreach (var homeless in AllHomeLess)
        //{
            
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private HomelessPanel GetPanelByName(string name)
    {
        if (name == "")
            return homeless1;
        else if (name == "")
            return homeless2;
        else if (name == "")
            return homeless3;
        else if (name == "")
            return homeless4;
        else return null;
    }

}
