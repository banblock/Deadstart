using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[System.Serializable]
public class PRS
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;

    public PRS(Vector3 pos, Quaternion rot, Vector3 scale)
    {
        this.position = pos;
        this.rotation = rot;
        this.scale = scale;
    }
}


public class UMath
{
    public static float Base(float hypo, float under)
    {
        return (Mathf.Sqrt(Mathf.Pow(hypo, 2) - Mathf.Pow(under, 2)));
    }
}

public class Utills
{
    public static Quaternion QI => Quaternion.identity;

    public static Vector3 MousePointer {
        get {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = -9;
            return pos;
        }
    }

}
