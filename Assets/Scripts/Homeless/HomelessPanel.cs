using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Homeless Panel", menuName ="Homeless")]
public class HomelessPanel : ScriptableObject
{
    public Sprite portrait;
    public string homelessName;
    public float hunger;
}
