using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireScript : MonoBehaviour
{
    public GameObject nextWire;
    private SpriteRenderer spriteR;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteR = this.GetComponent<SpriteRenderer>();
        spriteR.color = new Color(0.5f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate()
    {
        if (nextWire != null)
        {
            nextWire.GetComponent<WireScript>().activate();
        }
        spriteR.color = new Color(0.8f, 0f, 0f);
    }
    
    public void deactivate()
    {
        if (nextWire != null)
        {
            nextWire.GetComponent<WireScript>().deactivate();
        }
        spriteR.color = new Color(0.5f, 0f, 0f);
    }
}
