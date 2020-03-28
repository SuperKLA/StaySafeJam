using UnityEngine;

public static class Utils
{
    public static float SignedVolumeOfTriangle(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float v321 = p3.x * p2.y * p1.z;
        float v231 = p2.x * p3.y * p1.z;
        float v312 = p3.x * p1.y * p2.z;
        float v132 = p1.x * p3.y * p2.z;
        float v213 = p2.x * p1.y * p3.z;
        float v123 = p1.x * p2.y * p3.z;
        return (1.0f / 6.0f) * (-v321 + v231 + v312 - v132 - v213 + v123);
    }
    public static float VolumeOfMesh(Mesh mesh)
    {
        float     volume    = 0;
        Vector3[] vertices  = mesh.vertices;
        int[]     triangles = mesh.triangles;
        for (int i = 0; i < mesh.triangles.Length; i += 3)
        {
            Vector3 p1 = vertices[triangles[i + 0]];
            Vector3 p2 = vertices[triangles[i + 1]];
            Vector3 p3 = vertices[triangles[i + 2]];
            volume += SignedVolumeOfTriangle(p1, p2, p3);
        }
        return Mathf.Abs(volume)*100; //100 um Rundungsfehler zu reduzieren
    }
    
    public static float SignedVolumeOfTriangle2(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 o)
    {
        Vector3 v1 = p1 - o;
        Vector3 v2 = p2 - o;
        Vector3 v3 = p3 - o;
 
        return Vector3.Dot(Vector3.Cross(v1, v2), v3) / 6f; ;
    }
 
    public static float VolumeOfMesh2(Mesh mesh)
    {
        float     volume    = 0;
        Vector3[] vertices  = mesh.vertices;
        int[]     triangles = mesh.triangles;
 
        Vector3 o = new Vector3(0f, 0f, 0f);
        // Computing the center mass of the polyhedron as the fourth element of each mesh
        for (int i = 0; i < mesh.triangles.Length; i++)
        {
            o += vertices[triangles[i]];
        }
        o = o / mesh.triangles.Length;
 
        // Computing the sum of the volumes of all the sub-polyhedrons
        for (int i = 0; i < mesh.triangles.Length; i += 3)
        {
            Vector3 p1 = vertices[triangles[i + 0]];
            Vector3 p2 = vertices[triangles[i + 1]];
            Vector3 p3 = vertices[triangles[i + 2]];
            volume += SignedVolumeOfTriangle2(p1, p2, p3, o);
        }
        return Mathf.Abs(volume);
    }
}