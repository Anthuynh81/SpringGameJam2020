using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public float speedMod;
    // Platform will alternate between the starting position and the one defined
    // Note: If the topRightPos is below or to the left of the start position,
    //      the platform will behave unpredictably
    public Vector3 topRightPos;
    private float startX;
    private float startY;
    private float endX;
    private float endY;
    private bool isMovingTopRight;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
        endX = topRightPos.x;
        endY = topRightPos.y;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingTopRight)
        {
            transform.Translate(Time.deltaTime * speedMod * (endX - startX), Time.deltaTime * speedMod * (endY - startY), 0);
        }
        else
        {
            transform.Translate(Time.deltaTime * speedMod * (endX - startX) * -1, Time.deltaTime * speedMod * (endY - startY) * -1, 0);
        }
        
        //If the platform has passed its down/right bound
        if (transform.position.x > endX || transform.position.y > endY)
        {
            isMovingTopRight = false;
            //If the platform has passed its top/left bound
        } else if (transform.position.x < startX || transform.position.y < startY)
        {
            isMovingTopRight = true;
        }
     
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(player) && Input.GetAxisRaw("Horizontal") == 0)
        {
            collision.transform.parent = transform;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(player))
        {
            player.transform.parent = null;
        }

    }

}
