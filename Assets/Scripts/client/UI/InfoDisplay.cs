using server.setting;
using UnityEngine;
using UnityEngine.UI;

namespace client.UI{}

public class InfoDisplay : MonoBehaviour
{

    public Camera mainCamera;
    public Tweaks tweaks;
    public Text blockPosText;
    public Text playerPosText;
    public Text blockName;
    public GameObject player;
    private  void Start()
    {
        
    }
    
    private void Update()
    {
        BlockPosTextDisplay();
        PlayerPosTextDisplay();
        
    }
    
    
    private void BlockPosTextDisplay()
    {
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0));
        
        if (Physics.Raycast(ray, out RaycastHit hitInfo, tweaks.maxOperateDistance))
        {
            blockPosText.gameObject.SetActive(true);
            blockName.gameObject.SetActive(true);
            
            Vector3 blockPos = hitInfo.transform.position;

            blockPosText.text = "< "+ ((int) (blockPos.x - 0.5f)) + " , " +
                                ((int) (blockPos.y + 0.5f)) + " , " +
                                ((int) (blockPos.z - 0.5f)) + " >";
            blockName.text = "Block: " + hitInfo.transform.gameObject.name.Replace("(Clone)","");
        }
        else
        {
            blockPosText.gameObject.SetActive(false);
            blockName.gameObject.SetActive(false);

        }
    }

    private void PlayerPosTextDisplay()
    {
        Vector3 playerPos = player.transform.position;
        playerPosText.text = "Position: " + playerPos.x.ToString("0.000") + " , " + playerPos.y.ToString("0.000") + " , " + playerPos.z.ToString("0.000");
    }
}
