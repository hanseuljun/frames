using System.Collections.Generic;
using Newtonsoft.Json;

namespace Frames
{
    public class Encoder
    {
        private List<Frame> frames;
        
        public Encoder()
        {
            frames = new List<Frame>();
        }

        public void AddFrame(Frame frame)
        {
            frames.Add(frame);
        }

        public string Print()
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