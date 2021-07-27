using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Fade : MonoBehaviour
{
    protected int _minAlpha = 0;
    protected int _maxAlpha = 1;

    public event UnityAction FadeEnded;

    protected IEnumerator ChangeAlpha(int targetAlpha, CanvasGroup canvasGroup)
    {
        while (canvasGroup.alpha != targetAlpha)
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, targetAlpha, Time.deltaTime);
            yield return null;
        }
        FadeEnded?.Invoke();
    }

    protected IEnumerator ChangeAlpha(int targetAlpha, TMP_Text text)
    {
        while (text.alpha != targetAlpha)
        {
            text.alpha = Mathf.MoveTowards(text.alpha, targetAlpha, Time.deltaTime);
            yield return null;
        }
    }
}
