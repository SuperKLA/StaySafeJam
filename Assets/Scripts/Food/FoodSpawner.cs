using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FoodSelector))]
public class FoodSpawner : MonoBehaviour
{
    public bool test = false;

    FoodSelector foodSelector;

    void Start()
    {
        foodSelector = GetComponent<FoodSelector>();
    }


    private void Update()
    {
        if (test)
        {
            test = false;
            SpawnFood();
        }
    }


    public Food SpawnFood()
    {
        Food nextFood = foodSelector.GetFood();
        if (nextFood != null)
            Instantiate(nextFood.gameObject, Vector3.zero, Quaternion.identity);
        return nextFood;
    }

}
