using System.Collections.Generic;
using UnityEngine;

public class HomelessConfig : MonoBehaviour
{
    [SerializeField]
    public List<Homeless> homelessList = new List<Homeless>();

    public float CaloriesNeedForMax = 4000f;

    public int RoundsToWin = 10;
    public int CurrentRound = 0;
}
