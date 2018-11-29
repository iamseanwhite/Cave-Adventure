using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour {

    GameObject rapier, rope, miniMapBorder;
    AudioSource rapierDraw, rapierSheath;

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

     void Start()
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        rapier = allObjects.FirstOrDefault(x => x.CompareTag("InHandRapier"));
        rope = allObjects.FirstOrDefault(x => x.CompareTag("RopeExtended"));
        miniMapBorder = allObjects.FirstOrDefault(x => x.CompareTag("MiniMapBorder"));
        rapierDraw = rapier.GetComponent<AudioSource>();
    }

    private GameObject character;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    

    public int capacity = 6;
    public List<Item> items = new List<Item>();

    void OnLevelWasLoaded()
    {
        Debug.Log("in OnLevelWasLoaded");
        Debug.Log("player is " + GameObject.FindWithTag("Player").name);
        character = GameObject.FindWithTag("Player");
        rapier = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(x => x.CompareTag("InHandRapier"));
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

            return true;
        }
        return false;
    }

    public void Remove(Item item)
    {
        Debug.Log("Removing Item.......");
        Debug.Log("character transform: " + character.transform.position);

        Debug.Log("Item is " + item);
        Debug.Log("Item.gameobject is " + item.gameObject);

        Instantiate(item.gameObject, character.transform.position + new Vector3(1,1,0), Quaternion.Euler(20, 0, 0));

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


    void UseItem(int key)
    {
        Debug.Log("in UseItem - rapier is " + rapier);
        int slot = key - 1;
        var item = items[slot];

        if (item != null && item.isEquipable)
            ToggleEquip(item);

        if(item != null && item.name == "Coconut" && PlayerHealth.instance.currentHealth != 100)
        {
            PlayerHealth.instance.TakeHit(-10);
            RemoveAfterOneTimeUse(item);
        }
    }

    void ToggleEquip(Item item)
    {
        Debug.Log("in ToggleEquip - rapier name is " + rapier.name);
        item.isEquipped = !item.isEquipped;
        if (item.name == "Rapier")
        {
           Debug.Log("in setactive -" + rapier.activeSelf);

           //rapier = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(x => x.CompareTag("Rapier"));
           rapier.SetActive(!rapier.activeSelf);
           rapierDraw.Play();

           Debug.Log("in setactive -" + rapier.activeSelf);
           Debug.Log("position -" + rapier.transform.position.x);
        }
            

        if (item.name == "Rope")
        { 
            if (Vector3.Distance(GameObject.FindWithTag("Player").transform.position, 
                                 GameObject.FindWithTag("RopeTriggerPoint").transform.position) <= 2)
            {                             
                rope.SetActive(true);                
                RemoveAfterOneTimeUse(item);
            }
        }

        if (item.name == "Shovel")
        {
            if (Vector3.Distance(GameObject.FindWithTag("Player").transform.position,
                                 GameObject.FindWithTag("ShovelTriggerPoint").transform.position) <= 7)
            {
                GameObject.FindWithTag("CavernCover").SetActive(false);
                RemoveAfterOneTimeUse(item);
            }
        }

        if (item.name == "Treasure Map" && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "Island")
        {
            item.isEquipped = !item.isEquipped;
            miniMapBorder.SetActive(!miniMapBorder.activeSelf);
        }
    }

    void RemoveAfterOneTimeUse(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
