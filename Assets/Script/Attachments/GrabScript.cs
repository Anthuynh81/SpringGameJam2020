using UnityEngine;

public class GrabScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool grabbed;

    private KeyCode control;
    public float distance;
    private RaycastHit2D hit;
    public Transform hold;
    private bool hasJoint;

    private SpringJoint2D joint;

    private void Start()
    {
        hasJoint = false;
        grabbed = false;
        control = KeyCode.G;
        distance = 0.5f;
        joint = GetComponent<SpringJoint2D>();
        joint.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(control))
        {
            if (!grabbed)
            {
                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
                if (hit.collider != null)
                {
                    grabbed = true;
                }
            }
            else
            {
                grabbed = false;
                joint.enabled = false;
                joint.connectedBody = null;
            }
        }

        if (grabbed && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            joint.enabled = true;
            joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
        }
    }
}