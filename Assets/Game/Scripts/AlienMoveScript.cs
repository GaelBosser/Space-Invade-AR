using UnityEngine;

public class AlienMoveScript : MonoBehaviour
{
    public float speed = 0.5f;
    // Start is called before the first frame update
    void Awake()
    {
        switch (GameManager.Instance.difficulty)
        {
            case Difficulty.Easy:
                speed = 0.5f;
                break;
            case Difficulty.Normal:
                speed = 0.8f;
                break;
            case Difficulty.Hard:
                speed = 1f;
                break;
            default:
                speed = 2f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameProgress == GameProgress.InProgress)
        {
            transform.LookAt(GameManager.Instance.player.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, GameManager.Instance.player.transform.position, speed * Time.deltaTime);
        }
    }
}
