using UnityEngine;
using Newtonsoft.Json;

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

        public JsonComponentFrame ToJsonComponent()
        {
            return new JsonTransformFrame(position, rotation, scale);
        }

        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(ToJsonComponent());
        }
    }
}