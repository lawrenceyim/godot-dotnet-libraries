using Godot;
using GodotDotnetLibraries;
using InputSystem;

public partial class InputSystemTestOne : Node {
    public override void _Ready() {
        Autoloader autoloader = new Autoloader();
        IAutoload autoload = autoloader.GetAutoload(AutoloadId.InputController);
        GD.Print($"{autoload.Id} object is input controller? {autoload is InputController}");
        InputController inputController = autoload as InputController;
        if (inputController is null) {
            return;
        }

        inputController.InputFromPlayer += ParseInput;
    }

    public void ParseInput(InputEventDto dto) {
        GD.Print(dto);
    }
}