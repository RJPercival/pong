using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class Paddle : MonoBehaviour
{
    public float speed = 10.0f;
    public float collisionVelocityScalingFactor = 0.2f;
    public AudioSource bounceSound;

    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue value)
    {
        var direction = value.Get<Vector2>();

        body.velocityY = direction.y * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Upon colliding with a wall, stop rather than bouncing.
            body.velocityY = 0;
        }
        
        var otherBody = collision.gameObject.GetComponent<Rigidbody2D>();
        if (otherBody != null)
        {
            // Transfer some velocity from the paddle to the ball.
            otherBody.velocity += body.velocity * collisionVelocityScalingFactor;
        }

        bounceSound.Play();
    }
}
