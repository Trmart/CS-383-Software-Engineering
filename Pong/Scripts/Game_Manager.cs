using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    //variables for holding players scores 
    public static int player1_Score = 0;
    public static int player2_Score = 0;

    //GUISkin class instance 
    public GUISkin gui_layout;

    //represents our ball object
    GameObject ball; 

    // Start is called before the first frame update
    void Start()
    {
        //set ball as our ball object from game
        ball = GameObject.FindGameObjectWithTag("Ball"); 
    }

    //function to keep and update players scores
    public static void Score(string wall_ID)
    {   
        //check if the ball object hit the right wall
        if(wall_ID == "RightWall")
        {
            //increment player 1's score
            player1_Score++;
        }

        //check if the ball object hit the left wall
        if(wall_ID == "LeftWall")
        {
            //increment player 2's score
            player2_Score++;
        }
    }

    // Update is called once per frame
    void OnGUI()
    {
        GUI.skin = gui_layout; 

        //display player 1's score'
        GUI.Label(new Rect(Screen.width/2 - 150 - 12, 20, 100,100), "" + player1_Score); 

        //display player 2's score'
        GUI.Label(new Rect(Screen.width/2 + 150 + 12, 20, 100,100), "" + player2_Score);

        if(GUI.Button(new Rect(Screen.width/2 - 60, 35, 120, 53), "RESTART"))
        {
            Time.timeScale = 1f; 
            
            //reset the players scores
            player1_Score = 0;
            player2_Score = 0;

            //send message will call a function we specify. Method, value, RequireReceiver. 
            ball.SendMessage("ResetGame", 0.5f, SendMessageOptions.RequireReceiver);

        }

        if(player1_Score == 10)
        {
            Time.timeScale = 0f; 
            //display player 1 winning message
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER ONE WINS");
        
            //call ResetBall() from Ball_Movement.cs with SendMessage() function 
            ball.SendMessage("ResetBallPosition", null, SendMessageOptions.RequireReceiver);
        }
        else if(player2_Score == 10)
        {
            Time.timeScale = 0f; 

            //display player 2 winning message
            GUI.Label(new Rect(Screen.width / 2 - 150, 200, 2000, 1000), "PLAYER TWO WINS");
            
            //call ResetBall() from Ball_Movement.cs with SendMessage() function 
            ball.SendMessage("ResetBallPostion", null, SendMessageOptions.RequireReceiver);
        }
    }
}
