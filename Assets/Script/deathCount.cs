using UnityEngine;

public class deathCount : MonoBehaviour
{
    // Update is called once per frame
    public float death;

    private void Update()
    {
        killSelf();
    }

    public void killSelf()
    {
        Destroy(gameObject, death);
    }
}