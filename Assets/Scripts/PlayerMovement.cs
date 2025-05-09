using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveTime = 0.2f; // Time to move to next grid space
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    private bool isMoving = false;
    private Vector2 input;
    private Vector3 targetPosition;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;



    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        targetPosition = transform.position;
        rb.gravityScale = 0; // Disable gravity
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (!isMoving)
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            // Only allow cardinal movement
            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                SetDirectionSprite(input);
                Vector3 destination = transform.position + new Vector3(input.x, input.y, 0);
                StartCoroutine(MoveTo(destination));
            }
        }
    }

    private void SetDirectionSprite(Vector2 direction)
    {
        if (direction == Vector2.up)
            spriteRenderer.sprite = spriteUp;
        else if (direction == Vector2.down)
            spriteRenderer.sprite = spriteDown;
        else if (direction == Vector2.left)
            spriteRenderer.sprite = spriteLeft;
        else if (direction == Vector2.right)
            spriteRenderer.sprite = spriteRight;
    }

    private System.Collections.IEnumerator MoveTo(Vector3 destination)
    {
        isMoving = true;
        float elapsedTime = 0;

        Vector3 startingPos = transform.position;

        while (elapsedTime < moveTime)
        {
            Vector3 newPos = Vector3.Lerp(startingPos, destination, elapsedTime / moveTime);
            rb.MovePosition(newPos); // Use Rigidbody2D for movement
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        rb.MovePosition(destination);

        transform.position = destination;
        isMoving = false;
    }
}
