using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupComeCloserManager : MonoBehaviour
{
    public static CupComeCloserManager Current;
    
    public List<Cup> Cups = new List<Cup>();
    public GameObject Target;
    public float DistanceThreshold;
    public bool IsHoldingFood;

    private void Start()
    {
        Current = this;
    }

    public void SetCupComeCloser(GameObject obj)
    {
        IsHoldingFood = true;
        this.Target = obj;
    }
    
    public void DisableComeCloser()
    {
        this.Target = null;
    }

    private void Update()
    {
        if (this.Target == null) return;

        for (int c = 0; c < this.Cups.Count; c++)
        {
            var cup = this.Cups[c];
            var cupData = cup.GetComponent<Cup>();
            var position = cupData.TargetDropFoodLocation;
            var targetPosition = this.Target.transform.position;
            
            targetPosition.y = position.y = 0;
            
            var dis = Vector3.Distance(position, targetPosition);
            if (dis < this.DistanceThreshold)
            {
                var value = Mathf.Clamp01(1 - (dis / this.DistanceThreshold));
                cup.OnFoodIsComingCloser(value);
            }
            else
            {
                cup.OnFoodIsComingCloser(0);
            }
        }
    }
}