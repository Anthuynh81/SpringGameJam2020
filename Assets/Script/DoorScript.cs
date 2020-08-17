using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool doorIsOpen = false;
    // Start is called before the first frame update
    public float openPosition;
    public float closedPosition;
    public float doorOffset = 100f;
    public float moveTime = 1.0f;
    private Vector3 velocity = Vector3.zero;
    private AudioSource audioData;
    void Start()
    {
        closedPosition = transform.position.y;
        openPosition = closedPosition + doorOffset;
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition;
        if (doorIsOpen)
        {
            targetPosition = new Vector3(transform.position.x, openPosition, 0);
        } else
        {
            targetPosition = new Vector3(transform.position.x, closedPosition, 0);
        }

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, moveTime);
    }

    //take a wild guess what this does
    public void activate()
    {
        doorIsOpen = true;
        audioData.Stop();
        audioData.Play();
    }

    //this too
    public void deactivate()
    {
        doorIsOpen = false;
        audioData.Stop();
        audioData.Play();
    }
}
