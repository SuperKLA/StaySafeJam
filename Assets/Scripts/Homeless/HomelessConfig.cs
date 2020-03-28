using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomelessConfig : MonoBehaviour
{
    [SerializeField]
    List<Homeless> homelessList = new List<Homeless>();

    public List<Homeless> GetHomelessList()
    {
        return homelessList;
    }
}
