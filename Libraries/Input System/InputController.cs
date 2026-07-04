#nullable enable
using System;
using GodotDotnetLibraries;
using Godot;

namespace InputSystem;

public partial class InputController : Node, IAutoload {
    public event Action<InputEventDto>? InputFromPlayer;
    public AutoloadId Id { get; } = AutoloadId.InputController;

    public InputController() { }

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