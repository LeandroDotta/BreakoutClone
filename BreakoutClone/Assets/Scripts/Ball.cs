using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed;
    
    private Vector2 direction;
    private Vector2 startPosition;
    private Rigidbody2D rb2d;

    public bool IsLocked 
    { 
        get
        {
            return rb2d.velocity == Vector2.zero;
        }
        set
        {
            if(value)
                rb2d.velocity = Vector2.zero;
            else
                rb2d.velocity = direction * speed;
        } 
    }

    void Start () {
        startPosition = transform.position;
        rb2d = GetComponent<Rigidbody2D>();

        ResetPosition();
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

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction.normalized;
        rb2d.velocity = this.direction * speed;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
        rb2d.velocity = rb2d.velocity.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D coll = collision.collider;
        AudioManager.Instance.Play(AudioManager.Instance.sfxBounce);

        if (coll.CompareTag("Player"))
        {
            Platform platform = coll.gameObject.GetComponent<Platform>();
            SetDirection(platform.GetDirection(collision.contacts[0].point));

            if(platform.IsSticky)
            {
                IsLocked = true;
                transform.SetParent(platform.transform);
            }
        }
    }
}
