using UnityEngine;

public class CameraController : MonoBehaviour
{
    const float rotationSpeed = 50f;

    void FixedUpdate()
    {
        // Move the camera around the focal point
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
