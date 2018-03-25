using System;
using Newtonsoft.Json;

namespace Frames
{
    public class FrameJsonConverter : JsonConverter
    {
        public FrameJsonConverter(params Type[] types)
        {
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            Frame frame = (Frame)value;
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
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Frame);
        }
    }
}