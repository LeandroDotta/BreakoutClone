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

        minX = leftWall.bounds.max.x;
        maxX = rightWall.bounds.min.x;
    }

    private void Update()
    {
        // Movimento ao tocar na tela (para smartphones e tablets)
        if(Input.touchCount == 1){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(Mathf.Abs(mousePos.x - transform.position.x) > 0.3f){
                Vector2 direction = new Vector2(mousePos.x - transform.position.x, 0).normalized;
                Move(direction);
            }
        }
        
        // Movimento pelo teclado ou mouse
        float axisHorizontal = Input.GetAxisRaw("Horizontal");

        if(axisHorizontal == 0) 
            axisHorizontal = Input.GetAxisRaw("Mouse X");
        
        if (axisHorizontal != 0)
        {
            Vector2 direction = new Vector2(axisHorizontal, 0);   
            Move(direction);
        }

        // Lançar a bola
        if((Input.GetButtonDown("Action") || Input.GetMouseButtonUp(0)) && !StageManager.Instance.ball.Movement.enabled)
        {
            if(StageManager.Instance.IsFirstLaunch)
            {
                // Primeiro lançamento é realizado em uma direção aleatória
                StageManager.Instance.ball.Launch(Platform.Directions[Random.Range(0, Platform.Directions.Length)]);
                StageManager.Instance.IsFirstLaunch = false;
            }
            else
            {
                StageManager.Instance.ball.Launch();
            }
        }
            
    }

    private void Move(Vector2 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minX + coll.bounds.extents.x, maxX - coll.bounds.extents.x), transform.position.y);
    }
}
