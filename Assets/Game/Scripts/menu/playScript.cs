using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        SceneManager.LoadScene("Robin");
        GameManager.Instance.gameProgress = GameProgress.InProgress;
    }
}
