using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    public static ScoreManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreManager>();
                if (_instance == null)
                {
                    _instance = new GameObject().AddComponent<ScoreManager>();
                }
            }

            return _instance;
        }
    }

    public Text scoreText;
    private int _score;
    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            if (GameManager.Instance.gameProgress == GameProgress.InProgress)
            {
                scoreText.text = $"Score: {_score}";
            }
        }
    }

    private void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        _score = 0;
    }
}
