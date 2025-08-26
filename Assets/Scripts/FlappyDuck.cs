using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FlappyDuck : MonoBehaviour
{
    Rigidbody2D flappyDuckRB;
    [SerializeField] float forceAmount;
    [SerializeField] DuckInventory duckInventory;

    void Start()
    {
        flappyDuckRB = GetComponent<Rigidbody2D>();
        duckInventory = GetComponent<DuckInventory>();

        flappyDuckRB.linearVelocityY = 0;

        Vector2 moveVector = new Vector2(0, 2);
    }

    void Update()
    {
        if (GameMaster.Instance.isGameOver)
        {
            flappyDuckRB.linearVelocityY = 0; // reseting the velocity to 0 so it doesnt keep it when you lose
        }

        if (GameMaster.Instance.isWaitingScreenActive == true) // stops the poles from increasing in speed in the waiting menu (aka main menu)
        {
            GameMaster.Instance.poleSpeed = 3f;
        }

        if (!duckInventory.isShopOpen)
        {
            FlapBird();

            if (Input.GetKey(KeyCode.E)) // debug purposes
            {
                this.transform.position = new Vector3(0, 0, 0);
            }
        }
    }

    private void FlapBird() // SpaceBar click
    {
        if (Input.GetKeyDown(KeyCode.Space) && !GameMaster.Instance.isGameOver)
        {
            duckInventory.shopOpenButtons[0].SetActive(false);
            duckInventory.shopOpenButtons[1].SetActive(false);
            flappyDuckRB.AddForce(transform.up * forceAmount, ForceMode2D.Impulse); // if shop is opened, dont let flappy duck move
            AudioManager.Instance.duckFlapSound.Play();
            GameMaster.Instance.isWaitingScreenActive = false;
        }
    }

    public void FlapBirdButton() // Mouse click
    {
        if (!GameMaster.Instance.isGameOver)
        {
            duckInventory.shopOpenButtons[0].SetActive(false);
            duckInventory.shopOpenButtons[1].SetActive(false);
            flappyDuckRB.AddForce(transform.up * forceAmount, ForceMode2D.Impulse); // if shop is opened, dont let flappy duck move
            AudioManager.Instance.duckFlapSound.Play();
            GameMaster.Instance.isWaitingScreenActive = false;

            // Mandatory since you need to deactivate UI for mouse gamers
            AudioManager.Instance.volumeButton.SetActive(false);
            GameMaster.Instance.pressSpaceBarUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
