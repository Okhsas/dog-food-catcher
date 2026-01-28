using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TutorialHover : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler
{
    [SerializeField] private GameObject tutorialImage;
    [SerializeField] private Image tutorialButtonVisual;

    private void Awake()
    {
        if (tutorialButtonVisual == null)
            tutorialButtonVisual = GetComponentInChildren<Image>();

        tutorialImage.SetActive(false);
        tutorialButtonVisual.color = Color.white;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tutorialImage.SetActive(true);

        tutorialButtonVisual.color = new Color(1, 1, 1, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tutorialImage.SetActive(false);
        tutorialButtonVisual.color = Color.white;
    }
}
