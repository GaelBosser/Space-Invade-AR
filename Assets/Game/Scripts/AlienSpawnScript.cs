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
    private float nextSpawnTimer;

    void Start()
    {

    }

    void Update()
    {
        if (nextSpawnTimer < Time.time && GameManager.Instance.gameProgress == GameProgress.InProgress)
        {
            do
            {
                selectedIndex = Random.Range(0, spawnPoints.Count - 1);
            } while (selectedIndex == lastIndex);

            lastIndex = selectedIndex;
            Instantiate(alienPrefab, spawnPoints[selectedIndex].transform.position, spawnPoints[selectedIndex].transform.rotation); //This spawns the emeny
            nextSpawnTimer = Time.time + timerBetweenSpawns; //This sets the timer 3 seconds into the future
        }
    }
}
