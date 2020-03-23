using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject CubePrefab;
    public int Size = 5;

    private void Start()
    {
        Generate();
    }

    private float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }

    private void Generate()
    {
        var maxDist = Mathf.Sqrt(2) * Size / 2;
        for (int x = 0; x < Size; x++)
        {
            for (int y = 0; y < Size; y++)
            {
                Vector3 pos = new Vector3(-Size / 2 + .5f + x, 0, -Size / 2 + .5f + y);
                Transform newCube = Instantiate(CubePrefab, pos, Quaternion.identity).transform as Transform;
                newCube.parent = transform;
                var dist = Mathf.Sqrt((x - Size / 2) * (x - Size / 2) + (y - Size / 2) * (y - Size / 2));
                newCube.GetComponent<Cube>().Angle += Remap(dist, 0, maxDist, -2f, 2f);
            }
        }
    }
}
