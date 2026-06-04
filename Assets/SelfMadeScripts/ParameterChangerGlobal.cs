using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class PartialFMODParameterController : MonoBehaviour
{
    //  event instance path is not needed for a Global Parameter!
    public string globalParameterName = "Volume"; 

    // Call this function via your Unity Component
    public void SetGlobalParameterValue(float value)
    {
        //  Targets the global system
        RuntimeManager.StudioSystem.setParameterByName(globalParameterName, value);
    }
}