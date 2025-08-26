using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class MountainGen : MonoBehaviour
{
    [SerializeField] private GameObject[] mountainsGO;
    [SerializeField] private GameObject spawnPosition;

    [SerializeField] private float currentTimer = 0;
    [SerializeField] private float setTimer = 13f;

    private void Start()
    {
        currentTimer = setTimer;
    }

    private void Update()
    {
        currentTimer -= Time.deltaTime;
        if (currentTimer <= 0)
        {
            currentTimer = setTimer;
            CreateMountain();
        }
    }

    private void CreateMountain()
    {
        for (int i = 0; i < mountainsGO.Length; i++)
        {
            spawnPosition.transform.position = new Vector3(spawnPosition.transform.position.x, -4.9f, spawnPosition.transform.position.z);
            Instantiate(mountainsGO[i].transform, spawnPosition.transform.position, Quaternion.identity);
        }
    }
}
