using UnityEngine;
using UnityEngine.UI;

public enum Difficulty { Easy, Normal, Hard }
public enum GameProgress { NotStarted, InProgress, Paused, Ended }


public class GameManager : MonoBehaviour
{
    public GameObject player;

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

    public Difficulty difficulty;
    public GameProgress gameProgress;

    private void Awake()
    {
        if (_instance != null) Destroy(this);
        DontDestroyOnLoad(this);

        difficulty = Difficulty.Normal;

        gameProgress = GameProgress.InProgress;
    }

    void Update()
    {
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
        if (life == 5)
        {
            coeur5.SetActive(true);
        }
    }
}
