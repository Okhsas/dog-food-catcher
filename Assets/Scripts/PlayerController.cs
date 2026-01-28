using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerVisual playerVisual;

    private void Awake()
    {
        playerVisual = GetComponentInChildren<PlayerVisual>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Food food = collision.GetComponent<Food>();

        if(food != null)
        {
            playerVisual.PlayEatAnimation();
            GameEvent.FoodEaten?.Invoke(food.foodData);
            Destroy(collision.gameObject);
        }
    }
}
