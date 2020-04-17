using UnityEngine;

public class BonusMoveScript : MonoBehaviour
{
    public float speed = 0.8f;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameProgress == GameProgress.InProgress)
        {
            if(transform.position.y > -2)
                transform.position = transform.position + new Vector3(0, speed * -1 * Time.deltaTime, 0);
            else
            {
                transform.Rotate(Vector3.up * Time.deltaTime * 30f);
            }
        }
    }
}
