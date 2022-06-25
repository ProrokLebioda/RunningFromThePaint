using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;

    private InputManager inputManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.Instance;
    }

    private void FixedUpdate()
    {
        // Ex1
        //rb.velocity = Vector3.forward * speed *Time.deltaTime;

        // Ex2
        rb.AddForce(new Vector3(0, 0, speed * Time.deltaTime));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
