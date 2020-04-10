using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public int score { get; set; }

    private void Awake()
    {
        if (_instance != null)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        score = 0;
    }
}
