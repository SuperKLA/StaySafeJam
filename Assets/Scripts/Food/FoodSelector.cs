using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSelector : MonoBehaviour
{
    public FoodConfig foodConfig;

    private List<Food> notEatenFoods = new List<Food>();

    void Start()
    {
        notEatenFoods.AddRange(foodConfig.foodList);
    }

    public Food GetFood()
    {
        if (notEatenFoods.Count == 0)
            return null;
        int index = Random.Range(0, notEatenFoods.Count - 1);
        Food selectedFood = notEatenFoods[index];
        notEatenFoods.RemoveAt(index);
        return selectedFood;
    }
}
