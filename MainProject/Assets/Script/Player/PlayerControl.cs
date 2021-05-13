using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : SingletonMono<PlayerControl>
{

    [Header("基础组件")]
    Rigidbody2D rb ; 
    Animator  anim ;
    private LayerMask ground;//“地面”

    private Vector2 DOWNWARD=new Vector2(0,1);



    [Header("基础数值")]
    private bool canMove = true; //玩家当前是否是可移动状态
    public float speed ;

    public float jumpForce ;
    public bool isGround,isJump ;
    public Transform feet;

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
        isGround = Physics2D.OverlapCircle(feet.position,0.1f,ground);
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
        if(moveX>0)  transform.localScale = new Vector3(-0.2f,0.2f,1);
        if(moveX<0)   transform.localScale = new Vector3(0.2f,0.2f,1);
        if(isGround)
        {
            if(moveX>0||moveX<0) anim.Play("侦探动态");
            else anim.Play("侦探静息");
        }
    }

    void Jump() 
    {
        if (!jumpPressed) return;
       if(isGround) rb.velocity = new Vector2(rb.velocity.x, jumpForce*Time.deltaTime);
        jumpPressed = false;
         anim.Play("侦探跳跃");
    }


    void FreshData()
    {
        moveX = Input.GetAxisRaw("Horizontal");
    }

    /// <summary>
    /// 暂停侦探
    /// </summary>
    public void Pause()
    {
        rb.velocity=new Vector3(0,0,0);
        rb.gravityScale=0;
        anim.Play("侦探静息");
        canMove=false;
    }

    /// <summary>
    /// 允许侦探移动
    /// </summary>
    public void EnableMove()
    {
        canMove=true;
        rb.gravityScale=1;
    }
}
