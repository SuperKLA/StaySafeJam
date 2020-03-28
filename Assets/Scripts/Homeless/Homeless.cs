using System;
using UnityEngine;

public class Homeless : MonoBehaviour
{
    public string  Name;
    public float   WellFedValue;
    public Vector2 HungerIncrease;

    public void OnValidate()
    {
        if (String.IsNullOrEmpty(this.Name)) return;

        this.gameObject.name = this.Name;
    }
}