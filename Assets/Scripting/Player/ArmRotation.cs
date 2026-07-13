using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    public float speed = 5f;
    public Transform playerArm;
    public Vector2 direction;
    void FixedUpdate()
    {
        RotateArmTowardsMouse();
    }

    public void RotateArmTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - transform.position);
        mousePosition.z = 0f;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle = angle - 270f;
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
}
