using UnityEngine;

public class PlayerWalking : MonoBehaviour //Simple Player Movement Script
{
    private SettManagers setts;
    [Header("Attributes")]
    public float walkspeed = 5f;
    public Rigidbody2D rb;
    float horizontal;
    float vertical;

    void Start()
    {
        setts = FindAnyObjectByType<SettManagers>();
    }
    void Update()
    {
        if(setts.currentMode == CurrentMode.Gameplay)
        {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        }
    }

    void FixedUpdate()
    {
        if(setts.currentMode == CurrentMode.Gameplay)
        {
        Vector2 movement = new Vector2(horizontal, vertical).normalized;
        rb.MovePosition(rb.position + movement * walkspeed * Time.fixedDeltaTime);  
        }
    }
}