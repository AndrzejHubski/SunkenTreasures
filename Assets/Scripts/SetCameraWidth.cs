using UnityEngine;

public class SetCameraWidth : MonoBehaviour
{
    public float cameraWidthInUnits = 8f; 

    void Start()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            float screenHeightInUnits = 2f * mainCamera.orthographicSize;

            float screenWidthInUnits = screenHeightInUnits * mainCamera.aspect;

            mainCamera.orthographicSize = cameraWidthInUnits * 0.5f / mainCamera.aspect;
        }
    }
}
