using System.Collections.Generic;

namespace Frames
{
    public class JsonFrames
    {
        private string json;

        public JsonFrames(string json)
        {
            this.json = json;
        }

        public List<Frame> ToFrames()
        {
            var frames = new List<Frame>();

            return frames;
        }
    }
}