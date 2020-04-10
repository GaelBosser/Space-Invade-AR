using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private int speed;

    private int damageDone;
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);

        switch (GameManager.Instance.difficulty)
        {
            case Difficulty.Easy:
                damageDone = 3;
                break;
            case Difficulty.Normal:
                damageDone = 2;
                break;
            case Difficulty.Hard:
                damageDone = 1;
                break;
            default:
                damageDone = 2;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Alien")) {
            other.gameObject.GetComponent<HealthScript>().UpdateLifeAndGetNewState(damageDone);
            Destroy(this.gameObject);
        }
    }

    /* public void OnBecameInvisible()
     {
         Destroy(gameObject, 5);
     }*/
}
