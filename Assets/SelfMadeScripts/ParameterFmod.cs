using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class FMODParameterController : MonoBehaviour
{
    public EventReference EventReference;
   public string fmodEvent;
    public string parameterName;
    
    private EventInstance instance;

    void Start()
    {
        // Create the audio instance
        instance = RuntimeManager.CreateInstance(fmodEvent);
        instance.start();
    }

    // Call this function via your Unity Button Component
    public void SetParameterValue(float value)
    {
        instance.setParameterByName(parameterName, value);
    }

    void OnDestroy()
    {
        // Clean up the instance when the object is destroyed
        instance.release();
        instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}