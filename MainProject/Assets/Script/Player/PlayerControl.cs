using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : SingletonMono<PlayerControl>
{
    public static PlayerControl instance ;

    [Header("基础组件")]
    Rigidbody2D rb ; 
    Animator    anim ;
    private LayerMask ground;//“地面”



    [Header("基础数值")]
    public bool canMove = true; //玩家当前是否是可移动状态
    public float speed ;
    public float moveX ;
    public float jumpForce ;
    public bool isGround,isJump ;
    public Collider2D feet;
    bool jumpPressed ; //是否按下跳跃

    
    void Start()
    {
        rb   =  GetComponent<Rigidbody2D>();
        anim =  GetComponent<Animator>();
        ground= LayerMask.GetMask("Ground");
    }

    private void FixedUpdate()
    {
        isGround = feet.IsTouchingLayers(ground.value);
    }

    void Update()
    {
        FreshData();

        //移动判定区
        if (canMove)
        {
            PlayerMovement();
            if (Input.GetButtonDown("Jump")) jumpPressed = true;
        }
       if(jumpPressed) Jump();
        
    }
    
    /// <summary>
    /// 水平移动
    /// </summary>
    void PlayerMovement()
    {
        rb.velocity = new Vector2( moveX * speed , rb.velocity.y);
        if(moveX>0)  transform.localScale = new Vector3(1,1,1);
        if(moveX<0)   transform.localScale = new Vector3(-1,1,1);

    }

    void Jump() 
    {
        if (!jumpPressed) return;
       if(isGround) rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpPressed = false;
    }


    void FreshData()
    {
        moveX = Input.GetAxisRaw("Horizontal");
    }
}
