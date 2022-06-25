using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private InputManager inputManager;
    private Camera cameraMain;

    private Transform newTransform;



    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Awake()
    {
        inputManager = InputManager.Instance;
        cameraMain = Camera.main;
    }

    private void Start()
    {
        newTransform = transform;
    }
    private void OnEnable()
    {
        inputManager.OnPerformedTouch += Move;
    }

    private void OnDisable()
    {
        inputManager.OnPerformedTouch -= Move;
    }

    public void Move(Vector2 screenPosition, float time)
    {
        Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, 12);
        Vector3 worldCoordinates = cameraMain.ScreenToWorldPoint(screenCoordinates);
        worldCoordinates.y = transform.position.y;
        worldCoordinates.z = transform.position.z;
        //transform.position = worldCoordinates;
        Debug.Log("Transform: " + transform.position.ToString());
        newTransform.position = worldCoordinates;
        Debug.Log("New Transform: " + newTransform.position.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //transform.position = Vector3.SmoothDamp(transform.position, newTransform.position, ref velocity, 3f );
        transform.position = newTransform.position;
    }
}
