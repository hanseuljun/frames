using UnityEngine;
using Frames;

public class Tester : MonoBehaviour
{
    public TestAnimator testAnimator;
    public TestReplayer testReplayer;
    private Frames.Frames frames;
    private bool record;

    private void Start()
    {
        testAnimator.Play();
        frames = new Frames.Frames();
        record = true;
    }

    private void Update()
    {
        if(record && Time.time > 2.0f)
        {
            record = false;
            testAnimator.Stop();
            testReplayer.Replay(frames);
        }

        if(record)
        {
            var transform = testAnimator.transform;
            var transformFrame = new TransformFrame(transform.localPosition,
                                                    transform.localRotation,
                                                    transform.localScale);

            var frame = new Frame();
            frame.AddComponentFrame(transformFrame);

            frames.AddFrame(frame);
        }
    }
}