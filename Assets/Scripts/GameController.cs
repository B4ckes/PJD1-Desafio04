using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameController : MonoBehaviour
{
    public PlayerController player;

    public FlashlightTool flashlight;
    public ScannerTool scanner;
    public RepairTool repairTool;
    public LaserTool laserTool;
    public Text currentToolText;

    public ToolType currentTool { get; private set; }

    void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerController>();

        this.flashlight = FlashlightTool.Instantiate(this.flashlight, player.toolSpawnerPosition);
        this.scanner = ScannerTool.Instantiate(this.scanner, player.toolSpawnerPosition);
        this.repairTool = RepairTool.Instantiate(this.repairTool, player.toolSpawnerPosition);
        this.laserTool = LaserTool.Instantiate(this.laserTool, player.toolSpawnerPosition);
    }

    void Update()
    {
        this.updateTool();
    }

    void updateTool() {
        if (this.currentTool != player.currentTool) {
            this.currentTool = player.currentTool;

            BaseTool[] tools = new BaseTool[4]
            {
                this.flashlight,
                this.scanner,
                this.repairTool,
                this.laserTool
            };

            foreach (BaseTool tool in tools) {
                    if (tool.type == player.currentTool) {
                        tool.gameObject.SetActive(true);
                        this.currentToolText.text = "Tool: " + tool.name;
                    } else {
                        tool.gameObject.SetActive(false);
                    }
                }
        }
    }

    public void doToolAction() {
        if (player.currentTool == flashlight.type) {
            flashlight.action();
        }
        if (player.currentTool == scanner.type) {
            scanner.action();
        }
        if (player.currentTool == repairTool.type) {
            repairTool.action();
        }
        if (player.currentTool == laserTool.type) {
            laserTool.action();
        }
    }
}
