using UnityEngine;

public class JointConnectorTwo : MonoBehaviour
{
    // variable

    public GameObject Object;
    private GameObject currentAttachment;
    private FixedJoint2D currentJoint;
    private HingeJoint2D specialJoint;

    public void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Attachment"))
        {
            Object = collision.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Attachment") && Input.GetMouseButtonUp(0))
        {
            Object = collision.gameObject;
            if (Object != currentAttachment && currentAttachment != null)
            {
                currentJoint.connectedBody = null;
                specialJoint.connectedBody = null;
            }

            switch (Object.ToString())
            {
                //Set case to the toString result of the attachment's GameObject
                case "JettyPack (UnityEngine.GameObject)":
                    Object.SendMessage("jointTwoAttach", Object);
                    break;

                case "ITDLF (UnityEngine.GameObject)":
                    Object.SendMessage("jointTwoAttach", Object);
                    break;

                case "Spring (UnityEngine.GameObject)":
                    Object.SendMessage("jointTwoAttach", Object);
                    break;

                case "RollyBombLauncher (UnityEngine.GameObject)":
                    Object.SendMessage("jointTwoAttach", Object);
                    break;

                case "LowerArm (UnityEngine.GameObject)":
                    Object.SendMessage("jointTwoAttach", Object);
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Object = null;
    }

    private void currentObject(GameObject curAttach)
    {
        currentAttachment = curAttach;
        if (curAttach.ToString() == "ArmPivot (UnityEngine.GameObject)")
        {
            specialJoint = currentAttachment.GetComponent<HingeJoint2D>();
        }
        else
        {
            currentJoint = currentAttachment.GetComponent<FixedJoint2D>();
        }
    }

    //JointOne.SendMessage("currentJoint", this.gameObject);
}