using UnityEngine;

public class CuttingBoard : MonoBehaviour
{
    public static CuttingBoard Current;

    public BoxCollider OwnCollider;
    
    private void Start()
    {
        Current = this;
    }
}