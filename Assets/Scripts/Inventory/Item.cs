using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public GameObject gameObject;
    public Sprite sprite = null;
    public bool isEquipable = false;
    public bool isEquipped = false;


}
