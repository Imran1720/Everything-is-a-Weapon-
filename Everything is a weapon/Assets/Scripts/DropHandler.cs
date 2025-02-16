using UnityEngine;

public class DropHandler : MonoBehaviour
{
    EnemyType enemyType;
    [SerializeField]
    private GameObject[] dropItems;

    private int dropIndex;



    private void Start()
    {
        int randomValue = Random.Range(0, 100);
        if (randomValue < 50)
        {
            dropIndex = 0;
        }
        else
        {
            dropIndex = 1;
        }
    }
    private void OnDestroy()
    {
        Instantiate(dropItems[dropIndex], transform.position, Quaternion.identity);
    }

}
