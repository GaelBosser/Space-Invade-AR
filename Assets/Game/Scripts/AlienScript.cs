using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    public int score;
    private int damageDone = 1;

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

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player")) 
        {

            Debug.Log("Alien Collide player");
            other.gameObject.GetComponent<HealthScript>().UpdateLifeAndGetNewState(damageDone);
            /* TODO => 
             * Feedback dégâts subis/mort du joueur
             */
            Destroy(this.transform.parent.gameObject);
        }
    }

    /// <summary>
    /// Désactive/Active les renderers des aliens s'ils doivent être affichés à la camera
    /// </summary>
    /*public void OnBecameVisible()
    {
        MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
        renderer.enabled = true;
    }
    public void OnBecameInvisible()
    {
        MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
        renderer.enabled = false;
    }*/
}
