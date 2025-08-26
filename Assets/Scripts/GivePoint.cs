using UnityEngine;

public class GivePoint : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    bool isTouched = false;

    BoxCollider2D boxCollider2D;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            if (!isTouched)
            {
                AudioManager.Instance.givePointSound.Play();
                GameMaster.Instance.AddScore(Random.Range(1, 5));
                isTouched = true;
            }
        }
    }
}
