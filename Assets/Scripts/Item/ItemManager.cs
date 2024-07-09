using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour
{

    // アイテム全般に関連する変数
    private GameObject playerObject; // プレイヤーオブジェクト

    // メガネアイテムに関連する変数
    public float spawnStopDuration = 3f; // スポーン停止時間（インスペクターから編集可能）
    public float glassEffectDuration = 5f; // Glassアイテムの効果時間
    public float enemySizeMultiplier = 0.5f; // 敵のサイズ倍率 

    // チリトリアイテムに関連する変数
    private EnemySpawner enemySpawner;
    private bool isSpawnStopped = false;

    // Gunアイテムに関連する変数
    public float gunEffectDuration = 5f; // Gunアイテムの効果時間
    public float gunBulletSpeed = 10f; // 弾の速度
    public float gunFireRate = 0.8f; // 弾の発射間隔
    public GameObject gunBulletPrefab; // 弾のプレファブ

    // condomeアイテムに関連する変数
    private GameObject condomeUI; // condomeUIのゲームオブジェクト

    // Starアイテムに関連する変数
    public Material rainbowMaterial; // 虹色のマテリアル
    public float starEffectDuration = 5f; // Starアイテムの効果時間
    private SpriteRenderer playerRenderer;  // プレイヤーのSpriteRenderer
    private Material originalMaterial;  // プレイヤーの元のマテリアル
    public float starKnockbackForce = 10f; // Starアイテムのノックバック力
    private bool isStarEffectActive = false; // Starアイテムの効果がアクティブかどうか

    // Phillアイテムに関連する変数
    [Header("ピルアイテムの設定")]
    public float pillEffectDuration = 5f; // Pillアイテムの効果時間
    public float pillSizeMultiplier = 0.5f; // Pillアイテムのサイズ倍率
    private Vector3 playerOriginalScale; // プレイヤーの元のサイズ

    // Rocketアイテムに関連する変数
    [Header("ロケットアイテムの設定")]
    public float rocketEffectDuration = 5f; // Rocketアイテムの効果時間

    // Timeアイテムに関連する変数
    [Header("タイムアイテムの設定")]
    public float timeEffectDuration = 5f; // timeアイテムの効果時間
    public float slowTimeScale = 0.7f; // スロー時のゲームスピードの倍率
    public float fastTimeScale = 1.3f; // 高速時のゲームスピードの倍率

    private Player player;

    private void Start()
    {
        // EnemySpawnerコンポーネントを取得
        enemySpawner = FindObjectOfType<EnemySpawner>();

        // プレイヤーオブジェクトを取得
        playerObject = GameObject.FindGameObjectWithTag("Player");

        // プレイヤーの元のサイズを保存
        playerOriginalScale = playerObject.transform.localScale;

        // プレイヤーのSpriteRendererを取得
        playerRenderer = playerObject.GetComponent<SpriteRenderer>();
        // プレイヤーの元のマテリアルを保存
        originalMaterial = playerRenderer.material;
        // Playerコンポーネントを取得
        player = FindObjectOfType<Player>();

    }

    public enum ItemType
    {
        Clean,
        Condome,
        DoubleUp,
        Glass,
        Gun,
        HeartIncrease,
        HeartDecrease,
        Pill,
        Rocket,
        Score500,
        Star,
        Time,
        Everything,

    }

    public void ApplyItemEffect(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Clean:
                ApplyClean();
                break;
            case ItemType.Condome:
                ApplyCondome();
                break;
            case ItemType.DoubleUp:
                ApplyDoubleUp();
                break;
            case ItemType.Glass:
                ApplyGlass();
                break;
            case ItemType.Gun:
                ApplyGun();
                break;
            case ItemType.HeartIncrease:
                ApplyIncreaseHeart();
                break;
            case ItemType.HeartDecrease:
                ApplyDecreaseHeart();
                break;
            case ItemType.Pill:
                ApplyPill();
                break;
            case ItemType.Rocket:
                ApplyRocket();
                break;
            case ItemType.Score500:
                ApplyScore500();
                break;
            case ItemType.Star:
                ApplyStar();
                break;
            case ItemType.Time:
                ApplyTime();
                break;
            case ItemType.Everything:
                ApplyEverything();
                break;
        }
    }

    // Cleanアイテムの効果
    private void ApplyClean()
    {
        // 現在のシーン内の全てのEnemyタグを持つオブジェクトを削除
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        // スポーンを停止
        if (!isSpawnStopped)
        {
            isSpawnStopped = true;
            StartCoroutine(StopSpawn());
        }
    }

    // 敵のスポーンを停止する
    private IEnumerator StopSpawn()
    {
        // EnemySpawnerのスポーンを停止
        enemySpawner.StopSpawning();

        // 指定された時間だけ待機
        yield return new WaitForSeconds(spawnStopDuration);

        // EnemySpawnerのスポーンを再開
        enemySpawner.StartSpawning();
        isSpawnStopped = false;
    }

    private void ApplyCondome()
    {
        GameManager.instance.playerData.isProtected = true;

        Debug.Log("condomeUI: " + player.condomeUI);
        if (player != null && player.condomeUI != null)
        {
            player.condomeUI.SetActive(true); // condomeUIを表示
        }
    }

    private void ApplyDoubleUp()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.ActivateDoubleUp();
        }
    }
    private void ApplyGlass()
    {
        StartCoroutine(ApplyGlassEffect());
    }

    private IEnumerator ApplyGlassEffect()
    {
        // 敵のサイズを変更
        EnemySpawner.Instance.SetEnemySize(enemySizeMultiplier);

        // 効果時間だけ待機
        yield return new WaitForSeconds(glassEffectDuration);

        // 敵のサイズを元に戻す
        EnemySpawner.Instance.SetEnemySize(1f);
    }

    // IncreaseHeartアイテムの効果
    private void ApplyIncreaseHeart()
    {
        if (GameManager.instance.playerData.currentLife < GameManager.instance.playerData.maxLife)
        {
            GameManager.instance.playerData.currentLife++;
        }
    }

    // DecreaseHeartアイテムの効果
    private void ApplyDecreaseHeart()
    {
        GameManager.instance.playerData.currentLife--;
    }

    // Gunアイテムの効果
    private void ApplyGun()
    {
        StartCoroutine(ShootGunBullets());
    }

    private IEnumerator ShootGunBullets()
    {
        float elapsedTime = 0f;

        while (elapsedTime < gunEffectDuration)
        {
            if (playerObject != null)
            {
                Transform playerTransform = playerObject.transform;
                Vector3 playerPosition = playerTransform.position;
                Quaternion playerRotation = playerTransform.rotation;

                // 弾を生成
                GameObject bullet = Instantiate(gunBulletPrefab, playerPosition, playerRotation);

                // 弾に速度を与える
                Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
                bulletRigidbody.velocity = playerTransform.up * gunBulletSpeed;
                Debug.Log("bulletRigidbody.velocity: " + bulletRigidbody.velocity);
                // 一定時間後に弾を削除
                Destroy(bullet, 5f);
            }

            // 次の弾発射までの間隔
            yield return new WaitForSeconds(gunFireRate);

            elapsedTime += gunFireRate;
        }
    }

    // Pillの効果を適用する

    private void ApplyPill()
    {
        StartCoroutine(ApplyPillEffect());
    }
    private IEnumerator ApplyPillEffect()
    {
        Debug.Log("Pillアイテムの効果を適用");

        // プレイヤーのサイズを変更
        playerObject.transform.localScale *= pillSizeMultiplier;

        // 効果時間だけ待機
        yield return new WaitForSeconds(pillEffectDuration);

        // プレイヤーのサイズを元に戻す
        playerObject.transform.localScale = playerOriginalScale;


    }

    // Rocketの効果を適用する
    private void ApplyRocket()
    {
        StartCoroutine(ApplyRocketEffect());
    }

    private IEnumerator ApplyRocketEffect()
    {
        PlayerJump playerJump = playerObject.GetComponent<PlayerJump>();
        if (playerJump != null)
        {
            playerJump.isRocketActive = true;
            yield return new WaitForSeconds(rocketEffectDuration);
            playerJump.isRocketActive = false;
        }
    }

    // Score500の効果を適用する
    private void ApplyScore500()
    {
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddScore(500);
        }
    }

    // Starの効果を適用する
    private void ApplyStar()
    {
        StartCoroutine(ApplyStarEffect());
    }

    // Starアイテムの効果
    private IEnumerator ApplyStarEffect()
    {
        // プレイヤーのマテリアルを虹色に変更
        playerRenderer.material = rainbowMaterial;


        // スターの効果を有効にする
        isStarEffectActive = true;

        // すべての敵のisTriggerをtrueに設定
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Collider2D enemyCollider = enemy.GetComponent<Collider2D>();
            if (enemyCollider != null)
            {
                enemyCollider.isTrigger = false;
            }
        }

        // 効果時間の開始時刻を記録
        float startTime = Time.time;

        // 効果時間が終了するまでループ
        while (Time.time < startTime + starEffectDuration)
        {
            yield return null;
        }

        // スターの効果を無効にする
        isStarEffectActive = false;

        // すべての敵のisTriggerをfalseに設定
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Collider2D enemyCollider = enemy.GetComponent<Collider2D>();
            if (enemyCollider != null)
            {
                enemyCollider.isTrigger = true;
            }
        }

        // プレイヤーのマテリアルを元に戻す
        playerRenderer.material = originalMaterial;
    }
    public bool IsStarEffectActive()
    {
        return isStarEffectActive;
    }


    private void ApplyTime()
    {
        StartCoroutine(ApplyTimeEffect());
    }

    private IEnumerator ApplyTimeEffect()
    {
        // ランダムに0.7か1.3のゲームスピードを選択
        float selectedTimeScale = Random.value < 0.5f ? slowTimeScale : fastTimeScale;

        // ゲームスピードを変更
        Time.timeScale = selectedTimeScale;

        // 効果時間だけ待機
        yield return new WaitForSecondsRealtime(timeEffectDuration);

        // ゲームスピードを元に戻す
        Time.timeScale = 1f;
    }

    private void ApplyEverything()
    {
        // ItemType列挙型の値を配列に取得
        ItemType[] itemTypes = (ItemType[])System.Enum.GetValues(typeof(ItemType));

        // Everythingを除外した配列を作成
        ItemType[] excludedItemTypes = System.Array.FindAll(itemTypes, i => i != ItemType.Everything);

        // ランダムに3種類のアイテムを選択
        for (int i = 0; i < 3; i++)
        {
            int randomIndex = Random.Range(0, excludedItemTypes.Length);
            ItemType randomItemType = excludedItemTypes[randomIndex];

            // 選択されたアイテムの効果を適用
            ApplyItemEffect(randomItemType);

            // 選択されたアイテムを配列から除外
            excludedItemTypes = System.Array.FindAll(excludedItemTypes, i => i != randomItemType);
        }
    }

}