using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameObject target;

    [SerializeField]
    private int health;


    [SerializeField]
    private float impact;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindAnyObjectByType<Player>().gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        // Attack();
    }

    void Move()
    {
        if (Vector2.Distance(target.transform.position, transform.position) > 1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        }

    }
    void Attack()
    {
        if (Vector2.Distance(target.transform.position, transform.position) <= 1.5f)
        {
            Debug.Log("Attacking Player");
        }
    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("Hit");
        DecreaseHealth(damage);

    }

    void DecreaseHealth(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}

public enum EnemyType
{
    Goblin,
    skeleton
}
