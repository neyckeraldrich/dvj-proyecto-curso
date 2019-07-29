using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{   
    public float speed;
//    public float distance;
//    private bool movingRight = true;
//    public Transform groundDetection;

    public bool MoveRight;



    // Update is called once per frame
    void Update()
    {
//        transform.Translate(Vector2.right * speed * Time.deltaTime);
//        
//        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position,Vector2.down,distance);
//        if(groundInfo.collider == false){
//            if(movingRight == true){
//                transform.eulerAngles = new Vector3(0,-180,0);
//                movingRight = false;
//            } else {
//                transform.eulerAngles = new Vector3(0,0,0);
//                movingRight = true;
//            }
//        }

        if(MoveRight){
            transform.Translate(2 * Time.deltaTime * speed ,0,0);
            transform.localScale = new Vector2(1,1);
        }else{
            transform.Translate(-2 * Time.deltaTime * speed ,0,0);
            transform.localScale = new Vector2(-1,1);
        }

    }
    
    void OnTriggerEnter2D(Collider2D trig){
        
            if(trig.gameObject.CompareTag("turn")){
                if(MoveRight){
                    MoveRight=false;                
                }else{
                    MoveRight=true; 
                }
            } 
                
    }
    
    
}
