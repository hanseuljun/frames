using UnityEngine;
using Frames;

public class Tester : MonoBehaviour
{
    public void Start()
    {
        var frame = new Frame();
        frame.AddComponentFrame(new TransformFrame(Vector3.up, Quaternion.identity, Vector3.one * 2.0f));
        frame.AddComponentFrame(new TransformFrame(Vector3.down, Quaternion.identity, Vector3.one * 1.0f));

        var frames = new Frames.Frames();
        frames.AddFrame(frame);
        print(frames.ToJson());
    }
}
