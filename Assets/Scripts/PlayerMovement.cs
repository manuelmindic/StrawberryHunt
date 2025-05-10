using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveTime = 0.2f;
    public Sprite blueSpriteUp;
    public Sprite blueSpriteDown;
    public Sprite blueSpriteLeft;
    public Sprite blueSpriteRight;

    public Sprite yellowSpriteUp;
    public Sprite yellowSpriteDown;
    public Sprite yellowSpriteLeft;
    public Sprite yellowSpriteRight;

    public Sprite pinkSpriteUp;
    public Sprite pinkSpriteDown;
    public Sprite pinkSpriteLeft;
    public Sprite pinkSpriteRight;

    private Sprite spriteUp;
    private Sprite spriteDown;
    private Sprite spriteLeft;
    private Sprite spriteRight;

    private bool isMoving = false;
    private Vector2 input;
    private Vector3 targetPosition;
    private GameManager gameManager = GameManager.Instance;
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
        if ( gameManager.selectedCharacterIndex == "blue" )
        {
            spriteRenderer.sprite = blueSpriteDown;
            spriteUp = blueSpriteUp;
            spriteLeft = blueSpriteLeft;
            spriteDown = blueSpriteDown;
            spriteRight = blueSpriteRight;
        }
        if (gameManager.selectedCharacterIndex == "pink")
        {
            spriteRenderer.sprite = pinkSpriteDown;
            spriteUp = pinkSpriteUp;
            spriteLeft = pinkSpriteLeft;
            spriteDown = pinkSpriteDown;
            spriteRight = pinkSpriteRight;
        }
        if (gameManager.selectedCharacterIndex == "yellow")
        {
            spriteRenderer.sprite = yellowSpriteDown;
            spriteUp = yellowSpriteUp;
            spriteLeft = yellowSpriteLeft;
            spriteDown = yellowSpriteDown;
            spriteRight = yellowSpriteRight;
        }
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
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryRemoveBush();
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