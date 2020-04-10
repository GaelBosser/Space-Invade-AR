using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    public int score;
    private int damageDone = 1;

    // Update is called once per frame
    void Update()
    {
        //TODO se déplacer vers le joueur
    }

    void Awake()
    {
        switch (GameManager.Instance.difficulty)
        {
            case Difficulty.Easy:
                score = 100;
                break;
            case Difficulty.Normal:
                score = 250;
                break;
            case Difficulty.Hard:
                score = 500;
                break;
            default:
                score = 200;
                break;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player")) 
        {
            other.gameObject.GetComponent<HealthScript>().UpdateLifeAndGetNewState(damageDone);

            /* TODO => 
             * Feedback collision/mort de l'alien
             * Feedback dégâts subis/mort du joueur
             */

            Destroy(this);
        }
    }

    /// <summary>
    /// Désactive/Active les renderers des aliens s'ils doivent être affichés à la camera
    /// </summary>
    public void OnBecameVisible()
    {
        MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
        renderer.enabled = true;
    }
    public void OnBecameInvisible()
    {
        MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
        renderer.enabled = false;
    }
}
