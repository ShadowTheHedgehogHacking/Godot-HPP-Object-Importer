using Godot;

public partial class ShadowLayoutImporterGodot : Node3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		string fileToImport = ProjectSettings.GlobalizePath("res://Sample Stage/stg0100_cmn.dat");

		// ShadowSET.LayoutEditorSystem.SetupLayoutEditorSystem();

		var list = ShadowSET.Layout.GetShadowLayout(fileToImport);
		var godot_shadowth_scaling = 39.3701f;

		var core = GetNode("/root/0100/Cubeus");
		core = core as MeshInstance3D;
		for (int i = 0; i < list.Count; i++) {
			var cube = core.Duplicate();
			((Node3D)cube).Position = new Vector3(list[i].PosX / godot_shadowth_scaling, list[i].PosY / godot_shadowth_scaling, list[i].PosZ / godot_shadowth_scaling);
			cube.Name = "(" + list[i].Link + ") " + list[i].GetName + " #" + i;
			AddChild(cube, true, InternalMode.Front);
			cube.Owner = this;
			GD.Print(cube.Name);
			GD.Print(((Node3D)cube).Position);
		}
	}
}
