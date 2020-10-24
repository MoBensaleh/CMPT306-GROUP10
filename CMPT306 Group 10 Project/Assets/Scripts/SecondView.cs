using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondView : MonoBehaviour
{
    private Mesh mesh;

    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRadius = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRadius), Mathf.Sin(angleRadius));
    }
    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    // Update is called once per frame
    private void Update()
    {
        float fov = 90f;
        Vector3 origin = Vector3.zero;
        int rayCount = 50;
        float angle = 0f;
        float angleIncrease = fov / rayCount;
        float viewDistance = 5f;

        Vector3[] vertices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            RaycastHit2D rayCast = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance);

            if (rayCast.collider) vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            else vertex = rayCast.point;

            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;

        }

        vertices[0] = origin;
        vertices[1] = new Vector3(5, 0);
        vertices[2] = new Vector3(0, -5);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }
}
