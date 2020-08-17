using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonTrigger : MonoBehaviour
{
    // objectToActivate is the object triggered by this button
    public GameObject objectToActivate;
    // collisionObject is the object this collides with when activated
    public GameObject collisionObject;
    // startOfWireChain is the first wire in the chain of wires stemming from this button
    public GameObject startOfWireChain;
    private AudioSource audioData;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(collisionObject))
        {
            objectToActivate.GetComponent<DoorScript>().activate();
            startOfWireChain.GetComponent<WireScript>().activate();
            audioData.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(collisionObject))
        {
            objectToActivate.GetComponent<DoorScript>().deactivate();
            startOfWireChain.GetComponent<WireScript>().deactivate();
            audioData.Play();

        }
    }
}
