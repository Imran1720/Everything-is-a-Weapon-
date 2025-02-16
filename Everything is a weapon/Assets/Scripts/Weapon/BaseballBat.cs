using UnityEngine;

public class BaseballBat : MonoBehaviour
{


    [SerializeField]
    int power;
    [SerializeField]
    int strength;
    [SerializeField]
    int weaponWearAmount;

    private void Update()
    {
        if (strength <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void DecreaseWeaponStrength()
    {
        strength -= weaponWearAmount;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        enemy.TakeDamage(power);
        DecreaseWeaponStrength();
    }
}
