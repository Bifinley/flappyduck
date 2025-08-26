using UnityEngine;

public class MovingCloud : MonoBehaviour
{
    [SerializeField] private float moveCloudSpeed = 3f;

    private void Update()
    {
        Vector3 moveOnX = new Vector3(-1, 0);

        this.transform.position += moveCloudSpeed * Time.deltaTime * moveOnX;

        if (this.transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}
