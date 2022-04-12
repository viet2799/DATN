using UnityEngine;

public class movePlayer : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontalValue;
    bool facingRight = true;
    [SerializeField] private float speed = 1;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        Debug.Log(horizontalValue);
    }
    
    void FixedUpdate()
    {
        Move(horizontalValue);
    }
    void Move(float dir)
    {
        float xVal = dir * speed;
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
        rb.velocity = targetVelocity;

        if(facingRight && dir <0)
        {

        }
    }
}
