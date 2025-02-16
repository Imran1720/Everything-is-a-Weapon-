using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject bomb;

    [Header("Range-Info")]
    [SerializeField]
    float minXRange;
    [SerializeField]
    float maxXRange;
    [SerializeField]
    float minYRange;
    [SerializeField]
    float maxYRange;

    [SerializeField]
    float duration;
    float timer;
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnBomb();
        }
    }

    private void SpawnBomb()
    {
        timer = duration;
        float randomXCordinate = Random.Range(minXRange, maxXRange);
        float randomYCordinate = Random.Range(minYRange, maxYRange);
        Vector2 position = new Vector2(randomXCordinate, randomYCordinate);
        Instantiate(bomb, position, Quaternion.identity);
    }
}
