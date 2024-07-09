using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    public ItemManager.ItemType itemType;
    private ItemManager itemManager;

    private void Start()
    {
        itemManager = FindObjectOfType<ItemManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            itemManager.ApplyItemEffect(itemType);
            Destroy(gameObject);
        }
    }
}