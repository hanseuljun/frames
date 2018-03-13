using UnityEngine;

namespace Frames
{
    public struct JsonTransformFrame : JsonComponentFrame
    {
        public JsonVector3 position;
        public JsonQuaternion rotation;
        public JsonVector3 scale;

        public JsonTransformFrame(Vector3 position,
                                  Quaternion rotation,
                                  Vector3 scale)
        {
            this.position = new JsonVector3(position);
            this.rotation = new JsonQuaternion(rotation);
            this.scale = new JsonVector3(scale);
        }
    }
}