using Godot;

public partial class Main : Node
{
	public override void _Ready()
	{
        GD.Print("main ready");

        foreach (Controller controller in GetNode("Controllers").GetChildren())
        {
            controller.Run();
        }
	}
}
