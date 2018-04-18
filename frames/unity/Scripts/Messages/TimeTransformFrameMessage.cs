using UnityEngine.Networking;

namespace Frames
{
    public class TimeTransformFrameMessage : MessageBase
    {
        private float time;
        private TransformFrame transformFrame;

        public float Time
        {
            get
            {
                return time;
            }
        }

        public TransformFrame TransformFrame
        {
            get
            {
                return transformFrame;
            }
        }

        public TimeTransformFrameMessage()
        {
        }

        public TimeTransformFrameMessage(float time, TransformFrame transformFrame)
        {
            this.time = time;
            this.transformFrame = transformFrame;
        }

        public override void Serialize(NetworkWriter writer)
        {
            writer.Write(time);
            writer.Write(transformFrame.GetPosition());
            writer.Write(transformFrame.GetRotation());
            writer.Write(transformFrame.GetScale());
        }

        public override void Deserialize(NetworkReader reader)
        {
            time = reader.ReadSingle();
            var position = reader.ReadVector3();
            var rotation = reader.ReadQuaternion();
            var scale = reader.ReadVector3();
            transformFrame = new TransformFrame(position, rotation, scale);
        }
    }
}