using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public Text progressText;

    const int MAX_CUT_AMOUNT = 100;

    int cutAmount = 15;
    int cutProgress = 0;
    bool hasFinishedCut = false;

    void Update() {
        progressText.text = "Cut progress: " + cutProgress + "%";

        if (this.hasFinishedCut) {
            SpriteRenderer renderer = this.gameObject.GetComponent<SpriteRenderer>();
            renderer.color = Color.green;
        }
    }

    public void cut() {
        if (!this.hasFinishedCut) {
            this.cutProgress += this.cutAmount;

            if (this.cutProgress >= MAX_CUT_AMOUNT) {
                this.cutProgress = MAX_CUT_AMOUNT;
                this.hasFinishedCut = true;
            }
        }
    }
}
