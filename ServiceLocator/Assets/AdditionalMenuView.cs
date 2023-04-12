using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AdditionalMenuView : MonoBehaviour
{
    [SerializeField] private Button closeBtn;
    [SerializeField] private Image additionalPanel;
    [SerializeField] private float duration;

    public Image GetAdditionalPanel() => additionalPanel;
    public float GetDuration() => duration;

    public void AddListener(UnityAction action) =>
        closeBtn.onClick.AddListener(action);

    public void RemoveListener(UnityAction action) =>
        closeBtn.onClick.RemoveListener(action);
}