using UnityEngine;

public class MountainMove : MonoBehaviour
{
    [SerializeField] private float moveMountainSpeed = 3f;

    private void Update()
    {
        Vector3 moveOnX = new Vector3(-1, 0);

        this.transform.position += moveMountainSpeed * Time.deltaTime * moveOnX;

        if (this.transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}
