using Godot;

public partial class CameraController : Camera3D
{

	private const float CameraSpeed = 5.0f;
	private const float CameraFastSpeed = 10.0f;
	private const float RotationSpeed = 0.1f;

	private Vector3 cameraTranslation;
	private Vector2 rotation;

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion mouseMotion)
		{
			if (Input.MouseMode == Input.MouseModeEnum.Captured)
			{
				// this is wrong
				float mouseXDelta = mouseMotion.Relative.X;
				float mouseYDelta = mouseMotion.Relative.Y;

				// Rotate the camera based on mouse movement
				RotateY(-mouseXDelta * RotationSpeed);
				RotateX(-mouseYDelta * RotationSpeed);
			}
		}
	}

	public override void _Process(double delta)
	{
		float speed = Input.IsKeyPressed(Key.Shift) ? CameraFastSpeed : CameraSpeed;
		cameraTranslation = new Vector3();

		if (Input.IsMouseButtonPressed(MouseButton.Right))
		{
			Input.MouseMode = Input.MouseModeEnum.Captured;
			if (Input.IsKeyPressed(Key.W))
				cameraTranslation += -Transform3D.Identity.Basis.Z;
			if (Input.IsKeyPressed(Key.S))
				cameraTranslation += Transform3D.Identity.Basis.Z;
			if (Input.IsKeyPressed(Key.A))
				cameraTranslation += -Transform3D.Identity.Basis.X;
			if (Input.IsKeyPressed(Key.D))
				cameraTranslation += Transform3D.Identity.Basis.X;
			if (Input.IsKeyPressed(Key.Q))
				cameraTranslation += -Transform3D.Identity.Basis.Y;
			if (Input.IsKeyPressed(Key.E))
				cameraTranslation += Transform3D.Identity.Basis.Y;
		} else
		{
			Input.MouseMode = Input.MouseModeEnum.Visible;

		}

		cameraTranslation = cameraTranslation.Normalized() * speed * (float)delta;
		Translate(cameraTranslation);
	}
}
