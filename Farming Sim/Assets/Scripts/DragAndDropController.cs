using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropController : MonoBehaviour
{
    [SerializeField] ItemSlot itemSlot;
    [SerializeField] GameObject itemIcon;
    RectTransform iconTransform;
    Image itemIconImage;

    private void Start()
    {
        itemSlot = new ItemSlot();
        iconTransform = itemIcon.GetComponent<RectTransform>();
        itemIconImage = itemIcon.GetComponent<Image>();


    }

    private void Update()
    {
        

        if (itemIcon.activeInHierarchy == true)
        {
            iconTransform.position = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject() == false)
                {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    worldPosition.z = 0;

                    if (ItemSpawnManager.instance != null)
                    {
                        Debug.Log($"Spawning item {itemSlot.item.name} at {worldPosition}");
                        ItemSpawnManager.instance.SpawnItem(worldPosition, itemSlot.item, itemSlot.count);

                        itemSlot.Clear();
                        itemIcon.SetActive(false);
                    }
                    else
                    {
                        Debug.LogError("itemSlot or itemSlot.item is null");
                    }


                    //itemSlot.Clear();
                    // itemIcon.SetActive(false);
                }
                else
                {
                    Debug.LogError("itemSlot or itemSlot.item is nulllll");
                }
            }


        }
    }


    internal void OnClick(ItemSlot newItemSlot)
    {
        Debug.Log($"OnClick called with itemSlot: {newItemSlot?.item?.name}, count: {newItemSlot?.count}");

        if (this.itemSlot == null)
        {
            this.itemSlot = new ItemSlot();
        }

        // If newItemSlot or its item is null, simply clear this.itemSlot
        if (newItemSlot == null || newItemSlot.item == null)
        {
            this.itemSlot.Clear();
        }
        else
        {
            // Copy properties from newItemSlot to this.itemSlot
            this.itemSlot.Copy(newItemSlot);
        }

        UpdateIcon();
    }


    private void UpdateIcon()
    {
        if(itemSlot.item == null)
        {
            itemIcon.SetActive(false);
        }
        else
        {
            itemIcon.SetActive(true);
            itemIconImage.sprite = itemSlot.item.icon;
        }
    }
}
