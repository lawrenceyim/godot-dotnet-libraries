using System;
using System.Collections.Generic;
using System.Linq;
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

        foreach (object obj in _autoloadTypes.Select(Activator.CreateInstance)) {
            root.CallDeferred(Node.MethodName.AddChild, obj as Node);
            IAutoload autoload = (IAutoload)obj;
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