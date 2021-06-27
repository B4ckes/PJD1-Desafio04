using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerTool : BaseTool
{

    protected override void Awake()
    {
        base.Awake();
        this.name = "Scanner";
        this.type = ToolType.ScannerTool;
    }

    public override void action() {
        RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, this.direction);

        if (hit.collider != null && hit.collider.tag == "BlueprintFragment") {
            if (hit.distance <= this.AIM_DISTANCE) {
                BlueprintFragmentController blueprint = hit.collider.gameObject.GetComponent<BlueprintFragmentController>();
                this.coroutine = this.researchFragmentEvent(blueprint);
                StartCoroutine(this.coroutine);
            }
        }
    }

    IEnumerator researchFragmentEvent(BlueprintFragmentController blueprint) {
        while(true) {
            blueprint.researchFragment();
            yield return new WaitForSeconds(0.5f);
        }
    }
}
