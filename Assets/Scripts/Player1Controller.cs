using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    // Movement Variables
    public float MovementSpeed = 10;
    public int DirectionCount = 0;
    private Rigidbody2D _rigidbody;         // Rigidbody variable

    public bool FacingNorth = true;

    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        Debug.Log(pos);
        _rigidbody = GetComponent<Rigidbody2D>();   // Get the rigidbody2d component

    }

    // Update is called once per frame
    void Update()
    {
        Move();        
    }

    void Move ()
    {
        var moveVertical = 5f;
        if (DirectionCount == 4 || DirectionCount == -4)
            {
                DirectionCount = 0;
            }
        if (Input.GetKeyDown("up"))
        {
            if (DirectionCount == 0)
            {
                transform.position += new Vector3(0, moveVertical, 0) * Time.fixedDeltaTime * MovementSpeed;
            }
            else if (DirectionCount == 1 || DirectionCount == -3) 
            {
                transform.position += new Vector3(moveVertical, 0, 0) * Time.fixedDeltaTime * MovementSpeed;
            }
            else if (DirectionCount == 2 || DirectionCount == -2)
            {
                transform.position += new Vector3(0, -moveVertical, 0) * Time.fixedDeltaTime * MovementSpeed;
            }
            else if (DirectionCount == 3 || DirectionCount == -1)
            {
                transform.position += new Vector3(-moveVertical, 0, 0) * Time.fixedDeltaTime * MovementSpeed;
            }
            
        }
        
        if (Input.GetKeyDown("down"))
        {
            if (DirectionCount == 0)
            {
                transform.position += new Vector3(0, -moveVertical, 0) * Time.fixedDeltaTime * MovementSpeed;
            }
            else if (DirectionCount == 1 || DirectionCount == -3) 
            {
                transform.position += new Vector3(-moveVertical, 0, 0) * Time.fixedDeltaTime * MovementSpeed;
            }
            else if (DirectionCount == 2 || DirectionCount == -2)
            {
                transform.position += new Vector3(0, moveVertical, 0) * Time.fixedDeltaTime * MovementSpeed;
            }
            else if (DirectionCount == 3 || DirectionCount == -1)
            {
                transform.position += new Vector3(moveVertical, 0, 0) * Time.fixedDeltaTime * MovementSpeed;
            }

            
        }
        
        if (Input.GetKeyDown("right"))
        {
            RotateRight();
            var rot = transform.rotation;
            Debug.Log(DirectionCount);
        }
        if (Input.GetKeyDown("left"))
        {
            RotateLeft();
            pos = transform.position;
            Debug.Log(DirectionCount);
        }
    }
    void RotateRight()
    {
        DirectionCount += 1;
        transform.Rotate(0f, 0f, -90f);
    }
    void RotateLeft()
    {
        DirectionCount -= 1;
        transform.Rotate(0f, 0f, 90f);
    }
}
