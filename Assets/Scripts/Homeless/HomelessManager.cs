using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class HomelessManager : MonoBehaviour
{
    public static HomelessManager Current;

    public HomelessConfig homelessConfig;
    public List<Homeless> AllHomeLess;
    public List<float>    HungerStartValues;

    private void Start()
    {
        Current = this;
        this.Setup();
    }

    void Setup()
    {
        this.AllHomeLess       = this.homelessConfig.homelessList;
        this.HungerStartValues = new List<float>();

        for (int c = 0; c < this.AllHomeLess.Count; c++)
        {
            var homeless = this.AllHomeLess[c];
            this.HungerStartValues.Add(homeless.currentHunger);
        }

        // this.AllHomeLess = this.AllHomeLess ?? new List<Homeless>();
        //
        // for (int c = 0; c < this.homelessConfig.homelessList.Count; c++)
        // {
        //     var homelessPrefab = this.homelessConfig.homelessList[c];
        //     var homeless = Instantiate(homelessPrefab.gameObject);
        //     homeless.name = homelessPrefab.Name;
        //
        //     var homelessData = homeless.GetComponent<Homeless>();
        //     this.AllHomeLess.Add(homelessData);
        // }
    }


    public void FeedHomeless(Food food, string homelessId)
    {
        var homeless = this.AllHomeLess.FirstOrDefault(m => m.ID.Equals(homelessId, StringComparison.OrdinalIgnoreCase));
        if (homeless == null) return;

        var restCalories    = (homeless.currentHunger / 100f) * this.homelessConfig.CaloriesNeedForMax;
        var currentCalories = restCalories + food.Calories;
        var hungerLevel     = currentCalories / this.homelessConfig.CaloriesNeedForMax;

        homeless.currentHunger = Mathf.Clamp(hungerLevel * 100, 0, 100);
    }

    public void IncreaseHunger()
    {
        for (int c = 0; c < this.AllHomeLess.Count; c++)
        {
            var homeless = this.AllHomeLess[c];
            var value    = Random.Range(homeless.HungerIncrease.x, homeless.HungerIncrease.y);

            homeless.currentHunger = Mathf.Clamp(homeless.currentHunger - value, 0, 100);
        }
    }

    public bool IsSomeDead()
    {
        for (int c = 0; c < this.AllHomeLess.Count; c++)
        {
            var homeless = this.AllHomeLess[c];
            if (homeless.currentHunger <= 0)
            {
                return true;
            }
        }

        return false;
    }

    public void ResetHomeless()
    {
        for (int c = 0; c < this.AllHomeLess.Count && c < this.HungerStartValues.Count; c++)
        {
            var homeless = this.AllHomeLess[c];
            homeless.currentHunger = this.HungerStartValues[c];
        }
    }
}