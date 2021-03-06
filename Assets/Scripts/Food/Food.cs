﻿using UnityEngine;

[RequireComponent(typeof(DraggableRecevoir))]
public class Food : MonoBehaviour
{
    public DraggableRecevoir Draggable;
    public Rigidbody         OwnRigidBody;
    public MeshCollider      OwnCollider;
    public MeshFilter        OwnMeshfilter;
    public Texture           InnerTexture;
    public Material          OwnMaterial;

    public string       name;
    public string CutSound;
    public FoodCategory category;
    public float        Calories;
    public float        Volume;

    [ContextMenu("CalculateMeshVolume")]
    private void CalculateMeshVolume()
    {
        this.Volume = Utils.VolumeOfMesh(OwnMeshfilter.sharedMesh);
        Debug.Log("CalculateMeshVolume abgeschlossen");
    }


    private void Start()
    {
        this.Draggable.OnDragEnabled += this.OnDragEnabled;
        this.Draggable.OnDragEnd     += this.OnDragEnd;
    }

    private void OnDragEnd()
    {
        CupComeCloserManager.Current.DisableComeCloser();

        this.OwnRigidBody.useGravity       = true;
        this.OwnRigidBody.detectCollisions = true;
    }

    private void OnDragEnabled()
    {
        CupComeCloserManager.Current.SetCupComeCloser(this.gameObject);
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/sfx_food_pickup", this.transform.position);

        this.OwnRigidBody.angularVelocity = Vector3.zero;
        this.OwnRigidBody.velocity        = Vector3.zero;

        this.OwnRigidBody.useGravity       = false;
        this.OwnRigidBody.detectCollisions = false;
    }
}