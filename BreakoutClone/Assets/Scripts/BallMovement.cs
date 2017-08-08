using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
	public float speed;

	[SerializeField]
	private Vector2 direction = new Vector2(1, 1);

	[HideInInspector]
	public Rigidbody2D rb2d;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D>();
		SetMovement(true);
	}

	void Update()
	{
		//print(rb2d.velocity.normalized + " - Direction: " + direction.normalized);
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

	void OnCollisionEnter2D(Collision2D collision)
    {
		Vector2 direction = rb2d.velocity.normalized;

		// Angulo mínimo para o movimento vertical
		if(direction.x > -0.1f && direction.x < 0.1f)
		{
			print(direction);
			direction.x = Mathf.Sign(direction.x) == -1 ? -0.1f : 0.1f;
		}

		// Ângulo mínimo para o moviemento horizontal
		if(direction.y > -0.3f && direction.y < 0.3f)
		{
			print(direction);
			direction.x = Mathf.Sign(direction.y) == -1 ? -0.3f : 0.3f;
		}

		SetDirection(direction);
    }
}
