using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Efeitos da água
public class UnderWaterFX : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        RenderSettings.fogColor = new Color(0.302f, 0.247f, 0.255f);
        RenderSettings.fogStartDistance = 0f;
        RenderSettings.fogEndDistance = 150f;

    }

    private void OnTriggerExit(Collider other)
    {
        RenderSettings.fogColor = new Color(0f, 0.733f, 1f);
        RenderSettings.fogStartDistance = 50f;
        RenderSettings.fogEndDistance = 8100f;
    }
}
