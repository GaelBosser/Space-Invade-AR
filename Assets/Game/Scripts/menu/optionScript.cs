using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionScript : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        SceneManager.LoadScene("Options");
    }
}
