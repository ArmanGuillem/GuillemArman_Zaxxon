using UnityEngine;

public class CameraManayer : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    [SerializeField] float distance = 10;
    [SerializeField] float verticalOffset = -2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 offset = new Vector3(0, verticalOffset, distance);

        transform.position = playerTransform.position - offset;
    }
}
