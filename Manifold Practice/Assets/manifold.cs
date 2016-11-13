using UnityEngine;
using System.Collections;

public class manifold : MonoBehaviour
{
    public Material mat;

    private Mesh createLine(Vector3 start, Vector3 end)
    {
        float h = .05f;
        Vector3[] vert = new Vector3[4];
        vert[0] = start;

        float dy = end.y - start.y;
        float dx = end.x - start.x;

        float m = dy / dx;
        float hx = h * h / (1 + 1 / (m * m));
        float hy = -1 / m * hx;

        vert[1] = new Vector3(start.x+hx, start.y+hy, start.z);//1
        vert[2] = new Vector3(end.x + hx, end.y + hy, end.z);//1
        
        vert[3] = end;



        int[] tris = new int[] {
            0 , 1 , 3,
            1 , 2 , 3
        };


        Mesh mesh = new Mesh();
        mesh.vertices = vert;
        mesh.triangles = tris;

        mesh.RecalculateNormals();

        return mesh;
    }

    private void Start()
    {
        //Create Vertices
               Vector3[] vert = new Vector3[9];
               vert[0] = new Vector3(0.25f, 0.02f, 0.0f);//0
               vert[1] = new Vector3(0.25f, 0.03f, 1.0f);//1
               vert[2] = new Vector3(0.25f, 0.04f, 2.0f);//2

               vert[3] = new Vector3(0.50f, 0.21f, 0.0f);//3
               vert[4] = new Vector3(0.50f, 0.31f, 1.0f);//4
               vert[5] = new Vector3(0.50f, 0.41f, 2.0f);//5

               vert[6] = new Vector3(1, 0.22f, 0.0f);//6
               vert[7] = new Vector3(1, 0.32f, 1.0f);//7
               vert[8] = new Vector3(1, 0.42f, 2.0f);//8



        //Create the triangles using the vertices
        int[] tris = new int[24];
        tris[0] = 0;
        tris[1] = 1;
        tris[2] = 2;

        tris[3] = 0;
        tris[4] = 2;
        tris[5] = 3;

        tris[6] = 3;
        tris[7] = 2;
        tris[8] = 4;

        tris[9] = 3;
        tris[10] = 4;
        tris[11] = 5;

        tris[12] = 1;
        tris[13] = 6;
        tris[14] = 7;

        tris[15] = 1;
        tris[16] = 7;
        tris[17] = 2;

        tris[18] = 2;
        tris[19] = 7;
        tris[20] = 8;

        tris[21] = 2;
        tris[22] = 8;
        tris[23] = 4;



        //Create a new mesh and pass down the vertices and triangles
        Mesh mesh = new Mesh();
        mesh.vertices = vert;
        mesh.triangles = tris;

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