using Godot;
using Godot.Collections;

public partial class TurnController : Controller
{
    private Character _active_character;
    private Array<Character> _characters = new Array<Character>();

    public override void Run()
    {
        Node characters = GetNode("/root/Main/World/Characters");
        characters.ChildEnteredTree += onCharactersChildEnteredTree;
        characters.ChildExitingTree += onCharactersChildExitingTree;

        foreach (Character character in characters.GetChildren())
        {
            _characters.Add(character);
        }

        startNextTurn();
    }

    private void startNextTurn()
    {
        if (_active_character != null)
        {
            _characters.Add(_active_character);
            _active_character.TurnEnded -= onActiveCharacterTurnEnded;
        }

        _active_character = _characters[0];
        _characters.Remove(_active_character);
        _active_character.TurnEnded += onActiveCharacterTurnEnded;
        GD.Print($"TurnController: {_active_character.Name} StartTurn");
        _active_character.StartTurn();
    }

    private void onCharactersChildEnteredTree(Node node)
    {
        _characters.Add((Character)node);
    }

    private void onCharactersChildExitingTree(Node node)
    {
        _characters.Remove((Character)node);
    }

    private void onActiveCharacterTurnEnded(Character character)
    {
        GD.Print($"TurnController: {_active_character.Name} EndTurn");
        startNextTurn();
    }
}
