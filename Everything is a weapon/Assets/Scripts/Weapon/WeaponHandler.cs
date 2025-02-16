using UnityEngine;

public class WeaponHandler : MonoBehaviour
{

    [SerializeField]
    private Animator weaponAnimator;

    [SerializeField]
    private TrailRenderer trailRenderer;

    private Player player;

    private void Start()
    {
        trailRenderer.enabled = false;
        player = GetComponentInParent<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
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
}