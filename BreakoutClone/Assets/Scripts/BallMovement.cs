using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
	public float speed;

	[SerializeField]
	private Vector2 direction = new Vector2(1, 1);
	private Rigidbody2D rb2d;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		SetMovement(true);
	}

	void OnEnable()
	{
		SetMovement(true);
	}

	void OnDisable()
	{
		SetMovement(false);
	}

	public void SetDirection(Vector2 direction)
    {
        this.direction = direction.normalized;
        SetMovement(true);
    }

	public void SetSpeed(float speed)
    {
        this.speed = speed;
        SetMovement(true);
    }

	private void SetMovement(bool isMoving)
	{
		if(rb2d != null)
		{
			if(isMoving)
				rb2d.velocity = direction * speed;
			else
				rb2d.velocity = Vector2.zero;
		}
	}
}
