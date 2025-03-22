using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotHighlight : MonoBehaviour
{
    private ItemSlotInteraction slot;

    private Image image;

    [SerializeField] private Color normalColor;
    [SerializeField] private Color highlightColor;
    [SerializeField] private float fadeInTime;
    [SerializeField] private float fadeOutTime;

    void Awake()
    {
        slot = GetComponent<ItemSlotInteraction>();
        image = GetComponent<Image>();
        slot.OnEnter.AddListener(FadeIn);
        slot.OnExit.AddListener(FadeOut);
    }

    public void FadeIn()
    {
        StartCoroutine(FadeCoroutine(highlightColor, fadeInTime));
    }

    private void FadeOut()
    {
        StartCoroutine(FadeCoroutine(normalColor, fadeOutTime));
    }

    private IEnumerator FadeCoroutine(Color colorTo, float fadeTime)
    {
        Color colorFrom = image.color;

        float time = 0;

        while (time < fadeInTime)
        {
            image.color = Color.Lerp(colorFrom, colorTo, time / fadeTime);
            time += Time.unscaledDeltaTime;
            yield return null;
        }
    }
}