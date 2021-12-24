using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Must be placed on the object 'Inventory'
public class ItemInventory : MonoBehaviour
{
    protected static Dictionary<string, ItemPicked> items;
    private static Dictionary<string, GameObject> imageSprites;
    private List<GameObject> inventory;

    public bool autoSave = false;

    protected RawImage nextItemSlot
    {
        get
        {
            foreach (var item in inventory)
            {
                if (item.transform.GetChild(0).GetComponent<RawImage>().texture == null) return item.transform.GetChild(0).GetComponent<RawImage>();
            }
            return null;
        }
    }

    private void Awake()
    {
        inventory = GetChildrenOfObject(gameObject);
    }

    public ItemInventory()
    {
        items = new Dictionary<string, ItemPicked>();
        imageSprites = new Dictionary<string, GameObject>();
    }

    public void UseItem(int itemIndex)
    {
        int actualIndex = itemIndex - 1;
        int currentIndex = 0;

        foreach (var item in items.Values)
        {
            if (currentIndex == actualIndex)
            {
                var count = item.useItem();
                var quantityText = imageSprites[item.ItemName].transform.parent.GetChild(1).GetComponent<Text>();
                quantityText.text = "x" + count.ToString();

                if (count == 0) {
                    items.Remove(item.ItemName);

                    var imageSlot = imageSprites[item.ItemName].GetComponent<RawImage>();
                    imageSlot.color = new Color(imageSlot.color.r, imageSlot.color.g, imageSlot.color.b, 0);

                    imageSprites[item.ItemName].GetComponent<RawImage>().texture = null;
                    imageSprites.Remove(item.ItemName);
                }
                break;
            }
            currentIndex++;
        }
    }

    public void AddItem(ItemPicked item)
    {
        if (items.ContainsKey(item.ItemName))
        {
            items[item.ItemName].addCount();
        }
        else
        {
            items.Add(item.ItemName, item);

            var imageSlot = nextItemSlot;
            imageSlot.gameObject.SetActive(autoSave);

            imageSlot.color = new Color(imageSlot.color.r, imageSlot.color.g, imageSlot.color.b, 255);

            imageSlot.texture = item.GetSprite();    

            imageSprites.Add(item.ItemName, imageSlot.gameObject);
        }

        var quantityText = imageSprites[item.ItemName].transform.parent.GetChild(1).GetComponent<Text>();
        quantityText.text = "x" + items[item.ItemName].ItemCount.ToString();
    }

    private List<GameObject> GetChildrenOfObject(GameObject obj)
    {
        List<GameObject> ret = new List<GameObject>();

        foreach (Transform child in obj.transform)
        {
            ret.Add(child.gameObject);
        }
        return ret;
    }

    public void Save()
    {
        if (autoSave) return;

        foreach (var item in imageSprites.Values)
        {
            item.SetActive(true);
        }
    }

    public class ItemPicked : MonoBehaviour
    {
        public GameObject item { get; private set; }
        public string ItemName { get; set; }
        public int ItemCount { get; private set; }

        public ItemPicked(GameObject item, string ItemName)
        {
            this.item = item;
            this.ItemName = ItemName;
            ItemCount = 1;
        }

        public Texture GetSprite()
        {
            return item.GetComponent<SpriteRenderer>().sprite.texture;
        }

        public void addCount() => ItemCount++;

        public int useItem()
        {
            switch (ItemName)
            {
                case "HealthPotion":
                    FindObjectOfType<PlayerHealth>().HealPlayer(25);
                    ItemCount--;
                    return ItemCount;
                case "Ammo":
                    var player = FindObjectOfType<AutomaticGunScriptLPFP>();
                    player.maxAmmo += 70;
                    player.totalAmmoText.text = player.maxAmmo.ToString();
                    ItemCount--;
                    return ItemCount;
                default:
                    break;
            }
            return -1;
        }
    }
}
