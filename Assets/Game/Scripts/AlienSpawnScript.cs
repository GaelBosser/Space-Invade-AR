using System.Collections.Generic;
using UnityEngine;

public class AlienSpawnScript : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> alienPrefabs;

    [SerializeField]
    private List<GameObject> spawnPoints;

    private int selectedSpawn = -1;
    private int selectedAlien = -1;
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
                    selectedSpawn = Random.Range(0, spawnPoints.Count);
                } while (selectedSpawn == lastIndex);

                selectedAlien = Random.Range(0, alienPrefabs.Count);

                lastIndex = selectedSpawn;
                Instantiate(alienPrefabs[selectedAlien], spawnPoints[selectedSpawn].transform.position, spawnPoints[selectedSpawn].transform.rotation);
                nextSpawnTimer = timerBetweenSpawns;
            } else
            {
                nextSpawnTimer -= Time.deltaTime;
            }
        }
    }
}
