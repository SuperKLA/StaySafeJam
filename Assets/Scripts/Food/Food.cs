using UnityEngine;

public class Food : MonoBehaviour
{
    public DraggableRecevoir Draggable;
    public Rigidbody         OwnRigidBody;
    public MeshCollider      OwnCollider;
    public MeshFilter        OwnMeshfilter;

    public string       name;
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
        
        this.OwnRigidBody.angularVelocity = Vector3.zero;
        this.OwnRigidBody.velocity        = Vector3.zero;

        this.OwnRigidBody.useGravity       = false;
        this.OwnRigidBody.detectCollisions = false;
    }
}