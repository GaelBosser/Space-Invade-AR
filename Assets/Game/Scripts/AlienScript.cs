using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    public int score;
    private int damageDone = 1;
    public float speed = 0.5f;

    void Awake()
    {
        switch (GameManager.Instance.difficulty)
        {
            case Difficulty.Easy:
                score = 100;
                speed = 0.5f;
                break;
            case Difficulty.Normal:
                score = 250;
                speed = 0.8f;
                break;
            case Difficulty.Hard:
                score = 500;
                speed = 1f;
                break;
            default:
                score = 200;
                speed = 2f;
                break;
        }

    }

    void Update()
    {
        if(GameManager.Instance.gameProgress == GameProgress.InProgress)
        {
            transform.LookAt(GameManager.Instance.player.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.player.transform.position, speed * Time.deltaTime);
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
            Destroy(this.gameObject);
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
