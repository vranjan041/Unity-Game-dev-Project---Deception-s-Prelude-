using UnityEngine;

public class AimMovement : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePosition.z = transform.position.z;

        Vector3 direction = (mousePosition - transform.position).normalized;

        float angleDeg = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // transform.rotation = Quaternion.Euler(new Vector3(0, 0, angleDeg));

        // Mirror the sprite based on the angleDeg
        if (angleDeg > 90f || angleDeg < -90f)
        {
            transform.localScale = new Vector3(-1.888436f, 1.888436f, 1.888436f);
        }
        else
        {
            transform.localScale = new Vector3(1.888436f, 1.888436f, 1.888436f);
        }
    }
}
