using UnityEngine;

public class ItemController : MonoBehaviour
{
    private float moveSpeed;
    private Rigidbody2D rb;

    private void Start()
    {
        // Rigidbody2Dコンポーネントを取得
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // 一定速度で下に移動
        rb.velocity = new Vector2(0f, -moveSpeed);
    }

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }
}