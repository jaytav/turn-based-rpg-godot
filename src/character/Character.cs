using Godot;

public partial class Character : Node3D
{
    [Signal]
    public delegate void TurnStartedEventHandler(Character character);

    [Signal]
    public delegate void TurnEndedEventHandler(Character character);

    public void StartTurn()
    {
        EmitSignal("TurnStarted", this);
    }

    public void EndTurn()
    {
        EmitSignal("TurnStarted", this);
    }
}
