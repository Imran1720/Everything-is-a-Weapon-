using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    protected Weapontype weaponType;
    [SerializeField]
    protected Sprite weaponSprite;

    [Header("WEAPON DETAILS")]

    [SerializeField]
    protected int power;
    [SerializeField]
    protected int strength;
    [SerializeField]
    protected int weaponWearAmount;

    private void Start()
    {
        UpdateSprite();
    }
    protected void Update()
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
    public void UpdateSprite()
    {
        GetComponentInChildren<SpriteRenderer>().sprite = weaponSprite;
    }


}

public enum Weapontype
{
    Bat,
    Torch,
    Skull,
    Rocks

}
