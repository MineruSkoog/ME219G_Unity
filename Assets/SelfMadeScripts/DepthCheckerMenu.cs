using UnityEngine;
using FMODUnity;

public class MenuParameterDynamics : MonoBehaviour
{
    [Header("FMOD Settings")]
    [Tooltip("The exact name of your Global Parameter in FMOD Studio.")]
    public string globalParameterName = "MenuDepth";

    [Header("Menu Structure")]
    [Tooltip("The maximum number of menu layers a player can click into.")]
    public int maxMenuLayers = 4;

    private int currentLayer = 0;

    void Start()
    {
        UpdateFMODParameter();
    }

    // Call this on buttons that open a new submenu
    public void GoDeeper()
    {
        if (currentLayer < maxMenuLayers)
        {
            currentLayer++;
            UpdateFMODParameter();
        }
    }

    // Call this on 'Back' buttons
    public void GoBack()
    {
        if (currentLayer > 0)
        {
            currentLayer--;
            UpdateFMODParameter();
        }
    }

    private void UpdateFMODParameter()
    {
        // Convert the current layer into a fraction between 0.0 and 1.0
        float normalizedValue = (float)currentLayer / maxMenuLayers;

        // Send to FMOD
        RuntimeManager.StudioSystem.setParameterByName(globalParameterName, normalizedValue);

        Debug.Log($"Layer: {currentLayer}/{maxMenuLayers} | FMOD Parameter Value: {normalizedValue}");
    }
}