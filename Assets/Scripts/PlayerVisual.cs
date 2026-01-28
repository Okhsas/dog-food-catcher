using System.Collections;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private SpriteRenderer playerVisual;
    [SerializeField] private Sprite normal;
    [SerializeField] private Sprite eating;

    private void Awake()
    {
        playerVisual = GetComponent<SpriteRenderer>();
    }

    public void PlayEatAnimation()
    {
        StopAllCoroutines();
        StartCoroutine(EatAnimation());
    }

    private IEnumerator EatAnimation()
    {
        playerVisual.sprite = eating;
        yield return new WaitForSeconds(0.5f);
        playerVisual.sprite = normal;
    }    
}
