using System.Collections;
using UnityEngine;

namespace Obscurity
{
    public static class Extentions
    {
        public static Coroutine Start(this IEnumerator x, MonoBehaviour sender) => sender.StartCoroutine(x);
        public static Color Transparent(this Color x) => new Color(x.r, x.g, x.b, 0);
    }
}