using UnityEngine;

public class Goal : MonoBehaviour
{
    public TMPro.TMP_Text goalsText;
    public int goals = 0;
    public AudioSource goalSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        ball.Respawn();

        goals += 1;
        goalsText.text = goals.ToString();

        goalSound.Play();
    }
}
