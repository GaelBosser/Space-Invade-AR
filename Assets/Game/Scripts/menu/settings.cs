using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{

    public static bool mute;
    public static Difficulty difficulty;
    private bool isFirstLoad;

    // Start is called before the first frame update
    void Start()
    {
        if (isFirstLoad)
        {
            ActivateSound();
            SetDifficultyEasy();
            isFirstLoad = false;
        }
        else
        {
            if (mute)
            {
                MuteSound();
            }
            else
            {
                ActivateSound();
            }

            switch (difficulty)
            {
                case Difficulty.Easy:
                    SetDifficultyEasy();
                    break;
                case Difficulty.Normal:
                    SetDifficultyNormal();
                    break;
                case Difficulty.Hard:
                    SetDifficultyHard();
                    break;
            }
        }
    }

    public void ActivateSound()
    {
        mute = false;
        GameObject.FindGameObjectWithTag("soundActivate").GetComponent<Image>().color = Color.green;
        GameObject.FindGameObjectWithTag("soundMute").GetComponent<Image>().color = Color.white;
    }

    public void MuteSound()
    {
        mute = true;
        GameObject.FindGameObjectWithTag("soundMute").GetComponent<Image>().color = Color.green;
        GameObject.FindGameObjectWithTag("soundActivate").GetComponent<Image>().color = Color.white;
    }

    public void SetDifficultyEasy()
    {
        difficulty = Difficulty.Easy;
        GameObject.FindGameObjectWithTag("difficultyEasy").GetComponent<Image>().color = Color.green;
        GameObject.FindGameObjectWithTag("difficultyNormal").GetComponent<Image>().color = Color.white;
        GameObject.FindGameObjectWithTag("difficultyHard").GetComponent<Image>().color = Color.white;
    }

    public void SetDifficultyNormal()
    {
        difficulty = Difficulty.Normal;
        GameObject.FindGameObjectWithTag("difficultyEasy").GetComponent<Image>().color = Color.white;
        GameObject.FindGameObjectWithTag("difficultyNormal").GetComponent<Image>().color = Color.green;
        GameObject.FindGameObjectWithTag("difficultyHard").GetComponent<Image>().color = Color.white;
    }

    public void SetDifficultyHard()
    {
        difficulty = Difficulty.Hard;
        GameObject.FindGameObjectWithTag("difficultyEasy").GetComponent<Image>().color = Color.white;
        GameObject.FindGameObjectWithTag("difficultyNormal").GetComponent<Image>().color = Color.white;
        GameObject.FindGameObjectWithTag("difficultyHard").GetComponent<Image>().color = Color.green;
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
