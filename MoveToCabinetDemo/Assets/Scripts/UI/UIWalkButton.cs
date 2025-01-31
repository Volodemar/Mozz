using UnityEngine;
using UnityEngine.EventSystems;

public class UIWalkButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isWalking = false;

    void Update()
    {
        if (isWalking)
        {
            PlayerController.Instance.StepMove();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isWalking = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isWalking = false;
    }
}