using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour {

    GameObject rapier, rope, miniMapBorder, torch, treasure, fireworks;
    AudioSource rapierDraw, rapierSheath;
    //public bool isNextToChest = false;
    OpenBox openBoxScript;

    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        instance = this;
        Debug.Log("in awake");
        //DontDestroyOnLoad(GameObject.FindWithTag("UI"));
        character = GameObject.FindWithTag("Player");

    }
    #endregion

     void Start()
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        rapier = allObjects.FirstOrDefault(x => x.CompareTag("InHandRapier"));
        //rope = allObjects.FirstOrDefault(x => x.CompareTag("RopeExtended"));
        torch = allObjects.FirstOrDefault(x => x.CompareTag("InHandTorch"));
        miniMapBorder = allObjects.FirstOrDefault(x => x.CompareTag("MiniMapBorder"));
        rapierDraw = rapier.GetComponent<AudioSource>();
        GameObject.FindWithTag("MiniMapBorder").SetActive(false);
    }

    private GameObject character;
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    //public GameObject rapier;
    public GameObject key;
    //public GameObject torch;
    public bool haskey = false;
    public bool hasTorch = false;
    Animator treasureAnimimator;

    public int capacity = 6;
    public List<Item> items = new List<Item>();

    void OnLevelWasLoaded()
    {
        Debug.Log("in OnLevelWasLoaded");
        Debug.Log("player is " + GameObject.FindWithTag("Player").name);
        //character = GameObject.FindWithTag("Player");
        //rapier = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(x => x.CompareTag("InHandRapier"));


        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        //rapier = allObjects.FirstOrDefault(x => x.CompareTag("InHandRapier"));

        if (SceneManager.GetActiveScene().name == "Island")
        {
            rope = allObjects.FirstOrDefault(x => x.CompareTag("RopeExtended"));

            //GameObject.FindWithTag("MiniMapBorder").SetActive(true);
            miniMapBorder.SetActive(true);

            Vector3 correctHealthBarPosition = transform.position;
            correctHealthBarPosition.x = 300;
            correctHealthBarPosition.y = -71;


            //SetHealthBarPosition(allObjects, correctHealthBarPosition);

            //allObjects.First(x => x.CompareTag("HealthBorder")).transform.position = correctHealthBarPosition;
            //Debug.Log("healthbar object is " + allObjects.First(x => x.CompareTag("HealthBorder")).name);
        }
        

        else
        {
            Debug.Log("in the cave...!");
            GameObject.FindWithTag("MiniMapBorder").SetActive(false);
            torch = allObjects.FirstOrDefault(x => x.CompareTag("InHandTorch"));
            treasure = allObjects.FirstOrDefault(x => x.name.Equals("tresure_box"));
            Debug.Log("treasure is " + treasure.name);

            openBoxScript = treasure.GetComponent<OpenBox>();

            treasureAnimimator = treasure.GetComponent<Animator>();
            Debug.Log("Animator is " + treasureAnimimator.name);
            Debug.Log("isopen is " + treasureAnimimator.GetBool("IsOpen"));
            fireworks = allObjects.FirstOrDefault(x => x.CompareTag("Fireworks"));
        }
        //if (SceneManager.GetActiveScene().name == "Cave Kit Demo")
            //torch = allObjects.FirstOrDefault(x => x.CompareTag("InHandTorch"));
        //miniMapBorder = allObjects.FirstOrDefault(x => x.CompareTag("MiniMapBorder"));
        //rapierDraw = rapier.GetComponent<AudioSource>();
    }

    //void SetHealthBarPosition(GameObject[] allObjects, Vector3 correct)
    //{
    //    allObjects.First(x => x.CompareTag("HealthBorder")).transform.position = correct;
    //}

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

           
            //if (item.name == "Key")
            //{
            //    haskey = true;
            //}

            // hasTorch true only when it is equipped.
            //if (item.name == "Torch")
            //{
            //    hasTorch = true;
            //}

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

        if (item.name == "Torch")
        {
            item.isEquipped = !item.isEquipped;
            torch.SetActive(false);
            Debug.Log("Torch removed");
            hasTorch = false;

        }

        if (item.name == "Key")
        {
            //item.isEquipped = !item.isEquipped;
            //key.SetActive(false);
            Debug.Log("Key removed");
            //haskey = false;
        }

            
        if (item.name == "Treasure Map")
        {
            item.isEquipped = false;
            miniMapBorder.SetActive(false);
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

        if (item.name == "Key")
        {
            Debug.Log("Using the key....");
            if (Vector3.Distance(GameObject.FindWithTag("Player").transform.position,
                                 GameObject.FindWithTag("Treasure").transform.position) <= 2)
            {
                Debug.Log("Should be opening...");
               //openBoxScript.OpenTheBox();
                treasureAnimimator.SetBool("isOpen", true);
                fireworks.SetActive(true);
                GetComponent<AudioSource>().Play();
                Invoke("GoBackToMenu", 7.0f);
            }
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
           if(rapierDraw != null)
              rapierDraw.Play();

           Debug.Log("in setactive -" + rapier.activeSelf);
           Debug.Log("position -" + rapier.transform.position.x);
        }

        if (item.name == "Torch")
        {
            torch.SetActive(!torch.activeSelf);
            Debug.Log("torch active");
            if (torch.activeSelf == true)
            {
                hasTorch = true;
            }
            else
            {
                hasTorch = false;
            }
            Debug.Log("torch is " + torch.activeSelf);
        }

        //if (item.name == "Key")
        //{
        //    key.SetActive(!key.activeSelf);
        //    Debug.Log("key active");
        //    if (torch.activeSelf == true)
        //    {
        //        haskey = true;
        //    }
        //    else
        //    {
        //        haskey = false;
        //    }
        //}


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

    void GoBackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
