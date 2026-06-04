using UnityEngine;
using FMODUnity;

public class MusicDistanceController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform enemyTransform;
    [SerializeField] private string globalParameterName = "EnemyDistance";

    void Update()
    {
        if (playerTransform == null || enemyTransform == null) return;

        // Calculate the distance
        float distance = Vector3.Distance(playerTransform.position, enemyTransform.position);

        // Set the global parameter across all of FMOD
        RuntimeManager.StudioSystem.setParameterByName(globalParameterName, distance);
    }
}