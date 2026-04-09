using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float maxDistance;
    
    private Rigidbody2D rb;
    private Camera mainCamera;
    private Vector2 startPosition, clampedPosition;

    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        rb.iskinematic = true;
        startPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        Vector2 dragPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        clampedPosition = dragPosition;

        float dragDistance = Vector2.Distance(startPosition, dragPosition);
        
        if(dragDistance > maxDistance) { 
            clampedPosition = startPosition + (dragPosition - startPosition).normalized * maxDistance;
        }

        if(dragPosition.x > startPosition.x) 
        { 
            clampedPosition.x = startPosition.x;
        }
        transform.position = clampedPosition;
    }

    private void OnMouseUp()
    {
        rb.iskinematic = false;
        Vector2 throwVector = startPosition - clampedPosition;
        rb.AddForce(throwVector * force);

        float resetTime = 5f;
        Invoke("Reset", resetTime);
    }

    private void Reset()
    {
        transform.position = startPosition;
        rb.iskinematic = true;
        rb.linearVelocity = Vector2.zero;
    }


}
