using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawnScript : MonoBehaviour
{
    [SerializeField]
    private GameObject alienPrefab;

    [SerializeField]
    private List<GameObject> spawnPoints;

    private int selectedIndex = -1;
    private int lastIndex = -1;
    private float timerBetweenSpawns = 2f;
    private float nextSpawnTimer = 0f;

    void Start()
    {

    }

    void Update()
    {
        if (GameManager.Instance.gameProgress == GameProgress.InProgress)
        {
            if(nextSpawnTimer <= 0)
            {
                do
                {
                    selectedIndex = Random.Range(0, spawnPoints.Count);
                } while (selectedIndex == lastIndex);

                lastIndex = selectedIndex;
                Instantiate(alienPrefab, spawnPoints[selectedIndex].transform.position, spawnPoints[selectedIndex].transform.rotation);
                nextSpawnTimer = timerBetweenSpawns;
            } else
            {
                nextSpawnTimer -= Time.deltaTime;
            }
        }
    }
}
