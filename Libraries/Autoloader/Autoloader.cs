#nullable enable
using System;
using System.Collections.Generic;
using System.Reflection;
using Godot;
using InputSystem;

namespace GodotDotnetLibraries;

public class Autoloader {
    private readonly List<Type> _autoloadTypes = [
        typeof(InputController)
    ];

    private readonly Dictionary<AutoloadId, IAutoload> _autoloads = [];

    public Autoloader() {
        SceneTree tree = (SceneTree)Engine.GetMainLoop();
        Node root = tree.Root;

        foreach (Type type in _autoloadTypes) {
            ConstructorInfo? ctor = type.GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                binder: null,
                Type.EmptyTypes,
                modifiers: null);

            object? obj = ctor?.Invoke(null);

            if (obj is not (Node node and IAutoload autoload)) {
                continue;
            }

            root.CallDeferred(Node.MethodName.AddChild, node);
            _autoloads.Add(autoload.Id, autoload);
        }
    }

    public IAutoload GetAutoload(AutoloadId id) {
        return _autoloads[id];
    }
}

public enum AutoloadId {
    InputController = 0
}