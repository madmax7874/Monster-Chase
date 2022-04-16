using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;
    private bool isGrounded = true;
    private float movementX;

    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    private Rigidbody2D myBody;
    private Animator myAnim;
    private SpriteRenderer sr;


    void Awake(){
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        PlayerMove();
        AnimatePlayer();
        PlayerJump();
    }


    // on collision func
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag(GROUND_TAG)){
            isGrounded=true;
        }

        if(collision.gameObject.CompareTag(ENEMY_TAG)){
            Destroy(gameObject);
            SceneManager.LoadScene("MainMenu");
        }
    }

    void PlayerMove(){
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX,0f,0f)*Time.deltaTime*moveForce;
    }

    void AnimatePlayer(){
        if(movementX > 0){
            myAnim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }else if(movementX < 0){
            myAnim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }else{
            myAnim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump(){
        if(Input.GetButtonDown("Jump") && isGrounded){
            isGrounded=false;
            myBody.AddForce(new Vector2(0f,jumpForce),ForceMode2D.Impulse);
        }
    }
}
