using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Vector2 startPosition;

    public BallMovement Movement { get; private set; }

    void Start () {
        startPosition = transform.position;
        Movement = GetComponent<BallMovement>();

        ResetPosition();
	}

    public void Launch()
    {
        transform.SetParent(null);

        Movement.enabled = true;
    }

    public void Launch(Vector2 direction)
    {
        Movement.SetDirection(direction);

        this.Launch();
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
        transform.SetParent(StageManager.Instance.platform.transform);

        Movement.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("OnCollisionEnter2D - Ball");
        Collider2D coll = collision.collider;

        if (coll.CompareTag("Player"))
        {
            Platform platform = coll.gameObject.GetComponent<Platform>();
            Movement.SetDirection(platform.GetDirection(collision.contacts[0].point));

            if(platform.IsSticky)
            {
                Movement.enabled = false;
                transform.SetParent(platform.transform);
            }
        }
    }   
}
