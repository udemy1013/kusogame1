using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // 敵のプレハブの配列
    public float spawnInterval = 1f; // スポーン間隔（秒）
    public float spawnRangeX = 5f; // スポーン位置のX座標の範囲
    public float spawnOffsetY = 10f; // カメラ位置からのオフセットY座標
    public float intervalDecreaseTime = 0.5f; // スポーン間隔が減少する時間間隔
    public float intervalDecreaseAmount = 0.1f; // スポーン間隔の減少量
    public float minSpawnInterval = 0.1f; // 最小スポーン間隔

    private Vector3[] enemyOriginalScales; // 敵の元のサイズの配列
    private float currentEnemySizeMultiplier = 1f; // 現在の敵のサイズ倍率

    private Coroutine spawnEnemiesCoroutine; // 敵をスポーンさせるコルーチン
    private Coroutine decreaseSpawnIntervalCoroutine; // スポーン間隔を減少させるコルーチン

    private Camera mainCamera; // メインカメラへの参照

    public static EnemySpawner Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // メインカメラを取得
        mainCamera = Camera.main;

        // 敵の元のサイズを配列に保存
        enemyOriginalScales = new Vector3[enemyPrefabs.Length];
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            enemyOriginalScales[i] = enemyPrefabs[i].transform.localScale;
        }

        // 一定間隔で敵をスポーンさせるコルーチンを開始
        spawnEnemiesCoroutine = StartCoroutine(SpawnEnemies());

        // スポーン間隔を減少させるコルーチンを開始
        decreaseSpawnIntervalCoroutine = StartCoroutine(DecreaseSpawnInterval());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // ランダムなX座標を生成
            float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);

            // カメラの現在の位置を取得
            Vector3 cameraPos = mainCamera.transform.position;

            // 敵のスポーン位置を設定（カメラの位置から一定のオフセットを加える）
            Vector3 spawnPos = new Vector3(spawnPosX, cameraPos.y + spawnOffsetY, 0f);

            // ランダムな敵のプレハブを選択
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyPrefab = enemyPrefabs[randomIndex];

            // 敵を現在の大きさ比率でスポーン
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            enemy.transform.localScale = enemyOriginalScales[randomIndex] * currentEnemySizeMultiplier;

            if (IsStarEffectActive())
            {
                Collider2D enemyCollider = enemy.GetComponent<Collider2D>();
                if (enemyCollider != null)
                {
                    enemyCollider.isTrigger = false;
                }
            }

            // 次のスポーンまで待機
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // スポーンを停止する
    public void StopSpawning()
    {
        if (spawnEnemiesCoroutine != null)
        {
            StopCoroutine(spawnEnemiesCoroutine);
        }

        if (decreaseSpawnIntervalCoroutine != null)
        {
            StopCoroutine(decreaseSpawnIntervalCoroutine);
        }
    }

    // スポーンを開始する
    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(DecreaseSpawnInterval());
    }

    // スポーン頻度を高くする
    private IEnumerator DecreaseSpawnInterval()
    {
        while (spawnInterval > minSpawnInterval)
        {
            // 指定された時間間隔だけ待機
            yield return new WaitForSeconds(intervalDecreaseTime);

            // スポーン間隔を減少させる
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - intervalDecreaseAmount);
        }
    }

    public void SetEnemySize(float sizeMultiplier)
    {
        currentEnemySizeMultiplier = sizeMultiplier;
        // 現在のシーン内の全てのEnemyタグを持つオブジェクトのサイズを変更
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            int enemyIndex = System.Array.IndexOf(enemyPrefabs, enemy.gameObject);
            if (enemyIndex >= 0)
            {
                enemy.transform.localScale = enemyOriginalScales[enemyIndex] * sizeMultiplier;
            }
        }
    }

    private bool IsStarEffectActive()
    {
        ItemManager itemManager = FindObjectOfType<ItemManager>();
        if (itemManager != null)
        {
            return itemManager.IsStarEffectActive();
        }
        return false;
    }
}