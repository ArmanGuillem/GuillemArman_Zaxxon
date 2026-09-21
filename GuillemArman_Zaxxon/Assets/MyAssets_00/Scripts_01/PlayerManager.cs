using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    bool isPlayerAlive;
    public float speed;
    [SerializeField] float desplSpeed;
    public float rotate; //Lo que rota segun el RS
    [SerializeField] float rotationSpeed;
    Vector2 move;
    InputActions inputActions;

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.Player.Fire.performed += ctx => Debug.Log("Fire");

        inputActions.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += _ => move = Vector2.zero;

        inputActions.Player.rotate.performed += ctx => rotate = ctx.ReadValue<float>();
        inputActions.Player.rotate.canceled += _ => rotate = 0f;
    }


    private void Update()
    {
        transform.Translate(Vector2.right * move.x * desplSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector2.up * move.y * desplSpeed * Time.deltaTime, Space.World);

        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * -360 * rotate);     
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
