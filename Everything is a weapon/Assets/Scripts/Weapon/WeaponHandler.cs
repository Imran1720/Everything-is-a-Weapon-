using UnityEngine;

public class WeaponHandler : MonoBehaviour
{

    [SerializeField]
    private Animator weaponAnimator;

    [SerializeField]
    private TrailRenderer trailRenderer;

    private Player player;

    private bool canEquipWeapon = false;
    private bool isWeaponEquiped = false;
    [SerializeField]
    private Transform equipPoint;

    private void Start()
    {
        trailRenderer.enabled = false;
        player = GetComponentInParent<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isWeaponEquiped)
        {
            RotateWeapon();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            canEquipWeapon = true;
        }
    }

    private void RotateWeapon()
    {
        weaponAnimator.SetTrigger("Swing");
    }

    public void EnableSwingFX()
    {
        if (trailRenderer != null)
        {
            trailRenderer.enabled = true;
        }
    }

    public void DisableSwingFX()
    {
        if (trailRenderer != null)
        {
            trailRenderer.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Can equip weapon");
        if (collision.GetComponent<Weapon>() != null && canEquipWeapon)
        {
            Weapon weapon = collision.GetComponent<Weapon>();
            canEquipWeapon = false;
            isWeaponEquiped = true;

            weapon.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));
            weapon.gameObject.transform.position = equipPoint.position;
            weapon.gameObject.transform.parent = this.transform;


        }
    }

    public void UnequipWeapon()
    {
        isWeaponEquiped = false;
    }
}