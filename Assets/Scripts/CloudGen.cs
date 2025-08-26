using UnityEngine;

public class CloudGen : MonoBehaviour
{
    [SerializeField] private GameObject clouds;
    [SerializeField] private GameObject spawnPosition;

    [SerializeField] private float currentTimer = 0;
    [SerializeField] private float setTimer = 3f;

    private void Start()
    {
        currentTimer = setTimer / 2;
    }

    private void Update()
    {
        currentTimer -= Time.deltaTime;
        if (currentTimer <= 0)
        {
            currentTimer = setTimer;
            CreateCloud();
        }
    }

    private void CreateCloud()
    {
        spawnPosition.transform.position = new Vector3(spawnPosition.transform.position.x, Random.Range(-3.46f, 0.59f), spawnPosition.transform.position.z);
        Instantiate(clouds.transform, spawnPosition.transform.position, Quaternion.identity);
    }
}
