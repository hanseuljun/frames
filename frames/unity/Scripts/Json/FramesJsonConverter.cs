using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Frames
{
    public class FramesJsonConverter : JsonConverter
    {
        public FramesJsonConverter()
        {
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Frames frames = (Frames)value;
            foreach(Frame frame in frames.ToList())
            {
                writer.WriteStartObject();
                writer.WritePropertyName(frame.GetType().ToString());
                writer.WriteStartArray();
                foreach (var componentFramePair in frame.ToDictionary())
                {
                    var type = componentFramePair.Key;
                    writer.WriteStartObject();
                    writer.WritePropertyName(type.ToString());
                    writer.WriteStartArray();
                    foreach (var componentFrame in componentFramePair.Value)
                    {
                        serializer.Serialize(writer, componentFrame.ToJsonComponent());
                    }
                    writer.WriteEndArray();
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
                writer.WriteEndObject();
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var frames = new Frames();

            // TODO: fix this
            var jFrames = JObject.Load(reader);
            var jFrameList = jFrames.GetValue(typeof(Frame).ToString());
            foreach (var jFrame in jFrameList.Children())
            {
                var frame = new Frame();
                foreach (var jFrameProperty in jFrame.Value<JObject>().Properties())
                {
                    if (jFrameProperty.Name == typeof(TransformFrame).ToString())
                    {
                        foreach (var jTransformFrame in jFrameProperty.Values())
                        {
                            var transformFrame = jTransformFrame.ToObject<JsonTransformFrame>()
                                                                .ToTransformFrame();
                            frame.AddComponentFrame(transformFrame);
                        }
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
                frames.AddFrame(frame);
            }

            return frames;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Frames);
        }
    }
}