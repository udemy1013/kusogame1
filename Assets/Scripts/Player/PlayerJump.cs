using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 5f;
    public float jumpAngle = 45f;
    public float maxVerticalVelocity = 10f;
    public float maxHorizontalVelocity = 5f;

    private Rigidbody2D rb;

    // ジャンプの効果音
    public AudioClip jumpSound;
    private AudioSource audioSource;

    // Rocketアイテムに関連する変数
    public bool isRocketActive = false; // Rocketアイテムが有効かどうかを示すフラグ
    public float rocketSpeed = 3f; // Rocketアイテムの推進力

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (isRocketActive)
        {
            // Rocketアイテムが有効な場合、一定のスピードでy軸上方向に移動する
            rb.velocity = new Vector2(rb.velocity.x, rocketSpeed);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // マウスの位置によってジャンプする方向を変える
            if (mousePosition.x > 0)
            {
                // 右側をクリックした場合
                Jump(1f);
            }
            else
            {
                // 左側をクリックした場合
                Jump(-1f);
            }
        }
    }

    private void Jump(float direction)
    {
        // 縦方向の速度を設定する
        float newVerticalVelocity = maxVerticalVelocity;
        rb.velocity = new Vector2(rb.velocity.x, newVerticalVelocity);

        // 左右の移動力を設定する
        float newHorizontalVelocity = direction * maxHorizontalVelocity;
        rb.velocity = new Vector2(newHorizontalVelocity, rb.velocity.y);

        // ジャンプ効果音を再生する
        if (audioSource != null && jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }
}