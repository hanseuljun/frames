using UnityEngine;

namespace Frames
{
    public struct JsonVector3
    {
        public float x;
        public float y;
        public float z;

        public JsonVector3(Vector3 vector3)
        {
            x = vector3.x;
            y = vector3.y;
            z = vector3.z;
        }
    }
}
