using UnityEngine;
using UnityEngine.EventSystems;

public class UseButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isPointerDown = false;

    public GameController gameController;

    bool isCurrentToolFlashlight() {
        return this.gameController.currentTool == ToolType.Flashlight;
    }

    void Update()
    {
        if (this.isPointerDown && !isCurrentToolFlashlight()) {
            this.gameController.doToolAction();
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        if (isCurrentToolFlashlight()) {
            this.gameController.doToolAction();
        }

        this.isPointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        this.isPointerDown = false;
    }
}
