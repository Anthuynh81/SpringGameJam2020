using UnityEngine;

public class ITDLF : MonoBehaviour
{
    public GameObject block;
    public GameObject blockSpawnPoint;
    public float limit = 0;
    public float reload = 0;
    public KeyCode control;

    public FixedJoint2D hellaJoint;
    public GameObject JointOne;
    public GameObject JointTwo;
    public GameObject JointThree;
    private Rigidbody2D rb;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        JointOne = GameObject.FindWithTag("JointOne");
        JointTwo = GameObject.FindWithTag("JointTwo");
        JointThree = GameObject.FindWithTag("JointThree");
        Debug.Log(JointOne.name);
        hellaJoint = GetComponent<FixedJoint2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(control) && limit < 5f)
        {
            dropBlock();
            ++limit;
        }
        if (limit >= 5f)
        {
            reload++;
        }
        if (reload == 5f)
        {
            limit = 0;
        }
    }

    private void dropBlock()
    {
        Instantiate(block.transform, blockSpawnPoint.transform.position, blockSpawnPoint.transform.rotation);
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