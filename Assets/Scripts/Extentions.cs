using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extentions
{
    public static float EaseInOutQuad(this float x) => x < 0.5 ? 2 * x * x : 1 - (-2 * x + 2) * (-2 * x + 2) / 2;
    public static float EaseOutQuint(this float x) => 1f - Mathf.Pow(1 - x, 5);
    public static float EaseInQuint(this float x) => Mathf.Pow(x, 4);

    public static Coroutine Start(this IEnumerator x, MonoBehaviour sender) => sender.StartCoroutine(x);
    
    public static Color Transparent(this Color x) => new Color (x.r, x.g, x.b, 0);
}