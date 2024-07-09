using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float invincibilityDuration = 1f;
    public float blinkInterval = 0.2f;

    private SpriteRenderer spriteRenderer;
    private bool isInvincible = false;

    public Vector3 toVec;
    public float forceHeight = 1.3f;
    public float forcePower = 10f;

    private ItemManager itemManager;

    public GameObject condomeUI;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        itemManager = FindObjectOfType<ItemManager>();

        condomeUI = GameObject.Find(GameManager.instance.playerData.condomeUIName);
        if (condomeUI != null)
        {
            condomeUI.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (itemManager.IsStarEffectActive())
            {
                Vector3 knockbackDirection = GetAngleVec(gameObject, collision.gameObject);
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(knockbackDirection * forcePower + Vector3.up * forceHeight, ForceMode2D.Impulse);
            }
            else if (!isInvincible)
            {
                TakeDamage(1);
                if (GameManager.instance.playerData.currentLife > 0)
                {
                    StartCoroutine(InvincibilityBlink());
                }
            }
        }
        else if (collision.gameObject.name == "BottomDeathZone")
        {
            TakeDamage(GameManager.instance.playerData.currentLife);
        }
    }

    private void TakeDamage(int damage)
    {
        if (GameManager.instance.playerData.isProtected)
        {
            GameManager.instance.playerData.isProtected = false;
            if (condomeUI != null)
            {
                condomeUI.SetActive(false);
            }
            return;
        }

        GameManager.instance.playerData.currentLife -= damage;
        if (GameManager.instance.playerData.currentLife <= 0)
        {
            GameManager.instance.playerData.currentLife = 0;
            OnGameOver();
        }
    }

    private void OnGameOver()
    {
        // プレイヤーオブジェクトを非アクティブにする
        gameObject.SetActive(false);

        // GameManagerのGameOver処理を呼び出す
        GameManager.instance.GameOver();
    }

    private IEnumerator InvincibilityBlink()
    {
        isInvincible = true;
        float elapsedTime = 0f;
        while (elapsedTime < invincibilityDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }
        spriteRenderer.enabled = true;
        isInvincible = false;
    }

    private Vector3 GetAngleVec(GameObject _from, GameObject _to)
    {
        Vector3 fromVec = new Vector3(_from.transform.position.x, _from.transform.position.y, 0);
        Vector3 toVec = new Vector3(_to.transform.position.x, _to.transform.position.y, 0);

        return Vector3.Normalize(toVec - fromVec);
    }
}