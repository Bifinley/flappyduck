using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour
{
    [SerializeField] public int Score = 0;
    [SerializeField] public float poleSpeed = 3;
    [SerializeField] public float gradualPoleSpeed = 0.0003f;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] public GameObject pressSpaceBarUI;
    [SerializeField] public GameObject duckGameObject;
    [SerializeField] public bool isGameOver = false;
    [SerializeField] public bool isWaitingScreenActive = true;

    // The items that come back after reset (below)
    [SerializeField] private GameObject customizeButton;
    [SerializeField] private GameObject gameTitle;

    public bool isShopOpenFromGameMaster;
    public static GameMaster Instance { get; private set; }

    private void Awake()
    {
        Time.timeScale = 0;

        if (Instance != null && Instance != this)
        {
            Debug.LogError("There can only be one Game Master!");
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Update()
    {

        StartGame();
        ResetGame();

        if (isWaitingScreenActive == true)
        {
            SaveManager.Save(Score, DuckInventory.Instance.ownedItems);
        }

        if (!isGameOver)
        {
            poleSpeed += gradualPoleSpeed;
        }
        else if (isGameOver)
        {
            poleSpeed = 3f;
        }
        scoreText.text = $"Score: {Score}";
    }

    private void StartGame()
    {
        if (!isGameOver && !isShopOpenFromGameMaster)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AudioManager.Instance.volumeButton.SetActive(false);
                pressSpaceBarUI.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void AddScore(int score)
    {
        Score += score;
    }

    public void GameOver()
    {
        AudioManager.Instance.duckDieSound.Play();
        isGameOver = true;
        Time.timeScale = 0;
        gameOverText.text = $"Click 'r/right-click' to reset.";

        SaveManager.Save(Score, DuckInventory.Instance.ownedItems);
    }

    public void ResetGame()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R)) // for keyboard gamers
        {
            AudioManager.Instance.volumeButton.SetActive(true);
            AudioManager.Instance.gameMusicSound.UnPause();
            isGameOver = false;
            duckGameObject.transform.position = new Vector3(0, 0, 0);
            customizeButton.SetActive(true);
            gameTitle.SetActive(true);
            gameOverText.text = $"";
            isWaitingScreenActive = true;
        }
        else if (isGameOver && Input.GetMouseButtonDown(1)) // for mouse gamers
        {
            AudioManager.Instance.volumeButton.SetActive(true);
            AudioManager.Instance.gameMusicSound.UnPause();
            isGameOver = false;
            duckGameObject.transform.position = new Vector3(0, 0, 0);
            customizeButton.SetActive(true);
            gameTitle.SetActive(true);
            gameOverText.text = $"";
            isWaitingScreenActive = true;
        }

    }
}
