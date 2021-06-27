using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerController : MonoBehaviour {
    const int SPEED = 5;
    ArrayList tools = new ArrayList();

    public ToolType currentTool { get; private set; } = ToolType.Flashlight;
    public Transform toolSpawnerPosition { get; set; }

    void Awake()
    {
        GameObject toolSpawner = GameObject.FindGameObjectWithTag("ToolSpawner");

        this.toolSpawnerPosition = toolSpawner.transform;
    }

    void FixedUpdate()
    {
        this.move();
    }

    void move() {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        transform.position += new Vector3(horizontalMovement * SPEED * Time.deltaTime, verticalMovement * SPEED * Time.deltaTime, 0);

        if (horizontalMovement > 0) {
            transform.eulerAngles = new Vector2(0f, 0f);
        }
        
        if (horizontalMovement < 0) {
            transform.eulerAngles = new Vector2(0f, 180f);
        }
    }

    public void setToolFlashlight() {
        this.currentTool = ToolType.Flashlight;
    }

    public void setToolScannerTool() {
        this.currentTool = ToolType.ScannerTool;
    }

    public void setToolRepairTool() {
        this.currentTool = ToolType.RepairTool;
    }

    public void setToolLaserTool() {
        this.currentTool = ToolType.LaserTool;
    }
}
