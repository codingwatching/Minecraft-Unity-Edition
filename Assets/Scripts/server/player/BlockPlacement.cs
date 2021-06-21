using System.Collections;
using UnityEngine;

public class BlockPlacement : MonoBehaviour
{
    public GameObject blockPrefabs;
    public Camera mainCamera;

    public KeyBinding keyBinding;
    public Tweaks tweaks;

    TagList tagList;

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
            SetBlock(transform.position, blockPrefabs);
        }
        if (Input.GetKeyDown(keyBinding.attack))    
        {
            RemoveBlock(transform.position);
        }

    }


    void SetBlock(Vector3 playerPos, GameObject block)
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)); // screen center
        if (Physics.Raycast(ray, out RaycastHit hitInfo, tweaks.max_oparate_distance)) {
            Vector3 blockPos = hitInfo.collider.transform.position;
            if ((playerPos - blockPos).sqrMagnitude <= Mathf.Pow(tweaks.max_oparate_distance, 2))  // calculate the distnce between player and block
            {
                PlaceBlock(blockPos, blockPrefabs, hitInfo);
            }
        }
    }

    void RemoveBlock(Vector3 playerPos)
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out RaycastHit hitInfo, tweaks.max_oparate_distance))
        {
            Vector3 blockPos = hitInfo.collider.transform.position;
            if ((playerPos - blockPos).sqrMagnitude <= Mathf.Pow(tweaks.max_oparate_distance, 2))    // calculate the distnce between player and block
            {
                if (hitInfo.collider.tag == tagList.block)
                {
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
    }

    public void replaceBlock()
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
