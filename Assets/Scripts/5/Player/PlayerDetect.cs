using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    [SerializeField]  LayerMask layerGround;
    private BoxCollider2D playerBoxCol;
    [SerializeField] BoxCollider2D downBox;
    [SerializeField] BoxCollider2D leftBox;
    [SerializeField] BoxCollider2D rightBox;
    [SerializeField] BoxCollider2D upBox;
    public bool IsWall { get; set; }
    public bool IsGround { get; set; }
    public bool IsAir { get; set; }
    public bool detectLeft { get; set; }
    public bool detectRight { get; set; }
    public bool IsGroundWall { get; set; }
    private bool detectUp;
    void Start()
    {
        playerBoxCol = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        DetectWall();
        DetectUp();
        DetectDown();
        DetectLeft();
        DetectRight();
    }
    private void DetectWall()
    {
        if((detectLeft || detectRight) && IsGround)
        {
            IsGroundWall = true;
        }
        else
        {
            IsGroundWall = false;
        }
        if((detectLeft || detectRight) && IsAir)
        {
            IsWall = true;
        }
        else
        {
            IsWall = false;
        }
    }
    private void DetectUp()
    {
        RaycastHit2D upRay = Physics2D.BoxCast(upBox.bounds.center, upBox.size, 0f, Vector2.up, 0f,layerGround);
        if (upRay)
        {
            detectUp = true;
        }
        else
        {
            detectUp = false;
        }
    }
    private void DetectDown()
    {
        RaycastHit2D downRay = Physics2D.BoxCast(downBox.bounds.center, downBox.size, 0f, Vector2.down, 0, layerGround);
        if (downRay)
        {
            IsGround = true;
            IsAir = false;
        }
        else
        {
            IsAir = true;
            IsGround = false;
        }
    }
    private void DetectLeft()
    {
        RaycastHit2D leftRay = Physics2D.BoxCast(leftBox.bounds.center, leftBox.size, 0f, Vector2.left, 0, layerGround);
        if (leftRay)
        {
            detectLeft = true;
        }
        else
        {
            detectLeft = false;
        }
    }
    private void DetectRight()
    {
        RaycastHit2D rightRay = Physics2D.BoxCast(rightBox.bounds.center, rightBox.size, 0f, Vector2.right, 0, layerGround);
        if (rightRay)
        {
            detectRight = true;
        }
        else
        {
            detectRight = false;
        }
    }
}
