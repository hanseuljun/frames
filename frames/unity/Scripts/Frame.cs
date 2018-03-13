using System;
using System.Collections.Generic;

namespace Frames
{
    public class Frame
    {
        private Dictionary<Type, List<ComponentFrame>> dictionary;

        public Frame()
        {
            dictionary = new Dictionary<Type, List<ComponentFrame>>();
        }

        public void AddComponentFrame(ComponentFrame componentFrame)
        {
            var type = componentFrame.GetType();
            List<ComponentFrame> componentFrames;
            if (!dictionary.TryGetValue(type, out componentFrames))
            {
                componentFrames = new List<ComponentFrame>();
                dictionary.Add(type, componentFrames);
            }
            componentFrames.Add(componentFrame);
        }

        public Dictionary<Type, List<ComponentFrame>> ToDictionary()
        {
            return dictionary;
        }
    }
}