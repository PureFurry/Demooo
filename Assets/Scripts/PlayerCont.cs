using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
 
    public float player_speed;
    public float horizontal;
    public Rigidbody2D player_r2d;
    public GameObject playerObject;
    public Vector2 jumpHeight;
    public bool isJumping;
    void Start()
    {
        player_r2d = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        GetInput();
        Movement();
        
    }
    void GetInput(){
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
        else isJumping = false;
    }
    void Movement(){
        player_r2d.velocity = new Vector2(horizontal*player_speed, player_r2d.position.y);
        if (isJumping == true)
        {
            player_r2d.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }
}
