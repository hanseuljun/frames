using UnityEngine;
using Frames;

public class Tester : MonoBehaviour
{
    public void Start()
    {
        var frame = new Frame();
        frame.AddComponentFrame(new TransformFrame(Vector3.up, Quaternion.identity, Vector3.one * 2.0f));
        frame.AddComponentFrame(new TransformFrame(Vector3.down, Quaternion.identity, Vector3.one * 1.0f));

        var frames1 = new Frames.Frames();
        frames1.AddFrame(frame);
        string json = frames1.ToJson();
        print(json);

        var frames2 = Frames.Frames.FromJson(json);
        print("frames2:" + frames2.ToList().Count);
    }
}
