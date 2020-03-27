using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject missile;

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
            Instantiate(missile, transform.position, transform.rotation);
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