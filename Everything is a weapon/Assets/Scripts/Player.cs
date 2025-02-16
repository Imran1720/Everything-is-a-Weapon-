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

        Flip();
    }

    private void MovePlayer(float xInput, float yInput)
    {
        Vector2 speed = new Vector2(xInput, yInput).normalized;
        speed *= moveSpeed;
        rb.velocity = speed;
    }



    public void TakeDamage(int damage)
    {
        DecreaseHealth(damage);
    }

    public void DecreaseHealth(int damage)
    {
        health -= damage;
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
