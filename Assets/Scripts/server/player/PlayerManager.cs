using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject mainCamera;
    public KeyBinding keyBinding;
    public Tweaks tweaks;

    TagList tagList;

    CharacterController cc;

    //Jump
    bool isGround;

    //Movement
    float zMove, xMove, yMove;
    bool canFreeMove;

    //ViewRotation
    float horizontalRotate, verticalRotate;
    float yRotation;
    Vector3 moveVelocity;

    void Start()
    {
        tagList = new TagList();
        cc = GetComponent<CharacterController>();
    }

    
    private void Update()
    {

        bool freeCamera = false;
        GameObject playerOrCamera = freeCamera ? mainCamera : gameObject;

        Cursor.lockState = CursorLockMode.Locked;   //mouse lock

        #region Jump
        if (Input.GetKey(keyBinding.jump) && isGround)
        {
        }

        #endregion

        #region Movement

        float moveSpeed = 1.5f * tweaks.player_move_speed * Time.deltaTime;

        if (Input.GetKey(keyBinding.sprint))
        {
            moveSpeed *= 2;
        }   
        xMove = Input.GetAxis("MoveX") * moveSpeed;
        zMove = Input.GetAxis("MoveZ") * moveSpeed;
        yMove = Input.GetAxis("MoveY") * moveSpeed;

        cc.Move(transform.right * xMove + transform.forward * zMove + transform.up * yMove);

        #endregion

        #region ViewRotation

        float sensitivity = 400 * tweaks.sensitivity * Time.deltaTime;
        horizontalRotate = Input.GetAxis("Mouse X") * sensitivity * tweaks.horizontal_sensitivity;
        verticalRotate = Input.GetAxis("Mouse Y") * sensitivity * tweaks.vertical_sensitivity;

        yRotation -= verticalRotate;
        yRotation = Mathf.Clamp(yRotation, -90, 90);

        transform.Rotate(Vector3.up * horizontalRotate);
        mainCamera.transform.localRotation = Quaternion.Euler(yRotation, 0, 0);

        #endregion


    }

    IEnumerator freeMoveTiggerIntervalTime(float intervalTime)
    {
        yield return null;
    }


    void OnCollisionEnter(Collision collision)
    {

    }
}