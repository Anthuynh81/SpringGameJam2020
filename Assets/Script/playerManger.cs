using UnityEngine;

public class playerManger : MonoBehaviour
{
    public Rigidbody2D rb;
    public float torque = 20f;
    private HingeJoint2D POJoint;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            float turn = Input.GetAxis("Horizontal");
            rb.AddTorque(torque * turn * -1, ForceMode2D.Force);
        }

        if (Input.GetKey("d"))
        {
            float turn = Input.GetAxis("Horizontal");
            rb.AddTorque(torque * turn * -1, ForceMode2D.Force);
        }
    }
}