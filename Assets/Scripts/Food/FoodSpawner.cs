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
            Instantiate(nextFood.gameObject, Vector3.zero, GetRandomRotation());

        return nextFood;
    }


    private Quaternion GetRandomRotation()
    {
        return new Quaternion(Quaternion.identity.x, Random.Range(0.0f, 1.0f), Quaternion.identity.z, Quaternion.identity.w);
    }
}
