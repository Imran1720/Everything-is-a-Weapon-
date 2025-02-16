using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [Header("MOVEMENT-INFO")]
    [SerializeField]
    private float moveSpeed;
    private float xInput;
    private float yInput;
    private float speedMultiplier = 100f;


    private void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        SetVelocity(xInput, yInput);
    }

    private void SetVelocity(float xInput, float yInput)
    {
        Vector2 speed = new Vector2(xInput, yInput).normalized;
        speed *= speedMultiplier * moveSpeed * Time.deltaTime;
        rb.velocity = speed;
    }
}
