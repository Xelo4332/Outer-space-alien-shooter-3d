using UnityEngine;

public class simpleMove : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed of movement

    void Update()
    {
        // Get input from the user
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Move the GameObject based on input
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
