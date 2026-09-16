using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    bool isPlayerAlive;
    public float speed;
    [SerializeField] float desplSpeed;
    public float rotateSpeed;
    Vector2 Move;
    InputActions inputActions;

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.Player.Fire.performed += ctx => Debug.Log("Fire");

        inputActions.Player.Move.performed += ctx => Move = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += _ => Move = Vector2.zero;

        inputActions.Player.rotate.performed += ctx => Move = ctx.ReadValue<Vector2>();
        inputActions.Player.rotate.canceled += _ => Move = Vector2.zero;
    }


    private void Update()
    {
        transform.Translate(Vector2.right * Move.x * desplSpeed * Time.deltaTime);
        transform.Translate(Vector2.up * Move.y * desplSpeed * Time.deltaTime);

        transform.Rotate(Vector2.up * Move.y * desplSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
}
