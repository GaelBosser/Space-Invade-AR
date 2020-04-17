using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnMouseUpAsButton()
    {
        SceneManager.LoadScene("Robin");
        GameManager.Instance.gameProgress = GameProgress.InProgress;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
