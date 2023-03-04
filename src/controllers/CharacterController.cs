using Godot;

public partial class CharacterController : Controller
{
    private Character _active_character;

	public override void Run()
	{
        Node characters = GetNode("/root/Main/World/Characters");
        characters.ChildEnteredTree += onCharactersChildEnteredTree;

        foreach (Character character in characters.GetChildren())
        {
            character.TurnStarted += onCharacterTurnStarted;
        }
	}

    public override void _UnhandledInput(InputEvent @event)
    {
        if (_active_character == null)
        {
            return;
        }

        if (@event.IsActionPressed("EndTurn"))
        {
            _active_character.EndTurn();
        }
    }

    private void onCharactersChildEnteredTree(Node node)
    {
        ((Character)node).TurnStarted += onCharacterTurnStarted;
    }

    private void onCharacterTurnStarted(Character character)
    {
        _active_character = character;
    }
}
