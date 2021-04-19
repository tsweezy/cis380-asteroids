using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    private Camera cam;
    private Rigidbody2D targetRb;
    private Vector3 targetSize;
    private float halfHeight, halfWidth;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        targetRb = target.GetComponent<Rigidbody2D>();
        targetSize = target.GetComponent<SpriteRenderer>().bounds.size;
    }
    // Update is called once per frame
    void Update()
    {
        halfHeight = cam.orthographicSize;
        halfWidth = cam.aspect * halfHeight;
    }

    void LateUpdate()
    {
        // the following is logic defining "soft" screen boundaries
        Vector3 targetPosition = target.transform.position;
        Vector2 targetVelocity = targetRb.velocity;

        targetPosition.y = Mathf.Clamp(targetPosition.y, -halfHeight, halfHeight);
        targetPosition.x = Mathf.Clamp(targetPosition.x, -halfWidth, halfWidth);

        if (targetPosition.y == -halfHeight|| targetPosition.y == halfHeight)
            target.GetComponent<Rigidbody2D>().velocity = new Vector2(targetVelocity.x, 0);
        if (targetPosition.x == -halfWidth || targetPosition.x == halfWidth)
            target.GetComponent<Rigidbody2D>().velocity = new Vector2(0, targetVelocity.y);

        target.transform.position = targetPosition;
    }
}
