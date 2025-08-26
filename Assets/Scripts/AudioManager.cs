using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    // Credits to Pixabay.com for their Audio
    public AudioSource gameMusicSound;
    public AudioSource duckDieSound;
    public AudioSource givePointSound;
    public AudioSource duckFlapSound;

    [SerializeField] private Image onOffSlot;

    [SerializeField] private Sprite onSprite;
    [SerializeField] private Sprite offSprite;

    public GameObject volumeButton;

    [SerializeField] private bool isAudioOn = true;

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogError("There can only be one Audio Manager!");
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        if (!GameMaster.Instance.isGameOver)
        {
            gameMusicSound.Play();
        }
    }
    private void Update()
    {
        if (GameMaster.Instance.isGameOver)
        {
            gameMusicSound.Pause();
        }
    }


    public void AudioOnOff()
    {
        if (isAudioOn == true) // if on turn off 
        {
            isAudioOn = false;

            gameMusicSound.volume = 0;
            givePointSound.volume = 0;
            duckFlapSound.volume = 0;
            duckDieSound.volume = 0;

            onOffSlot.sprite = offSprite;
        }
        else if(isAudioOn == false) // if off turn on
        {
            isAudioOn = true;

            gameMusicSound.volume = 0.45f;
            givePointSound.volume = 0.62f;
            duckFlapSound.volume = 0.12f;
            duckDieSound.volume = 0.73f;

            onOffSlot.sprite = onSprite;
        }
    }
}
