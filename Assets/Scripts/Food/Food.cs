using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public DraggableRecevoir Draggable;
    public Rigidbody OwnRigidBody;
    public MeshCollider OwnCollider;
    
    public string name;
    public FoodCategory category;
    public float Calories;
    public GameObject foodPrefab;
    
    private void Start()
    {
        this.Draggable.OnDragEnabled += this.OnDragEnabled;
        this.Draggable.OnDragEnd     += this.OnDragEnd;
    }

    private void OnDragEnd()
    {
        this.OwnRigidBody.useGravity = true;
        this.OwnRigidBody.detectCollisions = true;
    }

    private void OnDragEnabled()
    {
        this.OwnRigidBody.angularVelocity = Vector3.zero;
        this.OwnRigidBody.velocity        = Vector3.zero;
        
        this.OwnRigidBody.useGravity = false;
        this.OwnRigidBody.detectCollisions = false;
    }
}
