using UnityEngine;

public class PlayerMovement:MonoBehaviour
{
    float speed = 3.0f;

    GameObject player;
    Rigidbody rb;
    
    void init()
    {
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();
    }

    public void Movement(string direction)
    {
        init();
        float timeSpeed =50 * speed * Time.fixedDeltaTime;

        rb.velocity = direction switch
        {
            "move_forward" => Vector3.forward * timeSpeed,
            "move_backward" => Vector3.back * timeSpeed,
            "move_left" => Vector3.left * timeSpeed,
            "move_right" => Vector3.right * timeSpeed,
            "move_up" => Vector3.up * timeSpeed,
            "move_down" => Vector3.down * timeSpeed,
            _ => Vector3.zero,
        };
    }

    public bool CanFly()
    {
        init();
        return true;
    }

    public bool IsInTheAir()
    {
        return true;

    }

    
}