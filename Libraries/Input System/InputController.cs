#nullable enable
using System;
using Godot;

namespace InputSystem;

// Autoload
public partial class InputController : Node {
    public event Action<InputEventDto>? InputFromPlayer;

    public override void _Input(InputEvent @event) {
        switch (@event) {
            case InputEventKey key:
                InputFromPlayer?.Invoke(new KeyDto(
                    OS.GetKeycodeString(key.PhysicalKeycode),
                    key.Pressed,
                    key.Echo
                ));
                break;
            case InputEventMouseButton mouseButton:
                InputFromPlayer?.Invoke(new MouseButtonDto(
                    mouseButton.ButtonIndex.ToString(),
                    mouseButton.Pressed,
                    GetWindow().GetMousePosition()
                ));
                break;
            case InputEventMouseMotion mouseMotion:
                InputFromPlayer?.Invoke(new MouseMotionDto(
                    mouseMotion.Position,
                    mouseMotion.Relative
                ));
                break;
            case InputEventJoypadButton:
                break;
            case InputEventJoypadMotion:
                break;
        }
    }
}