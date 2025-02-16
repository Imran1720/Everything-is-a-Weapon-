using UnityEngine;

public class DropHandler : MonoBehaviour
{
    EnemyType enemyType;
    [SerializeField]
    private GameObject[] dropItems;



    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            Drop();
        }
    }

    public void Drop()
    {
        if (CanDropitem())
        {

        }
    }

    private bool CanDropitem()
    {

        float chance = Random.value;
        if (chance > 0.75f)
        {
            return true;
        }
        return false;
    }
}
