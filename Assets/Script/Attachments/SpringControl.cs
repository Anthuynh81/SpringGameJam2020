using UnityEngine;

public class SpringControl : MonoBehaviour
{
    //Basic Variables
    private Rigidbody2D rb;

    public float speed;
    private float speedModifier;
    private bool isHeld;
    public KeyCode control;

    //Variables for ground detection
    private bool touchingGround;

    public Transform bottomPos;
    public float checkRadius;
    public LayerMask jumpSurface;

    //Variables for compression
    public GameObject spring;

    private Vector3 temp;

    public FixedJoint2D hellaJoint;
    public GameObject JointOne;
    public GameObject JointTwo;
    public GameObject JointThree;
    private GameObject player;

    private void Start()
    {
        //Initializes the main variables
        isHeld = false;
        speedModifier = 0;
        control = KeyCode.UpArrow;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        JointOne = GameObject.FindWithTag("JointOne");
        JointTwo = GameObject.FindWithTag("JointTwo");
        JointThree = GameObject.FindWithTag("JointThree");
        hellaJoint = GetComponent<FixedJoint2D>();
    }

    private void fixedUpdate()
    {
    }

    private void Update()
    {
        //Checks to see if the button is held
        if (Input.GetKeyDown(control))
        {
            isHeld = true;
        }
        else if (Input.GetKeyUp(control))
        {
            isHeld = false;
        }
        //Causes the jump if the spring is on the ground
        touchingGround = Physics2D.OverlapCircle(bottomPos.position, checkRadius, jumpSurface);
        if (touchingGround == true && Input.GetKeyUp(control))
        {
            //Make sure the speed modifier is too high
            if (speedModifier > 2)
            {
                speedModifier = 2;
            }

            //Causes the jumping action
            rb.AddForce(new Vector2(0f, speed * (speedModifier + 1)), ForceMode2D.Force);

            //Resets the speed modifier
            speedModifier = 0;
        }

        //Spring compression when button is held
        if (isHeld)
        {
            temp = transform.localScale;

            if (temp.y >= 0.6)
            {
                temp.y -= Time.deltaTime / 3;
            }

            speedModifier += Time.deltaTime / 2;

            transform.localScale = temp;
        }
        else
        {
            temp = transform.localScale;

            if (temp.y <= 1)
            {
                temp.y += Time.deltaTime * 5;
            }

            transform.localScale = temp;
        }
    }

    public void jointOneAttach(GameObject Object)
    {
        Debug.Log("Spring to 1");
        transform.position = JointOne.transform.position;
        hellaJoint.enabled = false;
        /**gameObject.**/

        Rigidbody2D prb = player.GetComponent<Rigidbody2D>();
        rb.rotation = prb.rotation;

        //transform.Rotate(player.transform.rotation.eulerAngles);
        hellaJoint.enabled = true;
        Debug.Log(transform.eulerAngles);
        hellaJoint.connectedBody = player.GetComponent<Rigidbody2D>();
        hellaJoint.autoConfigureConnectedAnchor = false;
        control = KeyCode.Alpha1;
    }

    public void jointTwoAttach(GameObject Object)
    {
        Debug.Log("Spring to 2");
        transform.position = JointTwo.transform.position;
        hellaJoint.enabled = false;
        /**gameObject.**/

        Rigidbody2D prb = player.GetComponent<Rigidbody2D>();
        rb.rotation = prb.rotation + 60f + 180f;

        //transform.Rotate(player.transform.rotation.eulerAngles);
        hellaJoint.enabled = true;
        Debug.Log(transform.eulerAngles);
        hellaJoint.connectedBody = player.GetComponent<Rigidbody2D>();
        hellaJoint.autoConfigureConnectedAnchor = false;
        control = KeyCode.Alpha2;
    }

    public void jointThreeAttach(GameObject Object)
    {
        Debug.Log("Spring to 3");
        transform.position = JointThree.transform.position;
        hellaJoint.enabled = false;
        /**gameObject.**/

        Rigidbody2D prb = player.GetComponent<Rigidbody2D>();
        rb.rotation = prb.rotation + 120f;

        //transform.Rotate(player.transform.rotation.eulerAngles);
        hellaJoint.enabled = true;
        Debug.Log(transform.eulerAngles);
        hellaJoint.connectedBody = player.GetComponent<Rigidbody2D>();
        hellaJoint.autoConfigureConnectedAnchor = false;
        control = KeyCode.Alpha3;
    }
}