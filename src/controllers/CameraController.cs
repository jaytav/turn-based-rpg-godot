using Godot;
using System;

public partial class CameraController : Controller
{
    [Export]
    private int moveSpeed = 10;

    [Export]
    private int rotationSpeed = 3;

    [Export]
    private int minZoom = 5;

    [Export]
    private int maxZoom = 20;

    private Camera3D _camera;
    private Node3D _cameraContainer;

    public override void Run()
    {
        _cameraContainer = GetNode<Node3D>("/root/Main/World/CameraContainer");
        _camera = _cameraContainer.GetNode<Camera3D>("Camera3D");
    }

    public override void _Process(double delta)
    {
        int rotateDirection = 0;
        Vector3 movement = new Vector3();

        if (Input.IsActionPressed("CameraRotateRight"))
        {
            rotateDirection -= 1;
        }

        if (Input.IsActionPressed("CameraRotateLeft"))
        {
            rotateDirection += 1;
        }

        if (Input.IsActionPressed("CameraMoveUp"))
        {
            movement += Vector3.Forward;
        }

        if (Input.IsActionPressed("CameraMoveLeft"))
        {
            movement += Vector3.Left;
        }

        if (Input.IsActionPressed("CameraMoveDown"))
        {
            movement += Vector3.Back;
        }

        if (Input.IsActionPressed("CameraMoveRight"))
        {
            movement += Vector3.Right;
        }

        _cameraContainer.RotateY(rotateDirection * rotationSpeed * (float) delta);
        _cameraContainer.Translate(movement * moveSpeed * (float) delta);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event.IsActionPressed("CameraZoomIn"))
        {
            _camera.Size = Mathf.Max(minZoom, _camera.Size - 1);
        }
        else if (@event.IsActionPressed("CameraZoomOut"))
        {
            _camera.Size = Mathf.Min(maxZoom, _camera.Size + 1);
        }
    }
}
