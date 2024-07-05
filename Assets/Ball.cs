using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public float speed = 5.0f;
    public float acceleration = 0.01f;
    public bool isRespawning = false;

    private Rigidbody2D body;

    private void Awake()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    private async Task Start()
    {
        await Respawn();
    }

    private void FixedUpdate()
    {
        if (isRespawning) return;

        if(body.velocityX > 0)
        {
            body.velocityX += acceleration;
        }
        else
        {
            body.velocityX -= acceleration;
        }
    }

    public async Task Respawn()
    {
        // Pick an angle in a 90* arc centred on a paddle.
        var angleDegrees = Random.Range(45f, 135f);

        // Flip a coin to see whether we send the ball left or right.
        if (Random.value > 0.5)
        {
            angleDegrees += 180;
        }

        var angleRadians = angleDegrees * Mathf.Deg2Rad;
        var direction = new Vector2(math.cos(angleRadians), math.sin(angleRadians));

        body.position = Vector2.zero;
        body.velocity = Vector2.zero;

        isRespawning = true;
        await Task.Delay(1000);
        isRespawning = false;
        body.velocity = direction * speed;
    }
}
