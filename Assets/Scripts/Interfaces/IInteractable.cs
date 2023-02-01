using UnityEngine.Events;

public interface IInteractable 
{
    public string InteractionPrompt { get; }
    public UnityAction<IInteractable> OnIterationComplite { get; set; }

    public void Interact(Interactor interactor, out bool interactSuccesfull);
    public void EndInteraction();

}
