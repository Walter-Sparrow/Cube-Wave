using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [HideInInspector] public float Angle;
    public Vector2 HeightMinMax = new Vector2(5f, 20f);
    public float Speed = .05f;
    private float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
    private void Update()
    {
        var height = Remap(Mathf.Sin(Angle), -1, 1, HeightMinMax.x, HeightMinMax.y);
        Vector3 newSize = new Vector3(transform.localScale.x, height, transform.localScale.z);
        transform.localScale = newSize;
        Angle += Speed;
    }
}
