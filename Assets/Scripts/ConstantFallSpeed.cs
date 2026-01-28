using UnityEngine;

public class ConstantFallSpeed : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 3.0f;
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        body.linearVelocityY = Vector2.down.y * fallSpeed;
    }
}
