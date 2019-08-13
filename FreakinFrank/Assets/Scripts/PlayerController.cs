using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public float walkSpeed;
    public float jumpForce;  
    public AudioSource coinSound;  
    Rigidbody rb; // Rigidbody is used to allow physics interactions.    
    Collider col; // We will use the collider to get the size of the player for raycasting
    bool isJumpPressed = false;
    Vector3 size; // To hold the player size

    // Start is called before the first frame update
    void Start()
    {
        // Getting the game objects rigidbody data
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        size = col.bounds.size;
    }

    // FixedUpdate is used for physics handling (e.g. Rigidbody)
    void Update()
    {
        WalkHandler();
        JumpHandler();
        
    }
    void WalkHandler(){
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(walkSpeed*hAxis*Time.deltaTime,0,walkSpeed*vAxis*Time.deltaTime);
        
        //transform.position += move;
        Vector3 newPos = transform.position+move;

        // Now we move the rigidbody rather than adjusting the transform values directly:
        rb.MovePosition(newPos);

    }
    void JumpHandler(){
        float jAxis = Input.GetAxis("Jump");
        
        //if (jAxis>0 && rb.velocity.y == 0)
        if (jAxis > 0)
        {
            bool isGrounded = CheckGrounded();
            //print(isGrounded);
            if(!isJumpPressed && isGrounded)
            {
                //float initPos = transform.position.y;
                isJumpPressed = true;
                Vector3 jumpVector = new Vector3(0,jAxis*jumpForce,0);
                rb.AddForce(jumpVector, ForceMode.VelocityChange);
            }
            else
            {
                isJumpPressed = false;
                
            }
        }

    }
    bool CheckGrounded()
    {
        // Define bottom 4 corners (with relation to transform point)
        Vector3 c1 = transform.position + new Vector3(size.x/2, (-size.y/2 + 0.01f), size.z/2);
        Vector3 c2 = transform.position + new Vector3(-size.x/2, (-size.y/2 + 0.01f), size.z/2);
        Vector3 c3 = transform.position + new Vector3(-size.x/2, (-size.y/2 + 0.01f), -size.z/2);
        Vector3 c4 = transform.position + new Vector3(size.x/2, (-size.y/2 + 0.01f), -size.z/2);

        // Check if we are grounded
        bool g1 = Physics.Raycast(c1, -Vector3.up, 0.02f);
        bool g2 = Physics.Raycast(c2, -Vector3.up, 0.02f);
        bool g3 = Physics.Raycast(c3, -Vector3.up, 0.02f);
        bool g4 = Physics.Raycast(c4, -Vector3.up, 0.02f);

        // Using OR in return statement means only one needs to be true to return "true" value
        // To return "false" all statements must equate to false
        return (g1 || g2 || g3 || g4);
        

    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {        
        if(other.CompareTag("coin")){
            GameManager.instance.IncreaseScore(1);
            Destroy(other.gameObject);
            coinSound.Play();
        }
        else if(other.CompareTag("enemy")){
            print("Collided with enemy!");
        }
        else if(other.CompareTag("goal")){
            print("Made it!");
        }
        
    }
}
