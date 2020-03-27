using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject missilePrefab;

    [SerializeField]
    private GameObject bulletSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(missilePrefab, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
            Destroy(bullet, 5f);
        }

#elif UNITY_ANDROID || UNITY_IOS
        Touch touch = Input.touches[0];

        if(TouchPhase.Ended.Equals(touch.phase))
        {
            Instantiate(projectile, transform.position, transform.rotation);
        }
#endif
    }
}