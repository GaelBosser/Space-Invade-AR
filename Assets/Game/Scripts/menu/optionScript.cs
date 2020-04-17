using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OptionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnMouseUpAsButton()
    {
        SceneManager.LoadScene("Options");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
