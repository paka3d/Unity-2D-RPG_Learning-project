using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D theRB;
    //public int value;
    public float moveSpeed;
    public Animator myAnim;
    public bool canMove = true;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    private float halfHeight;
    private float halfWidth;

    public static PlayerControl instance;    // There can only be one // 

    public string areaTransitionName;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;  // Game starts with already one player control //
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }

            Destroy(gameObject);  // this removes duplicate player control //
        }

       
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
          
        }
        else
        {
            theRB.velocity =  Vector2.zero;
        }

        myAnim.SetFloat("MoveX", theRB.velocity.x);
        myAnim.SetFloat("MoveY", theRB.velocity.y);


        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            if(canMove)
            {
                myAnim.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
                myAnim.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
            }

           
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    public void SetBounds(Vector3 botLeft, Vector3 topRight)
    {
        bottomLeftLimit = botLeft;
        topRightLimit = topRight;
    }
}
