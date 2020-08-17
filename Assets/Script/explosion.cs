using UnityEngine;

public class explosion : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boom;

    public float timeLeft;

    // Update is called once per frame
    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Instantiate(boom.transform, transform.position, transform.rotation);
            Destroy(gameObject, 0.1f);
        }
    }
}