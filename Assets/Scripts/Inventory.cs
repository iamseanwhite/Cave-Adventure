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

    public int capacity = 6;
    public List<Item> items = new List<Item>();
        

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

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
