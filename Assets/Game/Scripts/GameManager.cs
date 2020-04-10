using UnityEngine;

public enum Difficulty { Easy, Normal, Hard }
public enum GameProgress { NotStarted, InProgress, Paused, Ended }
public class GameManager : MonoBehaviour
{
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

        gameProgress = GameProgress.NotStarted;
    }

    private void Update()
    {
        if(gameProgress == GameProgress.Ended)
        {
            //ScoreManager.Instance.score;
        }
    }

}
