using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Singleton
    PlayerMovement playerMovement;
    KeyBinding keyBinding;

    private void Awake()
    {
        keyBinding = new KeyBinding();
        playerMovement = new PlayerMovement();
    }
    #endregion

    private void Update()
    {
        if (!Input.anyKey) playerMovement.Movement("");     //reset the velocity to '0'(zero) of the player
      
        if (Input.GetKeyDown(keyBinding.KeyBindings("move_forward")))   playerMovement.Movement("move_forward");
        if (Input.GetKeyDown(keyBinding.KeyBindings("move_backward"))) playerMovement.Movement("move_backward");
        if (Input.GetKeyDown(keyBinding.KeyBindings("move_left")))   playerMovement.Movement("move_left");
        if (Input.GetKeyDown(keyBinding.KeyBindings("move_right")))   playerMovement.Movement("move_right");

        if (Input.GetKeyDown(keyBinding.KeyBindings("move_up")))   playerMovement.Movement("move_up");

        if (Input.GetKeyDown(keyBinding.KeyBindings("move_down")))   playerMovement.Movement("move_down");
        
    }

}
