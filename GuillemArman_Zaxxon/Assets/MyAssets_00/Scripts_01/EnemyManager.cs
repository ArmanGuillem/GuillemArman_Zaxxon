using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] float speed;
    PlayerManager playerManager;
    
    

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerManager = player.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        

    }

    void Move()
    {
        transform.Translate(Vector3.back* speed * Time.deltaTime);
        speed = playerManager.moveSpeed;


    }

    
}



