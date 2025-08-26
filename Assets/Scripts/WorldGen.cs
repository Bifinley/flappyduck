using UnityEngine;

public class WorldGen : MonoBehaviour
{
    [SerializeField] private GameObject woodPoles;
    [SerializeField] private GameObject spawnPosition;

    private float currentTimer = 0;
    [SerializeField] private float setTimer; // set in the editor

    private float createWoodPoleSetTimerMin =  0.9f;
    private float createWoodPoleTakeAwayAmount = 0.01f;

    private void Start()
    {
        currentTimer = setTimer;
    }

    private void Update()
    {
        currentTimer -= Time.deltaTime;

        if (GameMaster.Instance.isGameOver)
        {
            setTimer = 3f; // reset time if game is lost
        }

        if(setTimer <= createWoodPoleSetTimerMin)
        {
            setTimer = createWoodPoleSetTimerMin; // if setTimer reaches the min, then set it to min. If it goes over the poles will spawn too quickly making game impossible.
        }

        if(currentTimer <= 0)
        {
            currentTimer = setTimer;
            CreateWoodPole();
        }

        if (Input.GetKeyDown(KeyCode.F1)) // Just for testing purposes
        {
            CreateWoodPole();
        }

        //Debug.Log(currentTimer); 
    }

    private void CreateWoodPole()
    {
        setTimer -= createWoodPoleTakeAwayAmount;

        spawnPosition.transform.position = new Vector3(spawnPosition.transform.position.x, Random.Range(-3.46f, 0.59f), spawnPosition.transform.position.z);
        Instantiate(woodPoles.transform, spawnPosition.transform.position, Quaternion.identity);
    }
}
