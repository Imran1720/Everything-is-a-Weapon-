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

    [SerializeField]
    float duration;
    float timer;
    public bool isEquipped;

    private void Start()
    {
        UpdateSprite();
        timer = duration;
    }
    protected void Update()
    {

        timer -= Time.deltaTime;
        if (timer < 0 && !isEquipped)
        {
            Destroy(gameObject);
        }
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
