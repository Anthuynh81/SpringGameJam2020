using UnityEngine;

public class dragndrop : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool beingHeld = false;
    private Rigidbody2D rbTwoD;

    // Start is called before the first frame update
    private void Start()
    {
    }

    private void Update()
    {
        if (beingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.position = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
            rbTwoD = gameObject.GetComponent<Rigidbody2D>();

            var d = Input.GetAxis("Mouse ScrollWheel");
            if (d > 0f)
            {
                rbTwoD.rotation += 10;
            }
            else if (d < 0f)
            {
                rbTwoD.rotation -= 10;
            }
        }
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;

            beingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        beingHeld = false;
    }
}