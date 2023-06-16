using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_Prototype : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerSpeed = 10;
    public int playerJumpPower = 1250;
    public float moveX;
    public bool isGrounded;
    public float distanceToBottomOfPlayer = 0.9f;
    //

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRayCast();
    }
    void PlayerMove()
    {
        //CONTROL
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown ("Jump") && isGrounded == true){
            Jump();
        }
        //ANIMATIONS
        if (moveX != 0)
        {
            GetComponent<Animator>().SetBool("IsRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("IsRunning", false);
        }
        //PLAYER DIRECTION
        if(moveX < 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
    void Jump()
    {
        //JUMP CODE
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower);
        isGrounded = false;
    }
    //void FlipPlayer()
    //{
    //    facingRight = !facingRight;
    //    Vector2 localScale = gameObject.transform.localScale;
    //    localScale.x *= -1;
    //    transform.localScale = localScale;
    //} //old codes
    //void OnCollisionEnter2D(Collision2D col)
    //{
    // old codes too
    //}
    void PlayerRayCast()
    {
        //help me 
        //nhay len
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (rayUp.distance < distanceToBottomOfPlayer && rayUp != null && rayUp.collider != null && rayUp.collider.gameObject.tag == "boxes")
        {
            Destroy(rayUp.collider.gameObject);
        }


        //dap xuong
        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
        if(rayDown.distance < 0.9f && rayDown != null && rayDown.collider != null && rayDown.collider.gameObject.tag == "enemy")
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<Enemy_Move>().enabled = false;
            //Destroy(hit.collider.gameObject);

        }
        if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomOfPlayer && rayDown.collider.gameObject.tag != "enemy")
        {
            isGrounded=true;
        }
    }
}
