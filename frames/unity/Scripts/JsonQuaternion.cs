using UnityEngine;

public class JsonQuaternion
{
    public float w;
    public float x;
    public float y;
    public float z;

    public JsonQuaternion(Quaternion quaternion)
    {
        w = quaternion.w;
        x = quaternion.x;
        y = quaternion.y;
        z = quaternion.z;
    }
}
