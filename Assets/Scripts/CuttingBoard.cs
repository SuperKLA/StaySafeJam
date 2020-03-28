using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    public static CuttingBoard Current;

    public GameObject FoodOnCutBoard;
    
    private void Start()
    {
        Current = this;
    }
}