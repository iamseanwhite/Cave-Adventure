using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        instance = this;
        Debug.Log("in awake");
        DontDestroyOnLoad(GameObject.FindWithTag("UI"));
        character = GameObject.FindWithTag("Player");
    }
    #endregion


    private GameObject character;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public GameObject rapier;
    public GameObject torch;
    public GameObject key;
    public bool haskey = false;
    public bool hasTorch = false;

    public int capacity = 6;
    public List<Item> items = new List<Item>();

    void OnLevelWasLoaded()
    {
        Debug.Log("in OnLevelWasLoaded");
        Debug.Log("player is " + GameObject.FindWithTag("Player").name);
        character = GameObject.FindWithTag("Player");        
    }
        
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseItem(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseItem(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseItem(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UseItem(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            UseItem(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            UseItem(6);
        }
    }
    public bool Add(Item item)
    {
        if (items.Count < capacity)
        {
            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();

            if (item.name == "Key")
            {
                haskey = true;
            }

            if (item.name == "Torch")
            {
                hasTorch = true;
            }

            return true;
        }
        return false;
    }

    public void Remove(Item item)
    {
        Debug.Log("Removing Item.......");
        Debug.Log("character transform: " + character.transform.position);

        Instantiate(item.gameObject, character.transform.position + new Vector3(1,1,0), Quaternion.identity);
        Debug.Log("After Instantiate");
        items.Remove(item);

        if (item.name =="Rapier")
        {
            item.isEquipped = !item.isEquipped;
            rapier.SetActive(false);
        }

        if (item.name == "Torch")
        {
            item.isEquipped = !item.isEquipped;
            torch.SetActive(false);
            Debug.Log("Torch equipped");
        }

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }


    void UseItem(int key)
    {
        int slot = key - 1;
        var item = items[slot];

        if (item != null && item.isEquipable)
            ToggleEquip(item);
    }

    void ToggleEquip(Item item)
    {              
        item.isEquipped = !item.isEquipped;
        if (item.name == "Rapier")
            rapier.SetActive(!rapier.activeSelf);

        if (item.name == "Torch")
            torch.SetActive(!torch.activeSelf);
            Debug.Log("torch active");
             hasTorch = true;

        if (item.name == "Key")
            key.SetActive(!torch.activeSelf);
        Debug.Log("key active");
        haskey = true;
    }
}
