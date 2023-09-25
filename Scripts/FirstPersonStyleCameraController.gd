extends CharacterBody3D

# Credit to https://github.com/lukky-nl/Lukky-Godot-Dev-Rooms for base first person camera script

@onready var head = $head
@onready var camera_3d = $head/Camera3D

var speed = 15.0
const mouse_sens = 0.25

func _ready():
	Input.set_mouse_mode(Input.MOUSE_MODE_CAPTURED)

func _input(event):
	if event is InputEventMouseMotion:
		rotate_y(deg_to_rad(-event.relative.x * mouse_sens))
		head.rotate_x(deg_to_rad(-event.relative.y * mouse_sens))
		head.rotation.x = clamp(head.rotation.x,deg_to_rad(-89),deg_to_rad(89))


func _physics_process(delta):
	if (Input.is_action_pressed("faster")):
		speed = speed + 5.0
	if (Input.is_action_pressed("slower") && speed > 5.0):
		speed = speed - 5.0
	var input_dir = Input.get_vector("left", "right", "forward", "backward")

	var camera_transform = camera_3d.get_global_transform()
	# Extract the camera's forward vector
	var camera_forward = -camera_transform.basis.z.normalized()
	# Calculate the movement direction based on camera orientation
	var direction = camera_forward * -input_dir.y + camera_transform.basis.x * input_dir.x
	direction = direction.normalized()

	# Apply speed to the movement direction
	velocity = direction * speed

	move_and_slide()
