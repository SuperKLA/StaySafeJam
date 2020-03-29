using System.Collections.Generic;
using UnityEngine;

public class HomelessConfig : MonoBehaviour
{
    [SerializeField]
    public List<Homeless> homelessList = new List<Homeless>();

    public float CaloriesNeedForMax = 4000f;
}
