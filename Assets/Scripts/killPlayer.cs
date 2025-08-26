using UnityEngine;

public class killPlayer : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            GameMaster.Instance.GameOver(); // womp womp
        }
    }
}
