using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {    

    public float minSize;
    public float maxSize;

    private static Vector2[] directions = new Vector2[]
    {
        new Vector2(-1, 0.5f).normalized,
        new Vector2(-1, 1).normalized,
        new Vector2(-0.5f, 1).normalized,
        new Vector2(-0.15f, 1).normalized,

        new Vector2(0.15f, 1).normalized,
        new Vector2(0.5f, 1).normalized,
        new Vector2(1, 1).normalized,
        new Vector2(1, 0.5f).normalized
    };

    private Vector2 startPosition;
    private Collider2D coll;
    private SpriteRenderer spriteRenderer;
    private PlatformController controller;

    public static Vector2[] Directions { get { return directions; } }

    void Start()
    {
        startPosition = transform.position;
        coll = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlatformController>();
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
    }

    public Vector2 GetDirection(Vector2 contactPoint)
    {
        Bounds collBounds = coll.bounds;
        float sectionSize = collBounds.size.x / directions.Length;

        // Divide a plataforma em sessões, baseado na quantidade de direções que ela possui
        for(int i = 1; i <= directions.Length; i++)
        {
            // Ponto que define o finda da sessão
            float section = collBounds.min.x + (sectionSize * i);

            // Se o ponto de contato está dentro da sessão retorna sua respectiva direção
            if (contactPoint.x < section)
                return directions[i - 1];
        }

        // Caso o eixo X do ponto de contato seja maior até mesmo que a últma sessão, 
        // siginifica que ele tocou na lateral direita da plataforma, retornando a sua respectiva direção
        return directions[directions.Length - 1];
    }

    public void GrowUp()
    {
        StartCoroutine("ResizeCoroutine", Mathf.Clamp(spriteRenderer.size.x + 1, minSize, maxSize));
    }

    public void Lower()
    {
        StartCoroutine("ResizeCoroutine", Mathf.Clamp(spriteRenderer.size.x - 1, minSize, maxSize));
    }

    private IEnumerator ResizeCoroutine(float resizeTo)
    {
        float duration = 0.3f;
        float timer = 0;
        
        float startSize = spriteRenderer.size.x;

        while(spriteRenderer.size.x != resizeTo)
        {
            Vector2 newSize = new Vector2(Mathf.Lerp(startSize, resizeTo, timer), spriteRenderer.size.y);
            spriteRenderer.size = newSize;

            yield return new WaitForEndOfFrame();

            timer += Time.deltaTime / duration;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Bounds collBounds = GetComponent<Collider2D>().bounds;
        float sectionSize = collBounds.size.x / directions.Length;

        for (int i = 1; i <= directions.Length; i++)
        {
            Vector2 center = new Vector2(collBounds.min.x + (sectionSize * i) - (sectionSize /2), collBounds.center.y);

            // Desenha as sessões em que a plataforma foi dividida
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(center, new Vector2(sectionSize, collBounds.size.y));

            // Desenha a linha que representa a direção para a sessão
            Gizmos.color = Color.green;
            Gizmos.DrawLine(center, center + (directions[i - 1] * 5));   
        }
    }
}
