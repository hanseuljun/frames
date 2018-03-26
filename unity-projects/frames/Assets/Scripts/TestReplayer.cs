using UnityEngine;
using Frames;

public class TestReplayer : MonoBehaviour
{
    private bool replay;
    private Frames.Frames frames;
    private int frameIndex;

    private void Awake()
    {
        replay = false;
    }

    private void Update()
    {
        if(!replay)
        {
            return;
        }

        var frameList = frames.ToList();
        if(frameIndex < frameList.Count)
        {
            var frame = frameList[frameIndex++];
            var frameComponentDictionary = frame.ToDictionary();
            var transformFrame = (TransformFrame)frameComponentDictionary[typeof(TransformFrame)][0];
            transform.localPosition = transformFrame.GetPosition();
            transform.localRotation = transformFrame.GetRotation();
            transform.localScale = transformFrame.GetScale();
        }
    }

    public void Replay(Frames.Frames frames)
    {
        replay = true;
        this.frames = frames;
        frameIndex = 0;
        print("frames length: " + frames.ToList().Count);
    }
}
