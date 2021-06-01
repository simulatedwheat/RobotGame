using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    // Movement Variables
    public float MovementSpeed = 10;        // The players mevemnt speed
    private bool FacingNorth = true;        // Boolean for facing north
    private bool FacingWest = false;        // Boolean for facing West
    private bool FacingEast = false;        // Boolean for facing East
    private bool FacingSouth = false;       // Boolean for facing South

    private Rigidbody2D _rigidbody;         // Rigidbody variable

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();   // Get the rigidbody2d component

    }

    // Update is called once per frame
    void Update()
    {
        var moveNorth = Input.GetButtonDown("up");
        var moveSouth = Input.GetButtonDown("down");
        var moveWest = Input.GetButtonDown("left");
        var moveEast = Input.GetButtonDown("right");



        
    }

    void Move1 ()
    {
        
    }
    void RotateLeft () 
    {
        if (FacingNorth)
        {
            FacingNorth = false;
            FacingWest = true;
        }
        if (FacingEast)
        {
            FacingEast = false;
            FacingNorth = true;
        }
        if (FacingSouth)
        {
            FacingSouth = false;
            FacingEast = true;
        }
        if (FacingWest)
        {
            FacingWest = false;
            FacingSouth = true;
        }
    }

}
