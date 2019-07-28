using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWithNewInputSystem : MonoBehaviour
{
    public Rigidbody2D body;

    private PlayerControls controls;
    private Vector2 move;

    public float walkingSpeed;
    public float jumpSpeed;

    private void Awake()
    {
        controls = new PlayerControls();

        controls.Player.Shoot.performed += ctx => Shoot();

        controls.Player.Movement.performed += HandleMove;
        controls.Player.Movement.canceled += ctx => { Debug.Log("Move canceled"); move.x = 0f; };

        controls.Player.Jump.performed += HandleJump;
        controls.Player.Jump.canceled += ctx => { Debug.Log("Jump Canceled"); move.y = 0f; };

    }

    private void Update()
    {
        Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;
        transform.Translate(m, Space.World);
    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    private void Shoot()
    {
        Debug.Log("You just shot me!");
    }

    private void HandleMove(InputAction.CallbackContext context)
    {
        Debug.Log("You moved, direction: " + context.ReadValue<float>());
        move.x = context.ReadValue<float>() * walkingSpeed;
    }

    private void HandleJump(InputAction.CallbackContext context)
    {
        Debug.Log("You jumped: " + context.ReadValue<float>());
        move.y = jumpSpeed;
    }

}
