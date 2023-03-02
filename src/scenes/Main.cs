using Godot;

public partial class Main : Node
{
	public override void _Ready()
	{
        GD.Print("Main: _Ready");

        foreach (Controller controller in GetNode("Controllers").GetChildren())
        {
            GD.Print($"Main: {controller.Name} Run");
            controller.Run();
        }
	}
}
