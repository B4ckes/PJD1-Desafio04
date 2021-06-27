using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTool : BaseTool
{
    protected override void Awake()
    {
        base.Awake();
        this.name = "LaserCutter";
        this.type = ToolType.LaserTool;
    }

    public override void action() {
        RaycastHit2D hit = Physics2D.Raycast(this.gameObject.transform.position, this.direction);

        if (hit.collider != null && hit.collider.tag == "Door") {
            if (hit.distance <= this.AIM_DISTANCE) {
                DoorController door = hit.collider.gameObject.GetComponent<DoorController>();
                this.coroutine = this.cutDoorEvent(door);
                StartCoroutine(this.coroutine);
            }
        }
    }

    private IEnumerator cutDoorEvent(DoorController door) {
        while (true) {
            door.cut();
            yield return new WaitForSeconds(0.3f);
        }
    }
}
