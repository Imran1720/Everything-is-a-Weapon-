using UnityEngine;

public class BaseballBat : Weapon
{

    private void Update()
    {
        if (strength <= 0)
        {
            GetComponentInParent<WeaponHandler>().UnequipWeapon();
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
        if (enemy != null)
        {
            enemy.TakeDamage(power);
            DecreaseWeaponStrength();
        }
    }
}
