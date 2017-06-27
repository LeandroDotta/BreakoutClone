using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed;
    public Vector2 direction;

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}

    private void FixedUpdate()
    {
        Move();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void Move()
    {
        rb2d.MovePosition(rb2d.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;
        print(collision.contacts.Length);
        direction = Vector2.Reflect(direction, normal).normalized;
    }
}
