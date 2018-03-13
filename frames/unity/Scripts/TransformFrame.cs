using UnityEngine;

namespace Frames
{
    public class TransformFrame : ComponentFrame
    {
        private Vector3 position;
        private Quaternion rotation;
        private Vector3 scale;

        public TransformFrame(Vector3 position,
                              Quaternion rotation,
                              Vector3 scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
        }

        public JsonComponentFrame ToJson()
        {
            return new JsonTransformFrame(position, rotation, scale);
        }
    }
}