using UnityEngine;

public class EnemiManayer : MonoBehaviour
{
    float speed;

    [SerializeField] PlayerManager playerManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerManager = player.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        speed = playerManager.moveSpeed;
    }
}
