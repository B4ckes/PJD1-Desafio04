using UnityEngine;
using UnityEngine.EventSystems;

public class UseButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private GameController gameController;

    void Awake()
    {
        this.gameController = GameController.FindObjectOfType<GameController>();
    }

    public void OnPointerDown(PointerEventData eventData) {
        this.gameController.doToolAction();
    }

    public void OnPointerUp(PointerEventData eventData) {
        this.gameController.stopToolAction();
    }
}
