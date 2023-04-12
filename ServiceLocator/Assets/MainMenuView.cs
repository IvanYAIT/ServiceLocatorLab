using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button openBtn;
    [SerializeField] private Image additionalPanel;
    [SerializeField] private float duration;

    public Image GetAdditionalPanel() => additionalPanel;
    public float GetDuration() => duration;

    public void AddListener(UnityAction action) =>
        openBtn.onClick.AddListener(action);

    public void RemoveListener(UnityAction action)=>
        openBtn.onClick.RemoveListener(action);
}