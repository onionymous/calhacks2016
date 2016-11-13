using UnityEngine;
using System.Collections;

public class square2 : MonoBehaviour
{
    public Material mat;

    private void Start()
    {
        //Create 4 Vertices
        Vector3[] vert = new Vector3[4];
        vert[0] = new Vector3(-1, 1, 0);//0
        vert[1] = new Vector3(1, 1, 0);//1
        vert[2] = new Vector3(1, -1, 0);//2
        vert[3] = new Vector3(-1, -1, 0);//3

        //Create the triangles using the vertices
        int[] tris = new int[6];
        tris[0] = 0;
        tris[1] = 1;
        tris[2] = 2;
        tris[3] = 0;
        tris[4] = 2;
        tris[5] = 3;

        //Create a new mesh and pass down the vertices and triangles
        Mesh mesh = new Mesh();
        mesh.vertices = vert;
        mesh.triangles = tris;

        mesh.RecalculateNormals();

        //Make sure mesh filter and mesh renderer componenets are attached
        if (!GetComponent<MeshFilter>())
            gameObject.AddComponent<MeshFilter>();

        if (!GetComponent<MeshRenderer>())
            gameObject.AddComponent<MeshRenderer>();

        //Pass down the mesh data to mesh filter
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        //Send material data to mesh renderer
        gameObject.GetComponent<MeshRenderer>().material = mat;
    }
}