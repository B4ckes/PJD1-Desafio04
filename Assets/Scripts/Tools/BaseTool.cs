using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToolType {
    None,
    ScannerTool,
    Flashlight,
    RepairTool,
    LaserTool
}

[System.Serializable]
public class BaseTool : MonoBehaviour {
    public ToolType type { get; protected set; }
    public Vector2 position { get; set; }

    protected float AIM_DISTANCE = 1f;
    protected Vector2 direction = new Vector2(1f, 0);
    protected IEnumerator coroutine;

    protected virtual void Awake() {
        this.name = "Base tool";
        this.type = ToolType.None;
    }

    void Update() {
        this.stopCoroutine();
    }

    public virtual void action() {
        Debug.Log("Base tool has no action.");
    }

    void stopCoroutine() {
        if (Input.GetMouseButtonUp(1) && this.coroutine != null) {
            StopCoroutine(this.coroutine);
        }
    }
}
