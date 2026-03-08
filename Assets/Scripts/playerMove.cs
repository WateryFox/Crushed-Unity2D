using UnityEngine;
using UnityEngine.AI;

public class playerMove : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
        }
    }

    public void platformMove(float x)
    {
        rb.linearVelocity = new Vector2(x, rb.linearVelocity.y);
    }
}
