using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private int speed;
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }

    // Update is called once per frame
    void Update()
    {
    }

   /* public void OnBecameInvisible()
    {
        Destroy(gameObject, 5);
    }*/
}
