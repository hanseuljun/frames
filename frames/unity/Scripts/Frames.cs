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
            return new Frames(new List<Frame>());
        }

        public void AddFrame(Frame frame)
        {
            frames.Add(frame);
        }

        public string ToJson()
        {
            string result = "";

            foreach (var frame in frames)
            {
                result += JsonConvert.SerializeObject(frame, Formatting.Indented, new FrameJsonConverter());
            }

            return result;
        }
    }
}