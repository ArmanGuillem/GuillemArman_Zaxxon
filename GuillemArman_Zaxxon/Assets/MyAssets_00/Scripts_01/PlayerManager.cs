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
    float maxRotation = 45f;

    //Limites de movimiento del jugador
    [SerializeField] float xMin = 0.5f, xMax = 9.5f, yMin = 0.5f, yMax = 5.5f;

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.Player.Fire.performed += ctx => Debug.Log("Fire");

        //Detecta los inputs del jugador y los asigna a las variables correspondientes
        inputActions.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += _ => move = Vector2.zero;

        inputActions.Player.rotate.performed += ctx => rotate = ctx.ReadValue<float>();
        inputActions.Player.rotate.canceled += _ => rotate = 0f;

    }


    private void Update()
    {
        // Mueve y rota al jugador en el eje X e Y
        MovePlayer();

        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * -360 * rotate);

        // Clampea la posicion del jugador para que no se salga de la pantalla
        Vector3 currentPos = transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x, xMin, xMax);
        currentPos.y = Mathf.Clamp(currentPos.y, yMin, yMax);
        transform.position = currentPos;
    }
    void RotatePlayer()
    {
         transform.eulerAngles = new Vector3.forward * maxRotation * rotate;
    }
    void MovePlayer()
    {
        transform.Translate(Vector2.right * move.x * desplSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector2.up * move.y * desplSpeed * Time.deltaTime, Space.World);

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
