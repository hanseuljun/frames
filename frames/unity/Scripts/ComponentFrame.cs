namespace Frames
{
    public interface ComponentFrame
    {
        JsonComponentFrame ToJsonComponent();
        string ToJsonString();
    }
}