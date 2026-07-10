using Godot;
using System;
using System.Collections.Generic;
using Godot.Collections;

public enum Values {
	A,
	B,
	C,
	D,
	E,
	F
}

public enum ItemType {
	Potion,
	Sword,
	Shield,
	Gun,
}

[Tool]
public partial class StringBasedEnum : Node2D {
	// [Export(PropertyHint.Enum, "A,B,C,D,E,F")]
	// public string Value { get; set; } = "A";

	[Export(PropertyHint.Enum, "Low:0,Medium:5,High:10")]
	public int Priority { get; set; } = 0;

	[Export]
	public string SelectedItem { get; set; } = "";

	public override void _ValidateProperty(Godot.Collections.Dictionary property) {
		switch (property["name"].AsString()) {
			case nameof(SelectedItem):
				// var options = new[] { "Sword", "Shield", "Potion" };
				string[] options = Enum.GetNames(typeof(ItemType));
				property["hint"] = (int)PropertyHint.Enum;
				property["hint_string"] = string.Join(",", options);
				break;
		}
	}
}
