using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float speed;
    [SerializeField] float mySpeed;
    Transform playerTransform;
    PlayerManager playerManager;

    
    

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerManager = player.GetComponent<PlayerManager>();
        playerTransform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Despawn();


    }

    void Move()
    {
        speed = playerManager.moveSpeed + mySpeed;
        transform.Translate(Vector3.back* speed * Time.deltaTime);


    }
    void Despawn()
        {
            if (transform.position.z < playerTransform.position.z)
            {
                Destroy(gameObject);
            }
    }

}



