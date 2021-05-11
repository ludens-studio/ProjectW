using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : SingletonMono<PlayerControl>
{

    [Header("基础组件")]
    Rigidbody2D rb ; 
    Animator    anim ;
    private LayerMask ground;//“地面”



    [Header("基础数值")]
    public bool canMove = true; //玩家当前是否是可移动状态
    public float speed ;

    public float jumpForce ;
    public bool isGround,isJump ;
    public Collider2D feet;

    bool jumpPressed ; //是否按下跳跃
    private float moveX;


    void Start()
    {
        rb   =  GetComponent<Rigidbody2D>();
        anim =  GetComponent<Animator>();
        ground= LayerMask.GetMask("Ground");
    }

    private void FixedUpdate()
    {
        isGround = feet.IsTouchingLayers(ground.value);

        FreshData();

        //移动判定区
        if (canMove)
        {
            PlayerMovement();
            if (Input.GetAxis("Jump")>0f) jumpPressed = true;
        }
        if (jumpPressed) Jump();
    }

    void Update()
    {
        
    }
    
    /// <summary>
    /// 水平移动
    /// </summary>
    void PlayerMovement()
    {
        rb.velocity = new Vector2( moveX * speed*Time.deltaTime , rb.velocity.y);
        if(moveX>0)  transform.localScale = new Vector3(1,1,1);
        if(moveX<0)   transform.localScale = new Vector3(-1,1,1);
    }

    void Jump() 
    {
        if (!jumpPressed) return;
       if(isGround) rb.velocity = new Vector2(rb.velocity.x, jumpForce*Time.deltaTime);
        jumpPressed = false;
    }


    void FreshData()
    {
        moveX = Input.GetAxisRaw("Horizontal");
    }
}
