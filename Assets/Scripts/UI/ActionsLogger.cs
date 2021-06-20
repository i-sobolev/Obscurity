using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionsLogger : MonoBehaviour
{
    [SerializeField] private float _hideDelay;
    private Text _attachedTextField;
    private Color _baseColor;

    public static ActionsLogger Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        
        _attachedTextField = GetComponent<Text>();
        _attachedTextField.text = string.Empty;
        
        _baseColor = _attachedTextField.color;

        Hide();
    }

    public void Log(string message)
    {
        _attachedTextField.text = message;
        StopAllCoroutines();
        
        UIAnimator.SmoothColorChange(_attachedTextField, _attachedTextField.color.Transparent(), _baseColor, 2).Start(this);
        UIAnimator.SmoothTranslate(_attachedTextField, _attachedTextField.rectTransform.anchoredPosition - Vector2.up * 10, _attachedTextField.rectTransform.anchoredPosition, 2, Hide).Start(this);
    }

    public void Hide()
    {
        StopAllCoroutines();

        UIAnimator.DelayAwait(_hideDelay).Start(this);
        UIAnimator.SmoothColorChange(_attachedTextField, _baseColor, _attachedTextField.color.Transparent(), 2).Start(this);
    }
}
