using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovementController : MonoBehaviour
{
	[Header("FPS Attributes")]
	[SerializeField] private Camera playerCamera;
	[SerializeField] private float walkSpeed;
	[SerializeField] private float runSpeed;
	[SerializeField] private float jumpForce;
	[SerializeField] private float grafity;

	[SerializeField] private float sensitivity;
	private const float LookYLimit = 80f;

	[SerializeField] private Vector3 moveDirection = Vector3.zero;
	private float _rotationX = 0;

	[SerializeField] private bool canMove = true;

	private CharacterController _characterController;

	void Start()
	{
		_characterController = GetComponent<CharacterController>();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Update()
	{
		#region Handles Movement
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		Vector3 right = transform.TransformDirection(Vector3.right);
		

		bool isRunning = Input.GetKey(KeyCode.LeftShift);

		float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
		float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;

		float movementDirectionY = moveDirection.y;
		moveDirection = (forward * curSpeedX) + (right * curSpeedY);

		#endregion

		#region Handles Jumping
			if (Input.GetButton("Jump") && canMove && _characterController.isGrounded)
			{
				moveDirection.y = jumpForce;
			}
			else
			{
				moveDirection.y = movementDirectionY;
			}

			if (!_characterController.isGrounded)
			{
				moveDirection.y -= grafity * Time.deltaTime;
			}
		#endregion


		#region Handles Roation

		_characterController.Move(moveDirection * Time.deltaTime);

		if (canMove)
		{
			_rotationX += -Input.GetAxis("Mouse Y") * sensitivity;
			_rotationX = Mathf.Clamp(_rotationX, -LookYLimit, LookYLimit);
			playerCamera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
			transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * sensitivity, 0);
		}

		#endregion
	}
}
