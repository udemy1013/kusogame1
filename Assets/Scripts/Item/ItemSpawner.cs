using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs; // アイテムのプレハブの配列
    public float spawnInterval = 1f;
    public float itemSpacing = 1f;
    public float moveSpeed = 2f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnItems();
            timer = 0f;
        }
    }

    private void SpawnItems()
    {
        // ランダムに3つのアイテムを選択
        GameObject[] selectedItems = GetRandomItems(3);

        for (int i = -1; i <= 1; i++)
        {
            Vector3 spawnPosition = transform.position + new Vector3(i * itemSpacing, 0f, 10f);
            GameObject item = Instantiate(selectedItems[i + 1], spawnPosition, Quaternion.identity);
            ItemController itemController = item.GetComponent<ItemController>();
            itemController.SetMoveSpeed(moveSpeed);
        }
    }

    private GameObject[] GetRandomItems(int count)
    {
        // アイテムのプレハブの配列をシャッフル
        GameObject[] shuffledItems = new GameObject[itemPrefabs.Length];
        itemPrefabs.CopyTo(shuffledItems, 0);
        ShuffleArray(shuffledItems);

        // 指定された数のアイテムを選択
        GameObject[] selectedItems = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            selectedItems[i] = shuffledItems[i];
        }

        return selectedItems;
    }

    private void ShuffleArray(GameObject[] array)
    {
        // Fisher-Yatesアルゴリズムを使用して配列をシャッフル
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            GameObject temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
}