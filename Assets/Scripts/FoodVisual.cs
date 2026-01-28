using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FoodVisual : MonoBehaviour
{
    private SpriteRenderer foodVisual;
    private Light2D foodGlow;

    private void Awake()
    {
        if(foodVisual == null)
        {
            foodVisual = GetComponentInChildren<SpriteRenderer>();
            foodGlow = GetComponentInChildren<Light2D>();
        }
    }
     public void ApplyFoodData(FoodData foodData)
    {
        foodVisual.sprite = foodData.spriteVisual;
        foodVisual.transform.localScale = foodData.spriteScale;

        Color c = foodData.glowColor;
        c.a = 1f;
        foodGlow.color = c;

    }
}
