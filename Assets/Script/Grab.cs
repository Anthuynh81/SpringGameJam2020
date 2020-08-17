using UnityEngine;

public class Grab : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode control;

    private FixedJoint2D myJoint;
    public bool isJoint;
    public GameObject Object;
    public GameObject currentlyHolding;
    public bool isEnabled;

    public GameObject cursor;
    public SpringJoint2D spring;

    private void Start()
    {
        spring = GetComponent<SpringJoint2D>();
        spring.enabled = false;
        cursor = GameObject.FindWithTag("Cursor");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(control) && !isEnabled)
        {
            isEnabled = true;
            spring.enabled = true;
            spring.connectedBody = cursor.GetComponent<Rigidbody2D>();
        }
        else if (Input.GetKeyDown(control) && isEnabled)
        {
            isEnabled = false;
            currentlyHolding.GetComponent<BoxCollider2D>().isTrigger = false;
            //currentlyHolding.GetComponent<CircleCollider2D>().isTrigger = false;
            Destroy(myJoint);
            spring.connectedBody = null;
            spring.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTrigger");
        Object = collision.gameObject;
        if (isEnabled && Object.tag == "grab")
        {
            gameObject.AddComponent<FixedJoint2D>();
            myJoint = GetComponent<FixedJoint2D>();
            myJoint.connectedBody = Object.GetComponent<Rigidbody2D>();
            myJoint.autoConfigureConnectedAnchor = true;
            Object.GetComponent<BoxCollider2D>().isTrigger = true;
            //Object.GetComponent <CircleCollider2D>().isTrigger = true;
            currentlyHolding = Object;

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Object = collision.gameObject;
    }
        
    private void OnTriggerExit2D(Collider2D collision)
    {
        Object = null;
    }
}