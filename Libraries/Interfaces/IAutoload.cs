namespace GodotDotnetLibraries;

/// <summary>
/// Classes that implement IAutoload should have a private constructor.
/// A single instance should be instantiated by the Autoloader.
/// </summary>
public interface IAutoload {
    public AutoloadId Id { get; }
}