using UnityEngine;

public class MovingPole : MonoBehaviour
{

    [SerializeField] GameObject pole1;
    [SerializeField] GameObject pole2;

    [SerializeField] private float movePoleSpeed = 3f;

    [SerializeField] private float currentPoleTimer = 0f;
    [SerializeField] private float resetTimer = 3f;

    [SerializeField] private bool testMode = false;

    private void Start()
    {
        currentPoleTimer = resetTimer;
    }

    private void Update()
    {
        currentPoleTimer -= Time.deltaTime;
        if (testMode == true)
        {
            if (currentPoleTimer <= 0f)
            {
                currentPoleTimer = resetTimer;

                AlignPoleHeightMovement(); // this moves the poles up and down, adding a new difficulty (still working on it, there is a bug with the timer)
            }
        }

        movePoleSpeed += 0.003f; // slowly move faster

        //Debug.Log(currentPoleTimer);

        Vector3 moveOnX = new Vector3(-1, 0);

        //this.transform.position += movePoleSpeed * Time.deltaTime * moveOnX;
        this.transform.position += GameMaster.Instance.poleSpeed * Time.deltaTime * moveOnX;


        if (this.transform.position.x <= -15)
        {
            Destroy(gameObject);
        }

        if (GameMaster.Instance.isGameOver == true)
        {
            Destroy(gameObject);
        }

    }

    private void AlignPoleHeightMovement()
    {
        pole1.transform.position += new Vector3(0, Random.Range(-1.5f, 1.5f), 0);
        pole2.transform.position += new Vector3(0, Random.Range(-1.5f, 1.5f), 0);

        Debug.Log("Pole Reajusted");
    }

}
