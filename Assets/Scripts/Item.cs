using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite sprite = null;
    public bool isEquiped = false;
}
