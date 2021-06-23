using UnityEngine;

[CreateAssetMenu(fileName = "Tweaks", menuName = "ScriptableObjects/Tweaks")]
public class Tweaks : ScriptableObject
{
    [Header("---- Movement ----")]
    public float player_move_speed;
    public float player_jump_force;
    public float gravity;

    [Header("---- ViewRotate ----")]
    public float sensitivity;
    public float horizontal_sensitivity;
    public float vertical_sensitivity;

    [Header("---- AttchOrUse ----")]
    public float max_oparate_distance;


}
