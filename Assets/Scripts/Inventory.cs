using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        instance = this;
        character = GameObject.FindWithTag("Player");
        //DontDestroyOnLoad(GameObject.FindWithTag("UI"));
    }
    #endregion

    private GameObject character;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public GameObject rapier;

    public int capacity = 6;
    public List<Item> items = new List<Item>();
        
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ToggleEquip(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ToggleEquip(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ToggleEquip(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ToggleEquip(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ToggleEquip(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ToggleEquip(6);
        }
    }
    public bool Add(Item item)
    {
        if (items.Count < capacity)
        {
            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();

            return true;
        }
        return false;
    }

    public void Remove(Item item)
    {
        Debug.Log("Removing Item");
        Debug.Log("character transform: " + character.transform.position);

        Instantiate(item.gameObject, character.transform.position + new Vector3(1,1,0), Quaternion.identity);
        Debug.Log("After Instantiate");
        items.Remove(item);

        if (item.name =="Rapier")
        {
            item.isEquipped = !item.isEquipped;
            rapier.SetActive(false);
        }

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    void ToggleEquip(int key)
    {
        int slot = key - 1;
        var item = Inventory.instance.items[slot];

        if (item != null && item.isEquipable)
        {
            item.isEquipped = !item.isEquipped;
            if (item.name == "Rapier")
                rapier.SetActive(!rapier.activeSelf);
        }
    }
}
