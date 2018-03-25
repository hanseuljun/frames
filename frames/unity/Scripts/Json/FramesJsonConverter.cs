using System;
using UnityEngine;
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
            Debug.Log("FramesJsonConverter.ReadJson 1");
            JObject jsonObject = JObject.Load(reader);
            Debug.Log("FramesJsonConverter.ReadJson 2");
            return new Frames();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Frames);
        }
    }
}