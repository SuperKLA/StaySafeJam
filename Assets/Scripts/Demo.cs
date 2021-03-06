﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    public LineRenderer OwnLineRenderer;
    public Transform ObjectContainer;
    // How far away from the slice do we separate resulting objects
    public float separation;
    public Vector3 NormalDirCutPlane = Vector3.forward;

    // Do we draw a plane object associated with the slice
    private Plane slicePlane = new Plane();    
    
    private MeshCutter meshCutter;
    private TempMesh biggerMesh, smallerMesh;
    
    // Start is called before the first frame update
    void Start()
    {
        meshCutter = new MeshCutter(256);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("CutMe")]
    void CutMe()
    {
        var pointOnCutPlane0 = OwnLineRenderer.GetPosition(0);
        var pointOnCutPlane1 = OwnLineRenderer.GetPosition(1);
        var dir = (pointOnCutPlane0 - pointOnCutPlane1).normalized;
        
        var normalVec = Vector3.Cross(dir, Vector3.up);

        SliceObjects(pointOnCutPlane0, normalVec);
    }
    
    void SliceObjects(Vector3 point, Vector3 normal)
    {
        var toSlice = GameObject.FindGameObjectsWithTag("Sliceable");

        // Put results in positive and negative array so that we separate all meshes if there was a cut made
        List<Transform> positive = new List<Transform>(),
            negative = new List<Transform>();

        GameObject obj;
        bool slicedAny = false;
        for (int i = 0; i < toSlice.Length; ++i)
        {
            obj = toSlice[i];
            // We multiply by the inverse transpose of the worldToLocal Matrix, a.k.a the transpose of the localToWorld Matrix
            // Since this is how normal are transformed
            var transformedNormal = ((Vector3)(obj.transform.localToWorldMatrix.transpose * normal)).normalized;

            //Convert plane in object's local frame
            slicePlane.SetNormalAndPosition(
                transformedNormal,
                obj.transform.InverseTransformPoint(point));

            slicedAny = SliceObject(ref slicePlane, obj, positive, negative) || slicedAny;
        }

        // Separate meshes if a slice was made
        if (slicedAny)
            SeparateMeshes(positive, negative, normal);
    }

    bool SliceObject(ref Plane slicePlane, GameObject obj, List<Transform> positiveObjects, List<Transform> negativeObjects)
    {
        var mesh = obj.GetComponent<MeshFilter>().mesh;

        if (!meshCutter.SliceMesh(mesh, ref slicePlane))
        {
            // Put object in the respective list
            if (slicePlane.GetDistanceToPoint(meshCutter.GetFirstVertex()) >= 0)
                positiveObjects.Add(obj.transform);
            else
                negativeObjects.Add(obj.transform);

            return false;
        }

        // TODO: Update center of mass

        // Silly condition that labels which mesh is bigger to keep the bigger mesh in the original gameobject
        bool posBigger = meshCutter.PositiveMesh.surfacearea > meshCutter.NegativeMesh.surfacearea;
        if (posBigger)
        {
            biggerMesh = meshCutter.PositiveMesh;
            smallerMesh = meshCutter.NegativeMesh;
        }
        else
        {
            biggerMesh = meshCutter.NegativeMesh;
            smallerMesh = meshCutter.PositiveMesh;
        }

        // Create new Sliced object with the other mesh
        GameObject newObject = Instantiate(obj, ObjectContainer);
        newObject.transform.SetPositionAndRotation(obj.transform.position, obj.transform.rotation);
        var newObjMesh = newObject.GetComponent<MeshFilter>().mesh;

        // Put the bigger mesh in the original object
        // TODO: Enable collider generation (either the exact mesh or compute smallest enclosing sphere)
        ReplaceMesh(mesh, biggerMesh);
        ReplaceMesh(newObjMesh, smallerMesh);

        (posBigger ? positiveObjects : negativeObjects).Add(obj.transform);
        (posBigger ? negativeObjects : positiveObjects).Add(newObject.transform);

        return true;
    }


    /// <summary>
    /// Replace the mesh with tempMesh.
    /// </summary>
    void ReplaceMesh(Mesh mesh, TempMesh tempMesh, MeshCollider collider = null)
    {
        mesh.Clear();
        mesh.SetVertices(tempMesh.vertices);
        mesh.SetTriangles(tempMesh.triangles, 0);
        mesh.SetNormals(tempMesh.normals);
        mesh.SetUVs(0, tempMesh.uvs);
        
        //mesh.RecalculateNormals();
        mesh.RecalculateTangents();

        if (collider != null && collider.enabled)
        {
            collider.sharedMesh = mesh;
            collider.convex = true;
        }
    }

    void SeparateMeshes(Transform posTransform, Transform negTransform, Vector3 localPlaneNormal)
    {
        // Bring back normal in world space
        Vector3 worldNormal = ((Vector3)(posTransform.worldToLocalMatrix.transpose * localPlaneNormal)).normalized;

        Vector3 separationVec = worldNormal * separation;
        // Transform direction in world coordinates
        posTransform.position += separationVec;
        negTransform.position -= separationVec;
    }

    void SeparateMeshes(List<Transform> positives, List<Transform> negatives, Vector3 worldPlaneNormal)
    {
        int i;
        var separationVector = worldPlaneNormal * separation;

        for(i = 0; i <positives.Count; ++i)
            positives[i].transform.position += separationVector;

        for (i = 0; i < negatives.Count; ++i)
            negatives[i].transform.position -= separationVector;
    }
}
