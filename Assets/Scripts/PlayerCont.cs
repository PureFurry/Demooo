using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCont : MonoBehaviour
{
 
    public float player_speed;
    public float horizontal;
    public Rigidbody2D player_r2d;
    public GameObject playerObject;
    public float jumpForce;
    public LayerMask groundObject;
    private CapsuleCollider2D player_CapsuleCollider;
    private Animator playerAnimator;
    bool isFaceRight =true;
    public Text coinText;
    public GameObject resertButton, deadText, winText;
    public static int totalCoins;
    public AudioSource audioManager;
    void Start()
    {
        player_r2d = GetComponent<Rigidbody2D>();
        player_CapsuleCollider = GetComponent<CapsuleCollider2D>();
        playerAnimator = GetComponent<Animator>();
        audioManager = GetComponent<AudioSource>();
    }


    void Update()
    {
        GetInput();
        Movement();
        if (GroundCheck() && Input.GetKeyDown(KeyCode.Space))
        {
                player_r2d.velocity = Vector2.up * jumpForce;                
        }
        AnimatonCont();
        if (horizontal < 0 && isFaceRight == true)
        {
            FlipLook();
        }
        else if(horizontal > 0 && isFaceRight == false)
        {
            FlipLook();
        }
    }
    void GetInput(){
        horizontal = Input.GetAxis("Horizontal");
    }
    void Movement(){
        player_r2d.velocity = new Vector2(horizontal*player_speed, player_r2d.velocity.y);
        
    }
    bool GroundCheck(){
        RaycastHit2D p_raycastHit2d = Physics2D.BoxCast(player_CapsuleCollider.bounds.center, player_CapsuleCollider.bounds.size, 0f, Vector2.down, .1f, groundObject);
        return p_raycastHit2d.collider == null;
    }
    void AnimatonCont(){
            playerAnimator.SetFloat("isRunning",Mathf.Abs(horizontal));            
    }
    void FlipLook(){    
           Vector2 currentScale = gameObject.transform.localScale;
           currentScale.x *= -1;
           gameObject.transform.localScale = currentScale;
           isFaceRight = !isFaceRight;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Coin"))
        {
            totalCoins++;
            coinText.text = totalCoins.ToString();
            audioManager.Play();
        }
        if(other.CompareTag("Spike")){
            totalCoins = 0;
            Time.timeScale = 0;
            deadText.SetActive(true);
            resertButton.SetActive(true);
        }
        if (other.CompareTag("EndPoint"))
        {
            Time.timeScale = 0;
            winText.SetActive(true);   
            resertButton.SetActive(true);         
        }
    }
}