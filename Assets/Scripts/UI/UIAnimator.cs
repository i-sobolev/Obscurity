using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimator
{
    public static IEnumerator SmoothTranslate(Graphic element, Vector2 start, Vector2 target, float time = 1, Action actionAfterEnd = null)
    {
        var lerpValue = 0f;

        while(lerpValue < 1)
        {
            element.rectTransform.anchoredPosition = Vector2.Lerp(start, target, lerpValue.EaseOutQuint());
            lerpValue += Time.deltaTime / time;
            yield return null;
        }

        if (actionAfterEnd != null)
            actionAfterEnd.Invoke();

        yield return null;
    }

    public static IEnumerator SmoothColorChange(Graphic element, Color start, Color target, float time = 1, Action actionAfterEnd = null)
    {
        var lerpValue = 0f;

        while (lerpValue < 1)
        {
            element.color = Color.Lerp(start, target, lerpValue.EaseOutQuint());
            lerpValue += Time.deltaTime / time;
            yield return null;
        }

        if (actionAfterEnd != null)
            actionAfterEnd.Invoke();

        yield return null;
    }

    public static IEnumerator DelayAwait(float delayValue, Action actionAfterEnd = null)
    {
        yield return new WaitForSeconds(delayValue);
    }
}
