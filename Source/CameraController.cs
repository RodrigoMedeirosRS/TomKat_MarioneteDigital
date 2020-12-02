using Godot;
using BLL;

public class CameraController : Camera
{
    private Sprite CameraOFF { get; set; }
    public override void _Ready()
    {
        CameraOFF = GetChild<Sprite>(0);
    }

    public override void _Process(float delta)
    {
        if (InputEventBll.GetKey(InputAction.CameraOff, KeyStatus.Pressed))
            CameraOFF.Visible = !CameraOFF.Visible;
    }
}
