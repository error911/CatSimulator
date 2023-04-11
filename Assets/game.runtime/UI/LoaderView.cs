using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LoaderView : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text text;

    public void SetProgress(float progress)
    {
        slider.value = progress;
    }


#if UNITY_EDITOR

    private void OnValidate()
    {
        if (slider != null) return;
        slider = GetComponent<Slider>();
    }

#endif
}

