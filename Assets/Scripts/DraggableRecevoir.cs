using System;
using UnityEngine;

public class DraggableRecevoir : MonoBehaviour
{
    public event Action OnDragEnabled;
    public event Action OnDragEnd;

    public Bounds? MaxMoveBounds;
    public Vector3 Offset = new Vector3(0,0.2f,0);
    
    public void OnDragStarting()
    {
        if (this.OnDragEnabled != null) this.OnDragEnabled();
    }

    public void OnDragEnding()
    {
        if (this.OnDragEnd != null) this.OnDragEnd();
    }

}