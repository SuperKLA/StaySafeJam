using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HomelessManager : MonoBehaviour
{
    public static HomelessManager Current;

    public HomelessConfig homelessConfig;
    public List<Homeless> AllHomeLess;

    private void Start()
    {
        Current = this;
        this.Setup();
    }

    void Setup()
    {
        this.AllHomeLess = this.AllHomeLess ?? new List<Homeless>();
        
        for (int c = 0; c < this.homelessConfig.homelessList.Count; c++)
        {
            var homelessPrefab = this.homelessConfig.homelessList[c];
            var homeless = Instantiate(homelessPrefab.gameObject);
            homeless.name = homelessPrefab.Name;

            var homelessData = homeless.GetComponent<Homeless>();
            this.AllHomeLess.Add(homelessData);
        }
        
    }


    public void GiveFood(Food food, string homelessId)
    {
        var homeless = AllHomeLess.FirstOrDefault(m => m.ID.Equals(homelessId, StringComparison.OrdinalIgnoreCase));
        if (homeless == null) return;

        homeless.currentHunger = Mathf.Clamp(homeless.currentHunger + food.Calories, 0, 100);
    }
}