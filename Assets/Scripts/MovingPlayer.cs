/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovingPlayer : MonoBehaviour
{
    public float MoveTime = 0.1f;                   // Time it takes to complete the move
    public LayerMask blockingLayer;                 // Used to see if space is open to move in to

    private BoxCollider2D BoxCollider;
    private Rigidbody2D Rigidbody;
    private float InverseMovetime;

    // Start is called before the first frame update
    // Protected virtual can be overwtritten by inheriting classes.
    protected virtual void Start()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
        Rigidbody = GetComponent<Rigidbody2D>();
        InverseMovetime = 1f / MoveTime;
        
    }

    //Move returns true if it is able to move and false if not. 
    //Move takes parameters for x direction, y direction and a RaycastHit2D to check collision.
    protected bool Move (int xDir, int yDir, out RaycastHit2D hit)
    {
        //Store start position to move from, based on objects current transform position.
        Vector2 start = transform.position;
        // Calculate end position based on the direction parameters passed in when calling Move.
        Vector2 end = start + new Vector2 (xDir, yDir);
        //Disable the boxCollider so that linecast doesn't hit this object's own collider.
        boxCollider.enabled = false;
        //Cast a line from start point to end point checking collision on blockingLayer.
        hit = Physics2D.Linecast (start, end, blockingLayer);
        //Re-enable boxCollider after linecast
        boxCollider.enabled = true;

        //Check if anything was hit
        if(hit.transform == null)
        {
            //If nothing was hit, start SmoothMovement co-routine passing in the Vector2 end as destination
            StartCoroutine (SmoothMovement (end));
            //Return true to say that Move was successful
            return true;
        }

        //If something was hit, return false, Move was unsuccesful.
        return false;
    }

    // Takes end as a parameter so it knows where to move to.
    protected IEnumerator SmoothMovement (Vector3 end)
    {
        //Calculate the remaining distance to move based on the square magnitude of the difference between current position and end parameter. 
        //Square magnitude is used instead of magnitude because it's computationally cheaper.
        float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

        //While that distance is greater than a very small amount (Epsilon, almost zero):
        while(sqrRemainingDistance > float.Epsilon)
        {
            //Find a new position proportionally closer to the end, based on the moveTime
            Vector3 newPostion = Vector3.MoveTowards(Rigidbody.position, end, InverseMoveTime * Time.deltaTime);
            //Call MovePosition on attached Rigidbody2D and move it to the calculated position.
            Rigidbody.MovePosition (newPostion);
            //Recalculate the remaining distance after moving.
            sqrRemainingDistance = (transform.position - end).sqrMagnitude;
            //Return and loop until sqrRemainingDistance is close enough to zero to end the function
            yield return null;
        }

    }

    //The virtual keyword means AttemptMove can be overridden by inheriting classes using the override keyword.
    //AttemptMove takes a generic parameter T to specify the type of component we expect our unit to interact with if blocked (Player for Enemies, Wall for Player).
    protected virtual void AttemptMove <T> (int xDir, int yDir)
        where T : Component
    {
        //Hit will store whatever our linecast hits when Move is called.
        RaycastHit2D hit;
        //Set canMove to true if Move was successful, false if failed.
        bool canMove = Move (xDir, yDir, out hit);
        //Check if nothing was hit by linecast
        if(hit.transform == null)
            //If nothing was hit, return and don't execute further code.
            return;
        //Get a component reference to the component of type T attached to the object that was hit
        T hitComponent = hit.transform.GetComponent <T> ();
        //If canMove is false and hitComponent is not equal to null, meaning MovingObject is blocked and has hit something it can interact with.
        if(!canMove && hitComponent != null)
            //Call the OnCantMove function and pass it hitComponent as a parameter.
            OnCantMove (hitComponent);
    }


    //The abstract modifier indicates that the thing being modified has a missing or incomplete implementation.
    //OnCantMove will be overriden by functions in the inheriting classes.
    protected abstract void OnCantMove <T> (T component)
        where T : Component;

    // Update is called once per frame
    void Update()
    {
        
    }
}
 */