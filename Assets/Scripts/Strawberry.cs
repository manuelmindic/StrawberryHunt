using UnityEngine;

public class Strawberry : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameLogic gameLogic = FindObjectOfType<GameLogic>();
            if (gameLogic != null)
            {
                gameLogic.CollectStrawberry();
            }

            Destroy(gameObject); 
        }
    }
}
