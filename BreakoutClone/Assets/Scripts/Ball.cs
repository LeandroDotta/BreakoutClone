using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed;
    public Vector2 direction;

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

    private void Move()
    {
        rb2d.MovePosition(rb2d.position + direction * speed * Time.fixedDeltaTime);
    }

    public void Launch()
    {
        transform.SetParent(null);
        IsLocked = false;
    }

    public void Launch(Vector2 direction)
    {
        this.direction = direction;
        this.Launch();
    }

    public void ResetPosition()
    {
        IsLocked = true;

        transform.position = startPosition;
        transform.SetParent(StageManager.Instance.platform.transform);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D coll = collision.collider;
        AudioManager.Instance.Play(AudioManager.Instance.sfxBounce);

        if (coll.CompareTag("Player"))
        {
            Platform platform = coll.gameObject.GetComponent<Platform>();
            direction = platform.GetDirection(collision.contacts[0].point);

            if(platform.IsSticky)
            {
                IsLocked = true;
                transform.SetParent(platform.transform);
            }
        }
        else
        {
            Vector2 normal = collision.contacts[0].normal;
            direction = Vector2.Reflect(direction, normal).normalized;
        }
    }
}
