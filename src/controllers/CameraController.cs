using Godot;

public partial class CameraController : Controller
{
    [Export]
    private int _moveSpeed = 400;

    [Export]
    private float _minZoom = 0.25f;

    [Export]
    private float _maxZoom = 2f;

    private Camera2D _camera;

    public override void Run()
    {
        _camera = GetNode<Camera2D>("/root/Main/World/Camera2D");
    }

    public override void _Process(double delta)
    {
        Vector2 movement = new Vector2();

        if (Input.IsActionPressed("CameraMoveUp"))
        {
            movement += Vector2.Up;
        }

        if (Input.IsActionPressed("CameraMoveLeft"))
        {
            movement += Vector2.Left;
        }

        if (Input.IsActionPressed("CameraMoveDown"))
        {
            movement += Vector2.Down;
        }

        if (Input.IsActionPressed("CameraMoveRight"))
        {
            movement += Vector2.Right;
        }

        _camera.Translate(movement * _moveSpeed * (float) delta);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed("CameraZoomIn"))
        {
            float zoom = Mathf.Min(_maxZoom, _camera.Zoom.X + 0.5f);
            _camera.Zoom = new Vector2(zoom, zoom);
        }
        else if (@event.IsActionPressed("CameraZoomOut"))
        {
            float zoom = Mathf.Max(_minZoom, _camera.Zoom.X - 0.5f);
            _camera.Zoom = new Vector2(zoom, zoom);
        }
    }
}
