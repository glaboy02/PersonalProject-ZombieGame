using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    // private float rotationSpeed = 100f;
    private float horizontalInput;
    private float verticalInput;
    // private float xRange = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // if (transform.position.x < -xRange)
        // {
        //     transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        // }
        // if (transform.position.x > xRange)
        // {
        //     transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        // }

        // Vector3 movement = new Vector3(horizontalInput * speed * Time.deltaTime, 0f, 0f);
        // transform.Translate(movement);
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);


        transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);
        // transform.Translate(Vector3.up * speed * Time.deltaTime);


        // Vector3 movement = new Vector3(
        //     horizontalInput,
        //     verticalInput,
        //     0f
        // );

        // transform.Translate(movement * speed * Time.deltaTime);
    }
}
