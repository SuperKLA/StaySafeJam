using System.Collections.Generic;
using UnityEngine;

public class Cup : MonoBehaviour
{
    public List<Food>   FoodInCup = new List<Food>();
    public string       HomeLessId;
    public LineRenderer SlideIntoFrontPath;
    public Vector3      StartPosition;
    public float        DropValue;

    public Vector3 TargetDropFoodLocation
    {
        get
        {
            var end = this.SlideIntoFrontPath.GetPosition(1);
            return this.StartPosition + end;
        }
    }

    private void Start()
    {
        this.StartPosition = transform.position;
    }

    private void OnCollisionEnter(Collision other)
    {
        var food = other.gameObject.GetComponent<Food>();
        if (food == null) return;

        CupComeCloserManager.Current.IsHoldingFood = false;

        this.FoodInCup.Add(food);
        food.transform.SetParent(this.transform);

        food.OwnRigidBody.angularVelocity = Vector3.zero;
        food.OwnRigidBody.velocity        = Vector3.zero;
    }

    private void OnCollisionExit(Collision other)
    {
        var food = other.gameObject.GetComponent<Food>();
        if (food == null) return;

        var position = food.transform.position;

        this.FoodInCup.Remove(food);
        food.transform.parent   = null;
        food.transform.position = position;
    }

    public void OnFoodIsComingCloser(float _value)
    {
        var start = this.SlideIntoFrontPath.GetPosition(0);
        var end   = this.SlideIntoFrontPath.GetPosition(1);
        var value = Vector3.Lerp(start, end, _value);

        this.transform.position = this.StartPosition + value;
        this.DropValue          = _value;
    }

    public void Update()
    {
        if (DropValue == 0) return;
        if (CupComeCloserManager.Current.IsHoldingFood) return;

        OnFoodIsComingCloser(this.DropValue - Time.deltaTime);
        //
        // if (DropValue >= 0) return;
        //
        // for (int c = 0; c < this.FoodInCup.Count; c++)
        // {
        //     var food = this.FoodInCup[c];
        //     if (food == null) continue;
        //
        //     food.transform.parent = null;
        // }
    }
}