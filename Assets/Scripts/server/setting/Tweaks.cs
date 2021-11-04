using UnityEngine;

namespace server.setting
{
    [CreateAssetMenu(fileName = "Tweaks", menuName = "ScriptableObjects/Tweaks")]
    public class Tweaks : ScriptableObject
    {
        [Header("---- Movement ----")]
        public float playerMoveSpeed;
        public float playerJumpForce;
        public float gravity;

        [Header("---- ViewRotate ----")]
        public float sensitivity;
        public float horizontalSensitivity;
        public float verticalSensitivity;

        [Header("---- Operate ----")]
        public float maxOperateDistance;


    }
}
