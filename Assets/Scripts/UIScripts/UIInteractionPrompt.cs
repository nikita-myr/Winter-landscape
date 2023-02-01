using UnityEngine;
using TMPro;

public class UIInteractionPrompt : MonoBehaviour
{
    private UnityEngine.Camera _Camera;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private TextMeshProUGUI _promptText;

    private void Start()
    {
        _Camera = UnityEngine.Camera.main;
        _uiPanel.SetActive(true);
    }

    private void LateUpdate()
    {
        var rotation = _Camera.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
        
    }
    
    public bool isDisplayed = false;
    
    public void SetUpText(string promptText)
    {
        _promptText.text = promptText;
        _uiPanel.SetActive(true);
        isDisplayed = true;
    }

    public void ClosePanel()
    {
        _uiPanel.SetActive(false);
        isDisplayed = false;
    }

    
    
    
}
