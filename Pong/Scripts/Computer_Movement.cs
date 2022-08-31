using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer_Movement : MonoBehaviour
{
    //variables to hold pressed keys
    public KeyCode move_player_down = KeyCode.DownArrow;
    public KeyCode move_player_up = KeyCode.UpArrow;

    //variables to hold speed values
    public float speed = 10.0f;

    //variable fpr y axis boundary in global scene 
    public float y_axis_boundary = 2.25f;

    //private rigid body class instance for movement
    private Rigidbody2D rigid_body_2d; 

    // Start is called before the first frame update
    void Start()
    {
        //call get component to set up our rigid body when start is called
        rigid_body_2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //declare an inplcit variable with var keyword
        //set rigid body instance to velocity member variable
        var velocity = rigid_body_2d.velocity;

        //check for key presses
        
        //if player presses either down arrow or 's'
        if(Input.GetKey(move_player_down))
        {
            velocity.y = -speed; 
        }
        //if player presses either down arrow or 's'
        else if(Input.GetKey(move_player_up))
        {
            velocity.y = speed;
        }
        else
        {
            velocity.y = 0; 
        }

        //set the velocity of our rigid body to the newly obtained velocity from detected movement 
        rigid_body_2d.velocity = velocity;

        //create and implicit variable to hold our transformed position point
        var position = transform.position;

        
        //check if the position is out of bounds
        if(position.y > y_axis_boundary)
        {
            position.y = y_axis_boundary;
        }

        if(position.y < -y_axis_boundary)
        {
            position.y = -y_axis_boundary;
        }

        //transform and set the position
        transform.position = position;
    }
}