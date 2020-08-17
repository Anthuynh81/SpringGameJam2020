using UnityEngine;

public class blockComponets : MonoBehaviour
{
    public GameObject block;
    public GameObject detect;
    public bool held = false;
    public Vector2 offset;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!held /**&& Input.GetMouseButtonDown(0)**/)
        {
            if (collision.GetType().Equals(detect))
            {
                Vector2 other = collision.transform.position;
                this.gameObject.transform.position = other + offset;
                held = true;
                Debug.Log(other);
                Debug.Log(transform.position);
                Debug.Log(held);
            }
        }
    }
}