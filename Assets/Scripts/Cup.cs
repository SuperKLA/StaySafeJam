using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    public List<Food> FoodInCup = new List<Food>();
    
    
    private void OnCollisionEnter(Collision other)
    {
        var food = other.gameObject.GetComponent<Food>();
        if (food == null) return;
        
        this.FoodInCup.Add(food);
    }

    private void OnCollisionExit(Collision other)
    {
        var food = other.gameObject.GetComponent<Food>();
        if (food == null) return;
        
        this.FoodInCup.Remove(food);
    }
}