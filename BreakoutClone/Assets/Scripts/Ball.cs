using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed;
    public Vector2 direction;
    public Platform platform;

    private Vector2 startPosition;
    private Rigidbody2D rb2d;

    public bool IsLocked { get; set; }

    // Use this for initialization
    void Start () {
        startPosition = transform.position;
        rb2d = GetComponent<Rigidbody2D>();

        ResetPosition();
	}

    private void FixedUpdate()
    {
        if(!IsLocked)
            Move();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Action") && IsLocked)
            Launch();
	}

    private void Move()
    {
        rb2d.MovePosition(rb2d.position + direction * speed * Time.fixedDeltaTime);
    }

    private void Launch()
    {
        // Direção aleatória
        direction = Platform.Directions[Random.Range(0, Platform.Directions.Length)];

        transform.SetParent(null);
        IsLocked = false;
    }

    public void ResetPosition()
    {
        IsLocked = true;

        transform.position = startPosition;
        transform.SetParent(platform.transform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D coll = collision.collider;

        if (coll.CompareTag("Player"))
        {
            Platform platform = coll.gameObject.GetComponent<Platform>();
            direction = platform.GetDirection(collision.contacts[0].point);
        }
        else
        {
            Vector2 normal = collision.contacts[0].normal;
            direction = Vector2.Reflect(direction, normal).normalized;
        }
        
    }
}
