using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveTime = 0.2f;
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    private bool isMoving = false;
    private Vector2 input;
    private Vector3 targetPosition;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Vector2 lastDirection = Vector2.down;



    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
        rb.gravityScale = 0;
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (!isMoving)
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                SetDirectionSprite(input);
                Vector3 destination = transform.position + new Vector3(input.x, input.y, 0);
                StartCoroutine(MoveTo(destination));
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                TryRemoveBush();
            }
        }
    }

    private void SetDirectionSprite(Vector2 direction)
    {
        lastDirection = direction;
        if (direction == Vector2.up)
            spriteRenderer.sprite = spriteUp;
        else if (direction == Vector2.down)
            spriteRenderer.sprite = spriteDown;
        else if (direction == Vector2.left)
            spriteRenderer.sprite = spriteLeft;
        else if (direction == Vector2.right)
            spriteRenderer.sprite = spriteRight;
    }

    private void TryRemoveBush()
    {
        Debug.Log("Hello");
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Bush");
        Vector2 checkPos = (Vector2)transform.position + lastDirection;
        Collider2D hit = Physics2D.OverlapPoint(checkPos, 1);

        if (hit != null && hit.CompareTag("Bush"))
        {
            Debug.Log("Bush in front!");
            Destroy(hit.gameObject);
        }



    }

    private System.Collections.IEnumerator MoveTo(Vector3 destination)
    {
        isMoving = true;
        float elapsedTime = 0;

        Vector3 startingPos = transform.position;

        while (elapsedTime < moveTime)
        {
            Vector3 newPos = Vector3.Lerp(startingPos, destination, elapsedTime / moveTime);
            rb.MovePosition(newPos); 
            elapsedTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        rb.MovePosition(destination);
        isMoving = false;
    }
}