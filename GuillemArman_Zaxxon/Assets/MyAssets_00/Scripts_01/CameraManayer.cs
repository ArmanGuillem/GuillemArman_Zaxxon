using UnityEngine;

public class CameraManayer : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    [SerializeField] float distance;
    [SerializeField] float verticalOffset;
    [SerializeField] float pitchAngle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 offset = new Vector3(0, verticalOffset, distance);

        transform.position = playerTransform.position - offset;

        Rotate();


        
    }
    
    void Rotate()
    {
        float zAngle = playerTransform.eulerAngles.z;
        Quaternion zRotation = Quaternion.Euler(pitchAngle, 0f, zAngle);
        transform.rotation = zRotation;
    }
}   

