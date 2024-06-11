using UnityEngine;

public class ArmMovement : MonoBehaviour
{
    public float minRotation = -45f;
    public float maxRotation = 45f;

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePosition.z = transform.position.z;

        Vector3 direction = (mousePosition - transform.position).normalized;

        float angleDeg = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Get the current rotation
        float currentRotation = transform.rotation.eulerAngles.z;

        // Clamp the rotation within the specified range
        float clampedRotation = Mathf.Clamp(angleDeg, minRotation, maxRotation);

        // Apply the clamped rotation back to the sprite
        transform.rotation = Quaternion.Euler(0f, 0f, clampedRotation);
    }
}
