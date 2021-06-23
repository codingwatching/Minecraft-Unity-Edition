using UnityEngine;

[CreateAssetMenu(fileName = "BlockList", menuName = "ScriptableObjects/BlockList")]

public class Block : ScriptableObject
{
    [Header("---- Special ----")]
    public GameObject bedrock;


    [Header("---- Normal ----")]
    public GameObject grass_block;


}
