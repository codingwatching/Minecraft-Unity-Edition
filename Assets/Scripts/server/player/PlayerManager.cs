using server.setting;
using UnityEngine;

namespace server.player
{
    public class PlayerManager : MonoBehaviour{
    
        public Tweaks tweaks;
        public KeyBinding keyBinding;
        public Camera mainCamera;

        private CharacterController _cc;
        
        //Move
        private float _xMove, _zMove, _yMove;
        
        //ViewRotation
        private float _horizontalRotate, _verticalRotate;
        private float _yRotation;

        void Start()
        {
            _cc = GetComponent<CharacterController>();
        }

    
        private void Update()
        {
            Cursor.lockState = CursorLockMode.Locked;   //mouse lock
        
          
            #region Movement

            float moveSpeed = 1.5f * tweaks.playerMoveSpeed * Time.deltaTime;

            if (Input.GetKey(keyBinding.sprint))
            {
                moveSpeed *= 2;
            }   
            _xMove = Input.GetAxis("MoveX") * moveSpeed;
            _zMove = Input.GetAxis("MoveZ") * moveSpeed;
            _yMove = Input.GetAxis("MoveY") * moveSpeed;

            _cc.Move(transform.right * _xMove + transform.forward * _zMove + transform.up * _yMove);

            #endregion
            
            #region ViewRotation

            float sensitivity = 400 * tweaks.sensitivity * Time.deltaTime;
            _horizontalRotate = Input.GetAxis("Mouse X") * sensitivity * tweaks.horizontalSensitivity;
            _verticalRotate = Input.GetAxis("Mouse Y") * sensitivity * tweaks.horizontalSensitivity;

            _yRotation -= _verticalRotate;
            _yRotation = Mathf.Clamp(_yRotation, -90, 90);

            transform.Rotate(Vector3.up * _horizontalRotate);
            mainCamera.transform.localRotation = Quaternion.Euler(_yRotation, 0, 0);

            #endregion
        }
    
    
    }
}