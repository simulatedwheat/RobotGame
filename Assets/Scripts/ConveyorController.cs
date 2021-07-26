using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{
    public Transform PlayerTransform; 
    public float ConveyorSpeed = 10;
    public float MoveVertical = 5f;
    public static int moveCount = 0;

    //public int moveCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    
    void OnTriggerEnter2D (Collider2D PlayerContact) 
    {
        Debug.Log(PlayerContact.name);
        if (moveCount >= 1)
        {
            Debug.Log("Player has already been moved");
        }
        else if (PlayerContact.tag == "Player" && (moveCount < 1)){
            PlayerTransform = GameObject.Find(PlayerContact.name).transform;
            PlayerTransform.position += new Vector3(0, MoveVertical, 0) * Time.fixedDeltaTime * ConveyorSpeed;
            moveCount += 1;
            Debug.Log(moveCount);

        }
    }
}
