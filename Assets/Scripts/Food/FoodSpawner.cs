using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FoodSelector))]
public class FoodSpawner : MonoBehaviour
{
    public bool test = false;
    public Transform SpawnPosition;

    FoodSelector foodSelector;

    void Start()
    {
        this.foodSelector = this.GetComponent<FoodSelector>();
    }


    private void Update()
    {
        if (this.test)
        {
            this.test = false;
            this.SpawnFood();
        }
    }


    public Food SpawnFood()
    {
        Food nextFood = this.foodSelector.GetFood();
        if (nextFood != null)
            Instantiate(nextFood.gameObject, this.SpawnPosition.position, this.GetRandomRotation());

        return nextFood;
    }


    private Quaternion GetRandomRotation()
    {
        return new Quaternion(Quaternion.identity.x, Random.Range(0.0f, 1.0f), Quaternion.identity.z, Quaternion.identity.w);
    }
}
