using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Transform tr;
    public float speed=10f;
    public float JumpForce=1000f;
    private bool canJump=false;
    // Start is called before the first frame update
    //reserved function, Runs only once when the object is created
   void Start() {
       rBody=GetComponent<Rigidbody2D>();
       tr=GetComponent<Transform>();
   }
    // Update is called once per frame
    void Update() {
     if(Input.GetKeyDown(KeyCode.Space)) //listens to my spacebar key being pressed
     {
         rBody.AddForce(new Vector2(0,JumpForce));
     }   
     if(Input.GetKeyDown(KeyCode.RightArrow))
     {
         tr.localScale=new Vector3( -1.5f,1.5f,1.5f);
     }
     if(Input.GetKeyDown(KeyCode.LeftArrow))
     {
         tr.localScale=new Vector3( 1.5f,1.5f,1.5f);
     }
     
     //ray cast from you feet downwords towards the  ground
     //Physics2D.Raycast()
     if(rBody.velocity.y==0.0)
        canJump=true;
    }
    //This function is called every fixed framerate frame, if the monobehviour is enabled
    //Use fixed updat efor physics based movement only
    void FixedUpdate()
    {
        float hor=Input.GetAxis("Horizontal");
       // float ver=Input.GetAxis("Vertical");
        //GetComponent<Rigidbody2D>().velocity=new Vector2(hor,ver);
        rBody.velocity=new Vector2(hor*speed,rBody.velocity.y);
    }
}
