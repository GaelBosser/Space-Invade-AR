using System.Collections.Generic;
using UnityEngine;

public class BonusSpawnScript : MonoBehaviour
{
    [SerializeField]
    private GameObject bonusPrefab;

    [SerializeField]
    private List<GameObject> bonusSpawnPoints;

    private int selectedBonusSpawn = -1;
    private int lastIndex = -1;
    private float timerBetweenBonusSpawns = 0f;
    private float bonusLifeTime = 0f;
    private float nextBonusSpawnTimer = 0f;

    void Start()
    {
        switch (GameManager.Instance.difficulty)
        {
            case Difficulty.Easy:
                timerBetweenBonusSpawns = 30f;
                bonusLifeTime = 10f;
                break;

            case Difficulty.Normal:
                timerBetweenBonusSpawns = 45f;
                bonusLifeTime = 7.5f;
                break;

            case Difficulty.Hard:
                timerBetweenBonusSpawns = 60f;
                bonusLifeTime = 5f;
                break;

            default:
                timerBetweenBonusSpawns = 300f;
                bonusLifeTime = 3f;
                break;
        }
    }

    void Update()
    {
        if (GameManager.Instance.gameProgress == GameProgress.InProgress)
        {
            if (nextBonusSpawnTimer <= 0)
            {
                do
                {
                    selectedBonusSpawn = Random.Range(0, bonusSpawnPoints.Count);
                } while (selectedBonusSpawn == lastIndex);

                lastIndex = selectedBonusSpawn;
                GameObject newBonus = Instantiate(bonusPrefab, bonusSpawnPoints[selectedBonusSpawn].transform.position, bonusSpawnPoints[selectedBonusSpawn].transform.rotation);
                Destroy(newBonus, bonusLifeTime);
                nextBonusSpawnTimer = timerBetweenBonusSpawns;
            }
            else
            {
                nextBonusSpawnTimer -= Time.deltaTime;
            }
        }
    }
}
