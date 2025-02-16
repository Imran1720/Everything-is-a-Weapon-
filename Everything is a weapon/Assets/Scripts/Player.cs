using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    int health;

    [Header("MOVEMENT-INFO")]
    [SerializeField]
    private float moveSpeed;
    private float horizontalInput;
    private float verticalInput;
    private float speedMultiplier = 100f;


    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        MovePlayer(horizontalInput, verticalInput);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
        Flip();
    }

    private void MovePlayer(float xInput, float yInput)
    {
        Vector2 speed = new Vector2(xInput, yInput).normalized;
        speed *= speedMultiplier * moveSpeed * Time.deltaTime;
        rb.velocity = speed;
    }

    void Attack()
    {
        Debug.Log("Attacking Enemy");

    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Player took damage!! -" + damage);
        DecreaseHealth(damage);
    }

    void DecreaseHealth(int damage)
    {
        health -= damage;
        Debug.Log("Player health after damage : " + health + " !!");
    }

    void Flip()
    {
        Vector2 localscale = transform.localScale;
        if (horizontalInput > 0 && localscale.x < 0)
        {
            localscale.x = 1;
        }
        if (horizontalInput < 0 && localscale.x > 0)
        {
            localscale.x = -1;
        }
        transform.localScale = localscale;
    }

}
