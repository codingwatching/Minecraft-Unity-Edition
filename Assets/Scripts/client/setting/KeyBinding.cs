using UnityEngine;

[CreateAssetMenu(fileName ="KeyBinding", menuName = "ScriptableObjects/KeyBinding")]
public class KeyBinding : ScriptableObject
{
    [Header("---- Movement ----")]
    public string move_forward;
    public string move_back;
    public string move_left;
    public string move_right;
    public string move_up;
    public string move_down;
    public string jump;
    public string sprint;
    public string sneak;

    [Header("---- Operate ----")]
    public string attack;
    public string use;
    public string pick;

    [Header("---- Inventory ----")]
    public string drop_item;
    public string inventory;
    public string swap_item;

    [Header("---- Toolbar ----")]
    public string save_toolbar;
    public string load_toolbar;

    [Header("---- Multiplayer ----")]
    public string player_list;
    public string chat;
    public string command;

    [Header("---- View ----")]
    public string zoom_view;

    [Header("---- Map ----")]
    public string minimap;
    public string fullmap;

    [Header("---- Miscellaneous ----")]
    public string advancement;
    public string screenshot;
    public string fullscreen;
    public string perspective;
}
