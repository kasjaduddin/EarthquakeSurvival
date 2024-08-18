using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    void Start()
    {
        SetCanvasPosition();
    }
    void Update()
    {
        
    }
    private void SetCanvasPosition()
    {
        Camera camera = Camera.main;
        Canvas canvas = GetComponent<Canvas>();
        float cameraY = camera.transform.position.y;
        Vector3 canvasPosition = canvas.transform.position;

        canvasPosition.y = cameraY;
        canvas.transform.position = canvasPosition;
    }
    public void OpenSafetyBook()
    {
        Debug.Log("Opened Book");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
