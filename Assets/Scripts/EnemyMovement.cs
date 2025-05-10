using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float moveTime = 0.2f;
    public List<Vector2> patrolDirections; // Use this if moving in directions
    public List<Transform> patrolPoints;   // Or use this for exact positions
    public bool useWaypoints = false;

    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private int currentIndex = 0;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (patrolDirections.Count == 0 && !useWaypoints)
        {
            // Example patrol route
            patrolDirections.Add(Vector2.right);
            patrolDirections.Add(Vector2.down);
            patrolDirections.Add(Vector2.left);
            patrolDirections.Add(Vector2.up);
        }

        StartCoroutine(MoveRoutine());
    }

    private IEnumerator MoveRoutine()
    {
        while (true)
        {
            if (!isMoving)
            {
                Vector3 destination;
                if (useWaypoints && patrolPoints.Count > 0)
                {

                    destination = patrolPoints[currentIndex].position;
                }
                else
                {
                    Vector2 dir = patrolDirections[currentIndex];
                    SetDirectionSprite(dir);
                    destination = transform.position + new Vector3(dir.x, dir.y, 0);
                }

                yield return StartCoroutine(MoveTo(destination));

                currentIndex = (currentIndex + 1) % (useWaypoints ? patrolPoints.Count : patrolDirections.Count);
            }

            yield return new WaitForSeconds(0.3f); // Delay before next move
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with the enemy!");
            MoveToLosingScreen();
        }
    }

    private void MoveToLosingScreen()
    {
        //gameManager.levelProgress -= 1;
        SceneManager.LoadScene("LosingScreen");
    }
    private IEnumerator MoveTo(Vector3 destination)
    {
        isMoving = true;
        float elapsedTime = 0;
        Vector3 startPos = transform.position;

        while (elapsedTime < moveTime)
        {
            Vector3 newPos = Vector3.Lerp(startPos, destination, elapsedTime / moveTime);
            rb.MovePosition(newPos);
            elapsedTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        rb.MovePosition(destination);
        isMoving = false;
    }
}
