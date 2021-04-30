using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl instance ;

    [Header("基础组件")]
    Rigidbody2D rb ; 
    Animator    anim ;
    public LayerMask ground ; //“地面”
    public Transform groundCheck ; //检测是否在地面上的子组件



    [Header("基础数值")]
    public bool canMove = true; //玩家当前是否是可移动状态
    public float speed ;
    public float moveX ;
    public float jumpForce ;
    public bool isGround,isJump ; 
    bool jumpPressed ; //是否按下跳跃

   
    private int jumpCount ;
    public int jumpNum ;

    private void Awake()
    {
        if(instance == null ){
            instance = this ;
            //设置instance
        }else{
            if(instance != this){
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);

    } 
    void Start()
    {
        rb   =  GetComponent<Rigidbody2D>();
        anim =  GetComponent<Animator>();
    }

    void Update()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position,0.1f,ground);
        FreshData();

        //移动判定区
        if(canMove){
        PlayerMovement();

        if(Input.GetButtonDown("Jump") && jumpCount >0){
            //如果符合跳跃判定，即有按键+有跳跃次数
          jumpPressed = true ;
        }
        Jump();
        }

        
    }

    void PlayerMovement(){
        rb.velocity = new Vector2( moveX * speed , rb.velocity.y);
        if(moveX>=0)  transform.localScale = new Vector3(1,1,1);
        if(moveX<0)   transform.localScale = new Vector3(-1,1,1);

    }

    void Jump(){
        //跳跃
        if(isGround == true){
            //如果判断在地面上
            jumpCount = jumpNum ; 
            //把跳跃次数恢复为x,x就是几段跳
            isJump = false ; 

        }

        if(jumpPressed && isGround ){
            //如果符合跳跃条件
            isJump = true ; 
            rb.velocity = new Vector2(rb.velocity.x , jumpForce);
            //给予y上跳跃的力。X保持
            jumpCount -- ;
            jumpPressed = false  ;
        }else if(jumpPressed && jumpCount > 0 && isJump){
            //在跳跃状态下的二次跳跃
            rb.velocity = new Vector2(rb.velocity.x , jumpForce);
            //给予y上跳跃的力。X保持
            jumpCount -- ;
            jumpPressed = false  ;
        }

    }

    void FreshData(){
        moveX = Input.GetAxisRaw("Horizontal");
    }
}
