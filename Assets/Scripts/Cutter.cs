using EzySlice;
using UnityEngine;
using Plane = UnityEngine.Plane;

public class Cutter : MonoBehaviour
{
    public static Cutter Current;
    
    public GameObject plane;
    public Transform ObjectContainer;

    // How far away from the slice do we separate resulting objects
    public float   separation;
    // Do we draw a plane object associated with the slice
    private Plane slicePlane = new Plane();

    private MeshCutter meshCutter;
    private TempMesh   biggerMesh, smallerMesh;
    public Material Banana;

    // Start is called before the first frame update
    void Start()
    {
        meshCutter = new MeshCutter(256);
        Current = this;
    }
    
    public void Cut(Vector3 position, Vector3 normal, params GameObject[] cutThis)
    {
        //SliceObjects(position, normal, cutThis);

        for (int c = 0; c < cutThis.Length; c++)
        {
            var cutObj = cutThis[c];
            var cutObjFood = cutObj.GetComponent<Food>();
            var material = cutObjFood.OwnMaterial;

            GameObject[] pieces;
            if (cutObjFood.InnerTexture != null)
            {
                var textureRegion = material.GetTextureRegion(0, 0, 1024, 1024);
                pieces = SlicerExtensions.SliceInstantiate(cutObj, position, normal, textureRegion, material);
            }
            else
            {
                pieces = SlicerExtensions.SliceInstantiate(cutObj, position, normal, material);
            }

            if (pieces == null) continue;
            
            for (int i = 0; i < pieces.Length; i++)
            {
                var piece = pieces[i];
                piece.name = cutObjFood.name;
                piece.transform.position = cutObj.transform.position;
                
                var collider = piece.AddComponent<MeshCollider>();
                collider.convex = true;
                
                var rigid = piece.AddComponent<Rigidbody>();
                var drag = piece.AddComponent<DraggableRecevoir>();
                
                rigid.angularVelocity = Vector3.zero;
                rigid.velocity = Vector3.zero;

                var meshfilter = piece.GetComponent<MeshFilter>();
                var volume = Utils.VolumeOfMesh(meshfilter.mesh);
                var partFactor = volume / cutObjFood.Volume;
                
                var food = piece.AddComponent<Food>();
                food.OwnCollider = collider;
                food.OwnRigidBody = rigid;
                food.OwnMeshfilter = meshfilter;
                food.OwnMaterial = cutObjFood.OwnMaterial;
                food.InnerTexture = cutObjFood.InnerTexture;
                food.name = cutObjFood.name;
                food.Volume = volume;
                food.Calories = cutObjFood.Calories * partFactor;
                food.category = cutObjFood.category;
                food.Draggable = drag;
                
                piece.tag = "Sliceable";
                
            }
            
            Destroy(cutObj);
        }
    }

   
    
    // void DrawPlane(Vector3 start, Vector3 end, Vector3 normalVec)
    // {
    //     Quaternion rotate = Quaternion.FromToRotation(Vector3.up, normalVec);
    //
    //     plane.transform.localRotation = rotate;
    //     plane.transform.position      = (end + start) / 2;
    //     plane.SetActive(true);
    // }
    //
}