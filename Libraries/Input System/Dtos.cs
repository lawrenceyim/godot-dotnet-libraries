using Godot;

namespace InputSystem;

public abstract record InputEventDto { }

public record KeyDto(string Identifier, bool Pressed, bool Echo) : InputEventDto {
    public readonly string Identifier = Identifier;
    public readonly bool Pressed = Pressed;
    public readonly bool Echo = Echo;
}

public record MouseMotionDto(Vector2 Position, Vector2 Relative) : InputEventDto {
    public readonly Vector2 Position = Position;
    public readonly Vector2 Relative = Relative;
}

public record MouseButtonDto(string Identifier, bool Pressed, Vector2 Position) : InputEventDto {
    public readonly string Identifier = Identifier;
    public readonly bool Pressed = Pressed;
    public readonly Vector2 Position = Position;
}

public record JoypadButtonDto() : InputEventDto { }

public record JoypadMotion() : InputEventDto { }