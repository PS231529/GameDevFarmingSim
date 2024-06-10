using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickUpDistance = 1.5f;
    [SerializeField] float ttl = 10f;

    public Item item;
    public int count = 1;


    public void Awake()
    {
        player = GameManager.instance.player.transform;
    }

    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (renderer != null && item.icon != null)
        {
            renderer.sprite = item.icon;
            Debug.Log($"Set sprite to {item.icon.name} for item {item.name} with count {count}");
        }
        else
        {
            Debug.LogError("SpriteRenderer or item icon is null");
        }
    }

    private void Update()
    {
        ttl -= Time.deltaTime;
        if(ttl < 0) { Destroy(gameObject);  }

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > pickUpDistance)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );
        
        if(distance < 0.1f)
        {
            if(GameManager.instance.inventoryContainer != null)
            {
                GameManager.instance.inventoryContainer.Add(item, count);
            }
            else
            {
                Debug.LogWarning("no inventory container attached");
            }

            Destroy(gameObject);
        }
    }
}
