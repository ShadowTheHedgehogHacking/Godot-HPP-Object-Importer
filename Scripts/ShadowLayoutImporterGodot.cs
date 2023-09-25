using Godot;

public partial class ShadowLayoutImporterGodot : Node3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		string fileToImport = ProjectSettings.GlobalizePath("res://Sample Stage/stg0100_cmn.dat");

		HeroesPowerPlant.LayoutEditor.LayoutEditorSystem.SetupLayoutEditorSystem(); // change this function to use Heroes's ini if you want Heroes objects

		var list = HeroesPowerPlant.LayoutEditor.LayoutEditorFunctions.GetShadowLayout(fileToImport);
		var godot_shadowth_scaling = 39.3701f;

		var core = GetNode("/root/0100/Cubeus");
		core = core as MeshInstance3D;
		for (int i = 0; i < list.Count; i++) {
			var cube = core.Duplicate();
			((Node3D)cube).Position = new Vector3(list[i].Position.X / godot_shadowth_scaling, list[i].Position.Y / godot_shadowth_scaling, list[i].Position.Z / godot_shadowth_scaling);
			cube.Name = "(" + list[i].Link + ") " + list[i].GetName + " #" + i;
			AddChild(cube, true, InternalMode.Front);
			cube.Owner = this;
			GD.Print(cube.Name);
			GD.Print(((Node3D)cube).Position);
		}
	}
}
