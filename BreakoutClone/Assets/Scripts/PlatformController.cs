using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        
    }

    private void Move()
    {
        float axisHorizontal = Input.GetAxisRaw("Horizontal");
        if (axisHorizontal != 0)
        {
            Vector2 direction = new Vector2(axisHorizontal, 0);
            rb2d.MovePosition(rb2d.position + direction * speed * Time.fixedDeltaTime);
        }
    }
}
