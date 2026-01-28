using UnityEngine;

[CreateAssetMenu(fileName = "FoodData", menuName = "Scriptable Objects/FoodData")]
public class FoodData : ScriptableObject
{
    [SerializeField] private bool foodType;
    [SerializeField] public int scoreValue;
    [SerializeField] public Color glowColor;
    [SerializeField] public Sprite spriteVisual;
    [SerializeField] public Vector3 spriteScale;
}
