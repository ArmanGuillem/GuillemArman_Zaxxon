using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    //Vidas y tal
    bool isAlive = true;
    public int health = 100;
    public int lives = 3;
    public int maxLives = 3;

   

    //Movimiento
    public float moveSpeed;
    [SerializeField] float desplSpeed;
    Vector2 move;
    [SerializeField] float accelerationRate;
    float currentSpeed;


    float moveX;
    float moveY;


    //Rotacion
    float maxRotationZ = 20f;
    float maxRotationX = 20f;
    
    [SerializeField] float rotationSpeed;
    Vector3 currentRot;

    //Suavizada
    float origin;
    float target;
    [SerializeField] float smoothTime;
    private Vector3 rotationVelocity = Vector3.zero;


    //Limites de movimiento del jugador
    [SerializeField] float xMin, xMax, yMin, yMax;


    InputActions inputActions;


    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.Player.Fire.performed += ctx => print ("Fire");

        //Detecta los inputs del jugador y los asigna a las variables correspondientes
        inputActions.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += _ => move = Vector2.zero;


        

    }


    private void Update()
    {
        Limit();
        // Mueve y rota al jugador en el eje X e Y
        MovePlayer();

        RotatePlayer();

        
    }
    void RotatePlayer()
    {
        Vector3 vectorRotZ = Vector3.forward * -maxRotationZ *  move.x;
        Vector3 vectorRotX = Vector3.right * -maxRotationX *  move.y; ;
        Vector3 vectorRot = vectorRotX + vectorRotZ;
        currentRot = Vector3.SmoothDamp(currentRot, vectorRot, ref rotationVelocity, smoothTime);
        transform.eulerAngles = currentRot;

    }
    void MovePlayer()
    {
        
        transform.Translate(Vector2.right * move.x * desplSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector2.up * move.y * desplSpeed * Time.deltaTime, Space.World);

        currentSpeed = Mathf.MoveTowards(currentSpeed, moveSpeed, accelerationRate * Time.deltaTime);

        // 3. Avance continuo en el eje Z (hacia adelante)
        .
        transform.Translate(Vector3.forward * (currentSpeed * Time.deltaTime), Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            print ("Te has chocado");
            moveSpeed = 0;
            

        }
    }

   
    void Limit()
    {
        Vector3 currentPos = transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x, xMin, xMax);
        currentPos.y = Mathf.Clamp(currentPos.y, yMin, yMax);
        transform.position = currentPos;
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

//float currentZ = transform.eulerAngles.z;

// 2. Calculamos el ángulo objetivo (maxRotation * rotate, sin Vector3.forward)
// targetZ = -maxRotation * rotate;

// 3. Usamos SmoothDampAngle (toma el camino más corto automáticamente)
//float smoothedZ = Mathf.SmoothDampAngle(currentZ, targetZ, ref rotationVelocity, smoothTime);

// 4. Aplicamos el nuevo ángulo al transform
//transform.eulerAngles = new Vector3(0, 0, smoothedZ);