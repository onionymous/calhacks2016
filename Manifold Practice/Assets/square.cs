using UnityEngine;
using System.Collections;

public class square : MonoBehaviour
{

    public Material mat;

    // Use this for initialization
    void Start()
    {
        Vector3[] vert = new Vector3[4] {
            new Vector3(-1 , 1 , 0),
            new Vector3(1 , 1 , 0),
            new Vector3(1 , -1 , 0),
            new Vector3(-1 , -1 , 0)
        };

        int[] tris = new int[] {
            0 , 1 , 2,
            0 , 2 , 3
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vert;
        mesh.triangles = tris;

        mesh.RecalculateNormals();

        if (!GetComponent<MeshFilter>())
            gameObject.AddComponent<MeshFilter>();

        if (!GetComponent<MeshRenderer>())
            gameObject.AddComponent<MeshRenderer>();

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = mat;

    }

}
