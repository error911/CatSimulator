using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ActionButton : MonoBehaviour
{
    [SerializeField] private TMP_Text btnText;
    [SerializeField] private Button btn;
    
    public void Construct(string caption, Action onClick)
    {
        btnText.text = caption;
        btn.onClick.AddListener(()=> onClick());
    }

#if UNITY_EDITOR    // Для домашки добавил, но не обязательно, этот метод не компилируется в билд
    private void OnValidate()
    {
        if (btn != null) return;
        btn = FindObjectOfType<Button>();
    }
#endif

}
