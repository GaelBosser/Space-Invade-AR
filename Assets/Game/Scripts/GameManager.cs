using UnityEngine;
using UnityEngine.SceneManagement;

public enum Difficulty { Easy, Normal, Hard }
public enum GameProgress { NotStarted, InProgress, Paused, Ended }


public class GameManager : MonoBehaviour
{
    public GameObject player;

    [Header("Life Interface")]
    [SerializeField]
    private GameObject coeur1;
    [SerializeField]
    private GameObject coeur1vide;
    [SerializeField]
    private GameObject coeur2;
    [SerializeField]
    private GameObject coeur2vide;
    [SerializeField]
    private GameObject coeur3;
    [SerializeField]
    private GameObject coeur3vide;
    [SerializeField]
    private GameObject coeur4;
    [SerializeField]
    private GameObject coeur5;

    [Header("Pause Interface")]
    [SerializeField]
    private GameObject pauseImage;
    [SerializeField]
    private GameObject pauseText;
    [SerializeField]
    private GameObject pauseButton;
    [SerializeField]
    private GameObject playButton;

    [Header("Death Interface")]
    [SerializeField]
    private GameObject deathImage;
    [SerializeField]
    private GameObject sans;
    [SerializeField]
    private GameObject replayButton;
    [SerializeField]
    private GameObject menuButton;

    [Header("Game Parameters")]
    public Difficulty difficulty;
    public GameProgress gameProgress;
    public bool mute;

    
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<GameManager>();
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null) Destroy(this);
        //DontDestroyOnLoad(this);

        difficulty = Settings.difficulty;
        mute = Settings.mute;

        gameProgress = GameProgress.InProgress;
    }

    void Update()
    {
        if(gameProgress == GameProgress.Ended)
        {
            pauseButton.SetActive(false);
        }
    }

    public void PauseMenuOnPauseButtonClick()
    {

        gameProgress = GameProgress.Paused;
        pauseImage.SetActive(true);
        pauseText.SetActive(true);
        playButton.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void UnpauseMenuOnPauseButtonClick()
    {
        gameProgress = GameProgress.InProgress;
        pauseImage.SetActive(false);
        pauseText.SetActive(false);
        playButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void PlayerDeath()
    {
        gameProgress = GameProgress.Ended;
        deathImage.SetActive(true);
        sans.SetActive(true);
        replayButton.SetActive(true);
        menuButton.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void GoToMainMenu()
    {
        gameProgress = GameProgress.NotStarted;
        SceneManager.LoadScene("Menu");
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("Robin");
        //SceneManager.LoadScene("SceneGame");
    }

    public void Replay()
    {
        SceneManager.LoadScene("Robin");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UpdateLifeInterface()
    {
        int life = player.GetComponent<HealthScript>().Life;

        if (life >= 1)
        {
            coeur1.SetActive(true);
            coeur1vide.SetActive(false);
        }
        else
        {
            coeur1.SetActive(false);
            coeur1vide.SetActive(true);

        }
        if (life >= 2)
        {
            coeur2.SetActive(true);
            coeur2vide.SetActive(false);
        }
        else
        {
            coeur2.SetActive(false);
            coeur2vide.SetActive(true);
        }
        if (life >= 3)
        {
            coeur3.SetActive(true);
            coeur3vide.SetActive(false);
        }
        else
        {
            coeur3.SetActive(false);
            coeur3vide.SetActive(true);
        }
        if (life >= 4)
        {
            coeur4.SetActive(true);
        }
        else
        {
            coeur4.SetActive(false);
        }
        if (life == 5)
        {
            coeur5.SetActive(true);
        }
        else
        {
            coeur5.SetActive(false);
        }
    }
}
