using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Must be placed on the object 'Inventory'
public class ItemInventory : MonoBehaviour
{
    protected static List<ItemPicked> items;
    private static List<GameObject> imageSprites;
    private List<GameObject> inventory;

    public bool autoSave = false;

    protected Image nextItemSlot
    {
        get
        {
            foreach (var item in inventory)
            {
                if (item.transform.GetChild(0).GetComponent<Image>().sprite == null) return item.transform.GetChild(0).GetComponent<Image>();
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
        items = new List<ItemPicked>();
        imageSprites = new List<GameObject>();
    }

    public void AddItem(ItemPicked item)
    {
        items.Add(item);
        var imageSlot = nextItemSlot;
        imageSlot.gameObject.SetActive(autoSave);
        imageSlot.sprite = item.GetSprite();
        imageSprites.Add(imageSlot.gameObject);
    }

    private List<GameObject> GetChildrenOfObject(GameObject obj){
        List<GameObject> ret = new List<GameObject>();

        foreach (Transform child in obj.transform) {
            ret.Add(child.gameObject);
        }
        return ret;
    }

    public void Save()
    {
        if (autoSave) return;

        foreach (var item in imageSprites)
        {
            item.SetActive(true);
        }
    }

    public class ItemPicked : MonoBehaviour
    {
        public GameObject item { get; private set; }
        public string ItemName { get; set; }

        public ItemPicked(GameObject item, string ItemName)
        {
            this.item = item;
            this.ItemName = ItemName;
        }

        public Sprite GetSprite()
        {
            return item.GetComponent<SpriteRenderer>().sprite;
        }
    }
}
