using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField]
    private Animator weaponAnimator;

    [SerializeField]
    private TrailRenderer trailRenderer;


    public bool isWeaponEquiped = false;
    [SerializeField]
    private Transform equipPoint;


    private void Start()
    {
        trailRenderer.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isWeaponEquiped)
        {
            RotateWeapon();
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

        if (collision.GetComponent<Weapon>() != null)
        {
            Weapon weapon = collision.GetComponent<Weapon>();

            if (!isWeaponEquiped)
            {
                weapon.isEquipped = true;
                weapon.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));
                weapon.gameObject.transform.position = equipPoint.position;
                weapon.gameObject.transform.parent = this.transform;
            }

            isWeaponEquiped = true;

        }
    }

    public void UnequipWeapon()
    {
        isWeaponEquiped = false;
    }
}