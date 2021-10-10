using DG.Tweening;
using UnityEngine;

namespace Obscurity
{
    public abstract class HumanoidMovement : MonoBehaviour
    {
        public float Speed { get; private set; } = 0.8f;

        protected Tween _speedChangingTween;

        protected void SpeedDown()
        {
            _speedChangingTween.Kill();

            float lerp = 0;
            float currentSpeed = Speed;

            _speedChangingTween = DOTween.Sequence()
                .AppendCallback(() =>
                {
                    if (lerp > 1)
                        _speedChangingTween.Kill();

                    Speed = Mathf.Lerp(currentSpeed, 0.8f, lerp);
                    lerp += Time.deltaTime / 0.5f;
                })
                .SetEase(Ease.InSine).SetLoops(-1);
        }

        protected void SpeedUp()
        {
            _speedChangingTween.Kill();

            float lerp = 0;
            float currentSpeed = Speed;

            _speedChangingTween = DOTween.Sequence()
                .AppendCallback(() =>
                {
                    if (lerp > 1)
                        _speedChangingTween.Kill();

                    Speed = Mathf.Lerp(currentSpeed, 1.2f, lerp);
                    lerp += Time.deltaTime / 0.5f;
                })
                .SetEase(Ease.InSine).SetLoops(-1);
        }

    }
}
