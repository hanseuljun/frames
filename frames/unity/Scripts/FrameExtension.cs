using System;
using UnityEngine;

namespace Frames
{
    public static class FrameExtension
    {
        public static TransformFrame GetFrame(this Transform transform, CoordinateSystem coordinateSystem = CoordinateSystem.Local)
        {
            switch(coordinateSystem)
            {
                case CoordinateSystem.Local:
                    return new TransformFrame(transform.localPosition, transform.localRotation, transform.localScale);
                case CoordinateSystem.Global:
                    return new TransformFrame(transform.position, transform.rotation, transform.lossyScale);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}