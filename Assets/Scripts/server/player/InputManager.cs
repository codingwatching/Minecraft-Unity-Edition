using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject blockPrefabs;
    //private readonly KeyBindingFromJson keyBindingFromJson;
     BlockPlacement bp ;

    public void Update()
    {
        Vector3 playerPos = new Vector3();
        playerPos = gameObject.transform.position;
        if (Input.anyKey) {

            if (Input.GetKey(KeyCode.Mouse0))
            {
                bp.RemoveBlock(playerPos);
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {
                bp.SetBlock(playerPos, blockPrefabs);
            }
            
        }
    }



}
