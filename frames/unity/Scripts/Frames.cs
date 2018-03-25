using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frames
{
    public class Frames
    {
        private List<Frame> frames;

        public Frames()
        {
            frames = new List<Frame>();
        }

        private Frames(List<Frame> frames)
        {
            this.frames = frames;
        }

        public static Frames FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Frames>(json, new FramesJsonConverter());
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented, new FramesJsonConverter());
        }

        public void AddFrame(Frame frame)
        {
            frames.Add(frame);
        }

        public List<Frame> ToList()
        {
            return frames;
        }
    }
}