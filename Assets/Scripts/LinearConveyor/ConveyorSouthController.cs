using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSouthController : MonoBehaviour
{
    public Transform PlayerTransform; 
    public float ConveyorSpeed = 10;
    public float MoveVertical = 1.25f;
    public static int moveCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     void OnTriggerEnter2D (Collider2D PlayerContact) 
    {
        Debug.Log(moveCount);
        if (moveCount >= 1)
        {
            Debug.Log("Player has already been moved");
        }
        else if (PlayerContact.tag == "Player" && (moveCount < 1)){
            PlayerTransform = GameObject.Find(PlayerContact.name).transform;
            StartCoroutine(ConveyorMove());
            moveCount += 1;
            Debug.Log(moveCount);

        }
    }
    void OnTriggerStay2D (Collider2D PlayerContact) 
    {
        Debug.Log(moveCount);
        if (moveCount >= 1)
        {
            Debug.Log("Player has already been moved");
        }
        else if (PlayerContact.tag == "Player" && (moveCount < 1)){
            PlayerTransform = GameObject.Find(PlayerContact.name).transform;
            StartCoroutine(ConveyorMove());
            moveCount += 1;
            Debug.Log(moveCount);

        }
    }

    IEnumerator ConveyorMove()
    {
        yield return new WaitForSeconds(0.5f);
        PlayerTransform.position += new Vector3(0, - MoveVertical, 0) * Time.fixedDeltaTime * ConveyorSpeed;
        yield return new WaitForSeconds(0.15f);
        PlayerTransform.position += new Vector3(0, - MoveVertical, 0) * Time.fixedDeltaTime * ConveyorSpeed;
        yield return new WaitForSeconds(0.15f);
        PlayerTransform.position += new Vector3(0, - MoveVertical, 0) * Time.fixedDeltaTime * ConveyorSpeed;
        yield return new WaitForSeconds(0.15f);
        PlayerTransform.position += new Vector3(0, - MoveVertical, 0) * Time.fixedDeltaTime * ConveyorSpeed;
    }

}
