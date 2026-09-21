using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    bool isPlayerAlive;
    public float speed;
    [SerializeField] float desplSpeed;
     //Lo que rota segun el RS
    [SerializeField] float rotationSpeed;

    Vector2 move;

    InputActions inputActions;

    //Rotacion
    float maxRotation = 45f;
    public float rotate;

    //Suavizada
    float origin;
    float target;
    [SerializeField] float smoothTime = 0.1f;
    float rotationVelocity;


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

        RotatePlayer();

    }
    void RotatePlayer()
    {
        float currentZ = transform.eulerAngles.z;

        // 2. Calculamos el ángulo objetivo (maxRotation * rotate, sin Vector3.forward)
        float targetZ = -maxRotation * rotate;

        // 3. Usamos SmoothDampAngle (toma el camino más corto automáticamente)
        float smoothedZ = Mathf.SmoothDampAngle(currentZ, targetZ, ref rotationVelocity, smoothTime);

        // 4. Aplicamos el nuevo ángulo al transform
        transform.eulerAngles = new Vector3(0, 0, smoothedZ);


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
