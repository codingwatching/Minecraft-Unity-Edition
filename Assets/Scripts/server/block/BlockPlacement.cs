using System.Collections;
using server;
using server.setting;
using UnityEngine;

public class BlockPlacement : MonoBehaviour
{
    public Camera mainCamera;

    public KeyBinding keyBinding;
    public Tweaks tweaks;
    public Inventory inventory;

    TagList tagList;
    GameObject block;

    #region Singleton
    private void Awake()
    {
        tagList = new TagList();
    }
    #endregion

    private void Update()
    {

        if (Input.GetKeyDown(keyBinding.use))
        {
            block = inventory.toolbar[inventory.select_item - 1];
            SetBlock(transform.position, block);
        }
        if (Input.GetKeyDown(keyBinding.attack))    
        {
            RemoveBlock(transform.position);
        }

    }


    void SetBlock(Vector3 playerPos, GameObject block)
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)); // screen center
        if (Physics.Raycast(ray, out RaycastHit hitInfo, tweaks.maxOperateDistance)) {
            Vector3 blockPos = hitInfo.collider.transform.position;
            if ((playerPos - blockPos).sqrMagnitude <= Mathf.Pow(tweaks.maxOperateDistance, 2))  // calculate the distance between player and block
            {
                PlaceBlock(blockPos, block, hitInfo);
            }
        }
    }

    void RemoveBlock(Vector3 playerPos)
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out RaycastHit hitInfo, tweaks.maxOperateDistance))
        {
            Vector3 blockPos = hitInfo.collider.transform.position;
            if ((playerPos - blockPos).sqrMagnitude <= Mathf.Pow(tweaks.maxOperateDistance, 2))    // calculate the distnce between player and block
            {
                if (hitInfo.collider.CompareTag(tagList.Block))
                {
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
    }


    public void ReplaceBlock()
    {

    }

    void PlaceBlock(Vector3 blockPos, GameObject gameObject, RaycastHit hitInfo)
    {
        blockPos.x = Mathf.Floor(blockPos.x) + 0.5f;
        blockPos.y = Mathf.Floor(blockPos.y) + 0.5f;
        blockPos.z = Mathf.Floor(blockPos.z) + 0.5f;

        Instantiate(gameObject, blockPos + hitInfo.normal, Quaternion.identity);
    }

}
