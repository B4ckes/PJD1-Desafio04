using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightTool : BaseTool
{
    public bool isFlashLightOn = false;

    public GameObject lightObject;

    protected override void Awake()
    {
        base.Awake();
        this.name = "Flashlight";
        this.type = ToolType.Flashlight;
        this.lightObject.SetActive(this.isFlashLightOn);
    }

    public override void action() {
        this.isFlashLightOn = !this.isFlashLightOn;
        this.lightObject.SetActive(this.isFlashLightOn);
    }
}
