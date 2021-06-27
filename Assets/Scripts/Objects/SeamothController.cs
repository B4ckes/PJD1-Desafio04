using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeamothController : MonoBehaviour
{
    public Text integrityText;

    const int MAX_INTEGRITY_LIFE = 100;

    int integrity;
    bool hasFullIntegrity;

    void Awake()
    {
        this.integrity = 35;
        this.hasFullIntegrity = false;
    }

    private void Update()
    {
        integrityText.text = "Integrity: " + integrity + "%";

        if (this.hasFullIntegrity) {
            SpriteRenderer renderer = this.gameObject.GetComponent<SpriteRenderer>();
            renderer.color = Color.green;
        }
    }

    public void fixSeamoth(int fixAmount) {
        if (!hasFullIntegrity) {
            this.integrity += fixAmount;

            if (this.integrity >= MAX_INTEGRITY_LIFE) {
                this.integrity = MAX_INTEGRITY_LIFE;
                this.hasFullIntegrity = true;
            }
        }
    }
}
