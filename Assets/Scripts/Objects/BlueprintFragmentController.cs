using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueprintFragmentController : MonoBehaviour
{
    public Text progressText;

    const int RESEARCHED_AMOUNT_MAX = 100;
    int researchedAmount = 0;
    bool hasCompletedResearch = false;

    private void Update()
    {
        progressText.text = "Research progress: " + researchedAmount + "%";

        if (hasCompletedResearch) {
            SpriteRenderer renderer = this.gameObject.GetComponent<SpriteRenderer>();
            renderer.color = Color.green;
        }
    }

    public void researchFragment() {
        if (!hasCompletedResearch) {
            this.researchedAmount += 5;

        if (this.researchedAmount >= RESEARCHED_AMOUNT_MAX) {
            this.researchedAmount = RESEARCHED_AMOUNT_MAX;
            this.hasCompletedResearch = true;
        }
        }
    }
}
