using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public bool isInteracting { get; private set; }
    
    private UnityEngine.Camera _camera;
    private Ray ray;
    private  RaycastHit[] _rayHits = new RaycastHit[3];
    private float _maxRayDistance = 15.0f;
    public LayerMask InteractionLayer;
    [SerializeField] private UIInteractionPrompt _uiInteractionPrompt;
    private int _numFound;
    
    private IInteractable _interactable;

    
    private void Start()
    {
        _camera = UnityEngine.Camera.main;
    }

    private void Update()
    {
        ray = new Ray(_camera.transform.position, _camera.transform.forward);
        //Physics.Raycast(ray, out _rayHit, _maxRayDistance, InteractionLayer);
        _numFound = Physics.RaycastNonAlloc(ray, _rayHits, _maxRayDistance, InteractionLayer);
        Debug.DrawRay(ray.origin, ray.direction * _maxRayDistance);
        Debug.Log(_numFound);
        if (_numFound > 0)
        {
            Debug.Log(_rayHits[0]);
            _interactable = _rayHits[0].collider.GetComponent<IInteractable>();

            if (_interactable != null)
            {
                if (!_uiInteractionPrompt.isDisplayed) _uiInteractionPrompt.SetUpText(_interactable.InteractionPrompt);

                if (Keyboard.current.fKey.wasPressedThisFrame) StartInteraction(_interactable);
            }
        }
        else
        {
            if (_interactable != null) _interactable = null;
            if (_uiInteractionPrompt.isDisplayed) _uiInteractionPrompt.ClosePanel();
        }
    }
    
    void StartInteraction(IInteractable interactable)
    {
        interactable.Interact(this, out bool interactSuccesfull);
        isInteracting = true;
    }

    void EndInterction()
    {
        isInteracting = false;
    }
}
