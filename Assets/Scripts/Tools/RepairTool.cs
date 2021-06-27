using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairTool : BaseTool
{
    private const int FIX_AMOUNT = 25;

    protected override void Awake()
    {
        base.Awake();
        this.name = "RepairTool";
        this.type = ToolType.RepairTool;
    }

    public override void action() {
        RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, this.direction);

        if (hit.collider != null && hit.collider.tag == "Seamoth") {
            if (hit.distance <= this.AIM_DISTANCE) {
                SeamothController blueprint = hit.collider.gameObject.GetComponent<SeamothController>();
                this.coroutine = this.fixSeamothEvent(blueprint);
                StartCoroutine(this.coroutine);
            }
        }
    }

    private IEnumerator fixSeamothEvent(SeamothController seamoth) {
        while (true) {
            seamoth.fixSeamoth(FIX_AMOUNT);
            yield return new WaitForSeconds(1);
        }
    }
}
