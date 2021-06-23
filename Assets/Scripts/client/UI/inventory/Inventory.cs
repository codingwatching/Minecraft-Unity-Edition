using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/InventoryList")]

public class Inventory : ScriptableObject
{
    [Header("---- Toolbar ----")]
    public int select_item;
    public GameObject[] toolbar;

    [Header("---- Inventory ----")]
    public GameObject[] inventory;

}
