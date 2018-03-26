using UnityEngine;

public class TestAnimator : MonoBehaviour
{
    private bool play;

    private void Awake()
    {
        play = false;
    }

    private void Update()
    {
        if(!play)
        {
            return;
        }
        transform.localPosition = new Vector3(Mathf.Cos(Time.time * 3.0f), Mathf.Sin(Time.time * 3.0f));
    }

    public void Play()
    {
        play = true;
    }

    public void Stop()
    {
        play = false;
    }
}
