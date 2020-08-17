using System.Collections;
using UnityEngine;

public class jettyControl : MonoBehaviour
{
    // Variables
    //public float speed = 6.0f;
    //public float jumpSpeed = 8.0f;
    //public float gravity = 20.0f;
    //private Vector2 stuff;

    private Rigidbody2D rb;
    private GameObject player;
    public float speed = 40f;
    private bool engineOn;
    private bool recharge;
    private bool isEngineRunning = false;
    public int engineRuntime = 1;
    public int rechargeTime = 5;
    public KeyCode control;
    public int attachmentSide;
    public FixedJoint2D hellaJoint;
    public GameObject JointOne;
    public GameObject JointTwo;
    public GameObject JointThree;

    private void Start()
    {
        engineOn = false;
        recharge = false;
        player = GameObject.FindWithTag("Player");
        JointOne = GameObject.FindWithTag("JointOne");
        JointTwo = GameObject.FindWithTag("JointTwo");
        JointThree = GameObject.FindWithTag("JointThree");
        Debug.Log(JointOne.name);
        hellaJoint = GetComponent<FixedJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(control))
        {
            engineOn = true;
        }

        if (Input.GetKeyUp(control))
        {
            engineOn = false;
        }
        Debug.Log(player.transform.eulerAngles.z);
        Debug.Log(transform.eulerAngles.z);
    }

    private void FixedUpdate()
    {
        if (!recharge)
        {
            switch (engineOn)
            {
                case true:
                    Debug.Log("The engine is on");
                    rb.AddRelativeForce(new Vector2(speed, 0f), ForceMode2D.Force);
                    player.GetComponent<Rigidbody2D>().AddTorque(25f, ForceMode2D.Force);
                    //StartCoroutine(engineRunsFor(1));
                    break;

                case false:
                    rb.AddRelativeForce(new Vector2(0f, 0f), ForceMode2D.Force);
                    break;
            }
        }
    }

    private IEnumerator engineRunsFor(float time)
    {
        if (isEngineRunning)
            yield break;

        isEngineRunning = true;

        yield return new WaitForSeconds(time);

        engineOn = false;
        recharge = true;
        StartCoroutine(rechargeTiming(engineRuntime));

        isEngineRunning = false;
    }

    private IEnumerator rechargeTiming(float time)
    {
        yield return new WaitForSeconds(rechargeTime);

        recharge = false;
    }

    public void setAttachmentSide(int side)
    {
        attachmentSide = side;
    }

    public void jointOneAttach(GameObject Object)
    {
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