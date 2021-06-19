using UnityEngine;

public class BlockPlacement : ScriptableObject
{
    public float maxPlayerPlaceDistance = 100.0f;  //set the max distance which player can place blocks

    public GameObject blockPrefabs;

    TagList tagList;

    #region Singleton
    private void Awake()
    {
        tagList = new TagList();
    }
    #endregion

    private void Update()
    {
        Vector3 playerPos = blockPrefabs.transform.position;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RemoveBlock(playerPos);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SetBlock(playerPos, blockPrefabs);
        }

    }

    public void SetBlock(Vector3 playerPos, GameObject block)
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelWidth / 2, 0)); // screen center
        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxPlayerPlaceDistance)) {
            Vector3 blockPos = hitInfo.collider.transform.position;
            if ((playerPos - blockPos).sqrMagnitude <= Mathf.Pow(maxPlayerPlaceDistance, 2))  // calculate the distnce between player and block
            {
                if(hitInfo.collider.CompareTag(tagList.ground))
                {
                    PlaceBlock(blockPos, block);
                }
                else if(hitInfo.collider.CompareTag(tagList.block))
                {
                    PlaceBlockByBlock(blockPos, hitInfo, block);
                }
            }
        }
    }

    public void RemoveBlock(Vector3 playerPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth / 2, Camera.main.pixelWidth / 2, 0));
        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxPlayerPlaceDistance))
        {
            Vector3 blockPos = hitInfo.collider.transform.position;
            if ((playerPos - blockPos).sqrMagnitude <= Mathf.Pow(maxPlayerPlaceDistance, 2))    // calculate the distnce between player and block
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
    public Vector3 BlockPosCorrecting(Vector3 vector3)
    {
        vector3.x = Mathf.Floor(vector3.x) + 0.5f;
        vector3.y = Mathf.Floor(vector3.y) + 0.5f;
        vector3.z = Mathf.Floor(vector3.z) + 0.5f;
        return vector3;
    }
    public void PlaceBlock(Vector3 blockPos, GameObject gameObject)
    {
        blockPos = BlockPosCorrecting(blockPos);
        Instantiate(gameObject, blockPos, Quaternion.identity);
    }

    public void PlaceBlockByBlock(Vector3 blockPos, RaycastHit hitInfo, GameObject gameObject)
    {
        blockPos = BlockPosCorrecting(blockPos);
        if(hitInfo.normal.x > 0)
        {
            blockPos.x += 1;
        }
        else if(hitInfo.normal.x < 0)
        {
            blockPos.x -= 1;
        }
        if (hitInfo.normal.y > 0)
        {
            blockPos.y += 1;
        }
        else if (hitInfo.normal.y < 0)
        {
            blockPos.y -= 1;
        }
        if (hitInfo.normal.z > 0)
        {
            blockPos.z += 1;
        }
        else if (hitInfo.normal.z < 0)
        {
            blockPos.z -= 1;
        }

        PlaceBlock(blockPos, gameObject);
    }

}
