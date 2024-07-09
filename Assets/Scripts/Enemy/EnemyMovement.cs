using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 移動速度

    private Rigidbody2D rb;

    private bool isContactedWithPlayer = false;

    private void Start()
    {
        // Rigidbody2Dコンポーネントを取得
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!isContactedWithPlayer)
        {
            // 一定速度で下に移動
            Vector2 movement = new Vector2(0f, -moveSpeed) * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isContactedWithPlayer = true;
        }
    }


}
