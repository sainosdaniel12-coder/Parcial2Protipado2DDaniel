using UnityEngine;

public class Cerdo : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool isBird = collision.gameObject.GetComponent<Bird>();

        if (isBird)
        {
            Destroy(gameObject);
        }

        float crushThreshold = -0.5f;
        bool isCrushed = collision.contacts[0].normal.y < crushThreshold;

        if (isCrushed)
        {
            Destroy(gameObject);
        }
    }
}
