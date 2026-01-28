using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private FoodData data;
    private FoodVisual foodVisualScript;

    public FoodData foodData => data;

    private void Awake()
    {
        foodVisualScript = GetComponent<FoodVisual>();
    }

    public void SetData(FoodData newFoodData)
    {
        data = newFoodData;
        foodVisualScript.ApplyFoodData(data);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadZone"))
        {
            Destroy(this.gameObject);
        }
    }
}
