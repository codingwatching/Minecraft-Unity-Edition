using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject mainCamera;
    public KeyBinding keyBinding;
    public Tweaks tweaks;

    CharacterController characterController;

    //Gravity
    Vector3 gVelocity;

    //Movement
    float zMove, xMove, yMove;

    //ViewRotation
    float horizontalRotate, verticalRotate;
    float yRotation;
    Vector3 moveVelocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    
    private void Update()
    {

        bool freeCamera = false;
        GameObject playerOrCamera = freeCamera ? mainCamera : gameObject;
        bool isGround = characterController.collisionFlags == CollisionFlags.Below;

        #region Gravity
        if (isGround && gVelocity.y < 0)
        {
            gVelocity.y = -1.0f;
        }

        gVelocity.y -= tweaks.gravity * Time.fixedDeltaTime;
        characterController.Move(gVelocity * Time.fixedDeltaTime);

        #endregion

        #region Jump
        if (Input.GetKey(keyBinding.jump) && isGround)
        {
            gVelocity.y = tweaks.player_jump_force;
        }


        #endregion

        #region Movement

        float moveSpeed = 0.3f * tweaks.player_move_speed * Time.fixedDeltaTime;
        xMove = Input.GetAxis("MoveX") * moveSpeed;
        yMove = Input.GetAxis("MoveY") * moveSpeed;
        zMove = Input.GetAxis("MoveZ") * moveSpeed;

        moveVelocity = transform.right * xMove + transform.up * yMove + transform.forward * zMove;
        characterController.Move(moveVelocity);

        #endregion

        #region ViewRotation

        horizontalRotate = 60 *Input.GetAxis("Mouse X") * tweaks.horizontal_sensitivity * Time.fixedDeltaTime;
        verticalRotate = 60 * Input.GetAxis("Mouse Y") * tweaks.vertical_sensitivity * Time.fixedDeltaTime;

        yRotation -= verticalRotate;
        yRotation = Mathf.Clamp(yRotation, -90, 90);

        transform.Rotate(Vector3.up * horizontalRotate);
        mainCamera.transform.localRotation = Quaternion.Euler(yRotation, 0, 0);

        #endregion

    }

}