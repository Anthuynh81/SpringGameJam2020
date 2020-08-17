using UnityEngine;

public class ArmControl : MonoBehaviour
{
    // variables
    private Rigidbody2D rb;

    private GameObject player;
    public HingeJoint2D[] hellaJoint;
    public GameObject JointOne;
    public GameObject JointTwo;
    public GameObject JointThree;
    public GameObject Magnet;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
        JointOne = GameObject.FindWithTag("JointOne");
        JointTwo = GameObject.FindWithTag("JointTwo");
        JointThree = GameObject.FindWithTag("JointThree");
        Magnet = GameObject.FindWithTag("Magnet");
        hellaJoint = GetComponents<HingeJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Methods
    public void Update()
    {
    }

    public void jointOneAttach(GameObject Object)
    {
        transform.position = JointOne.transform.position;
        //transform.Rotate(JointOne.transform.rotation.eulerAngles);
        hellaJoint[1].connectedBody = JointOne.GetComponent<Rigidbody2D>();
        hellaJoint[1].autoConfigureConnectedAnchor = false;
        JointOne.SendMessage("currentObject", this.gameObject);
        Magnet.GetComponent<Grab>().control = KeyCode.Alpha1;
    }

    public void jointTwoAttach(GameObject Object)
    {
        transform.position = JointTwo.transform.position;
        hellaJoint[1].connectedBody = JointTwo.GetComponent<Rigidbody2D>();
        hellaJoint[1].autoConfigureConnectedAnchor = false;
        JointTwo.SendMessage("currentObject", this.gameObject);
        Magnet.GetComponent<Grab>().control = KeyCode.Alpha2;
    }

    public void jointThreeAttach(GameObject Object)
    {
        transform.position = JointThree.transform.position;
        hellaJoint[1].connectedBody = JointThree.GetComponent<Rigidbody2D>();
        hellaJoint[1].autoConfigureConnectedAnchor = false;
        JointThree.SendMessage("currentObject", this.gameObject);
        Magnet.GetComponent<Grab>().control = KeyCode.Alpha3;
    }

    private void FixedUpdate()
    {
    }
}