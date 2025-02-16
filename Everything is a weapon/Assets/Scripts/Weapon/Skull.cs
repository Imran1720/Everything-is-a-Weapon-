using UnityEngine;

public class Skull : MonoBehaviour
{
    [SerializeField]
    protected Weapontype weaponType;
    [SerializeField]
    protected Sprite weaponSprite;

    [SerializeField]
    float defaultAreaOfImpact;
    [SerializeField]
    float increasedAreaOfImpact;
    [SerializeField]
    protected float throwForce;
    [SerializeField]
    protected int damage;

    [SerializeField]
    protected Rigidbody2D rb;
    [SerializeField]
    CircleCollider2D circleCollider;

    [SerializeField]
    private Animator animator;

    bool canThrow = false;


    private void Start()
    {
        circleCollider.radius = defaultAreaOfImpact;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && canThrow)
        {
            ThrowProjectile();
        }

    }

    private void ThrowProjectile()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = target - transform.position;
        rb.AddForce(direction * throwForce, ForceMode2D.Impulse);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            rb.velocity = Vector2.zero;

            circleCollider.radius = increasedAreaOfImpact;
            collision.GetComponent<Enemy>().TakeDamage(damage);
            animator.SetTrigger("Explode");
        }
        if (collision.GetComponent<Player>() != null)
        {
            canThrow = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            canThrow = false;
        }
    }

    public void DestroyThisObject()
    {
        Destroy(gameObject);
    }


}
