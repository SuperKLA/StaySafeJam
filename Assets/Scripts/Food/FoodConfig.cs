using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodConfig : MonoBehaviour
{
    [SerializeField]
    List<Food> foodList = new List<Food>();

    public List<Food> GetFoodList()
    {
        return foodList;
    }
}
