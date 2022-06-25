using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public Transform playerTransform;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Follow all the way, X-axis, Y-axis and Z-axis
        //transform.position = playerTransform.position + offset;


        // Follow on Y-axis and Z-axis only
        transform.position = new Vector3(0, playerTransform.position.y, playerTransform.position.z)+ offset;
    }

    // Update is called once per frame
    void Update()
    {
        // Follow all the way, X-axis, Y-axis and Z-axis
        //transform.position = playerTransform.position + offset;


        // Follow on Y-axis and Z-axis only
        transform.position = new Vector3(0, playerTransform.position.y, playerTransform.position.z) + offset;
    }
}
