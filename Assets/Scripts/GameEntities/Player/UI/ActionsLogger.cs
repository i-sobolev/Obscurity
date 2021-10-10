using UnityEngine;
using UnityEngine.UI;

namespace Obscurity.UI
{
    public class ActionsLogger : MonoBehaviour
    {
        [SerializeField] private float _hideDelay;
        private Text _attachedTextField;
        private Color _baseColor;
        private Vector2 _basePosition;

        public static ActionsLogger Instance { get; private set; }

        private void Awake()
        {
            Instance = this;

            _attachedTextField = GetComponent<Text>();
            _attachedTextField.text = string.Empty;

            _baseColor = _attachedTextField.color;
            _basePosition = (transform as RectTransform).anchoredPosition;

            Hide();
        }

        public void Log(string message)
        {
            ResetAnimation();

            _attachedTextField.text = message;

            //UIAnimator.SmoothColorChange(_attachedTextField, _attachedTextField.color.Transparent(), _baseColor, 2).Start(this);
            //UIAnimator.SmoothTranslate(_attachedTextField, _attachedTextField.rectTransform.anchoredPosition - Vector2.up * 10, _attachedTextField.rectTransform.anchoredPosition, 2, Hide).Start(this);
        }

        public void Hide()
        {
            ResetAnimation();

            //UIAnimator.DelayAwait(_hideDelay).Start(this);
            //UIAnimator.SmoothColorChange(_attachedTextField, _baseColor, _attachedTextField.color.Transparent(), 2).Start(this);
        }

        private void ResetAnimation()
        {
            StopAllCoroutines();
            (transform as RectTransform).anchoredPosition = _basePosition;
        }
    }
}