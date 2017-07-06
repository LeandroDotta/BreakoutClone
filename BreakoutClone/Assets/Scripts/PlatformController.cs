using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    public float speed;
    public Collider2D leftWall;
    public Collider2D rightWall;

    private float minX;
    private float maxX;
    private Collider2D coll;

    private void Start()
    {
        coll = GetComponent<Collider2D>();

        minX = leftWall.bounds.max.x + coll.bounds.extents.x;
        maxX = rightWall.bounds.min.x - coll.bounds.extents.x;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float axisHorizontal = Input.GetAxisRaw("Horizontal");
        if (axisHorizontal != 0)
        {
            Vector2 direction = new Vector2(axisHorizontal, 0);

            transform.Translate(direction * speed * Time.deltaTime);
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y);
        }
    }
}
