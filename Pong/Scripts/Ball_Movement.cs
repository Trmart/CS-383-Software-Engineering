using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Movement : MonoBehaviour
{
    public Rigidbody2D rigid_body_2d; 

    //function to initialize a random direction for the ball to start moving
    void GoBall()
    {
        float random = Random.Range(0,2); 

        if(random < 1)
        {
            //start moving ball to the right of the screen
            rigid_body_2d.AddForce(new Vector2(20,-15)); 
        }
        else
        {
            //start the ball moving in the left direction of the screen
            rigid_body_2d.AddForce(new Vector2(-20,-15)); 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //get the rigid body components
        rigid_body_2d = GetComponent<Rigidbody2D>();
        //wait 2 seconds and then call GoBall(); 
        Invoke("GoBall",2); 
    }

    //function to reset the balls position and velocity to zero
    void ResetBallPosition()
    {
        //stops ball movement by setting velocity to new zero 2d vector 
        rigid_body_2d.velocity = new Vector2(0,0);
        //sets the balls position to the origin
        transform.position = Vector2.zero;
    }

    //function to reset the game 
    void ResetGame()
    {
        //reset the balls position and velocity to zero
        ResetBallPosition();

        //call GoBall() after waiting 1 second
        Invoke("GoBall", 1); 
    }

    //waits untill the ball collides with a player paddel
    //then adjusts ball movement accordingly
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.collider.CompareTag("Player"))
        {
            //create an instance of the Vector2 class for changing the position and velocity
            Vector2 velocity; 

            velocity.x = rigid_body_2d.velocity.x; 

            velocity.y = (rigid_body_2d.velocity.y / 2.0f) + (collision.collider.attachedRigidbody.velocity.y / 3.0f);

            rigid_body_2d.velocity = velocity;
        }
    }
}
