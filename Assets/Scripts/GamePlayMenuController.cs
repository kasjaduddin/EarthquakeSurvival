using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayMenuController : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        SetCanvas();
    }
    private void SetCanvas()
    {
        Camera camera = Camera.main;
        GameObject canvas = GameObject.Find("Canvas");

        SetCanvasPosition(camera, canvas);
        SetCanvasRotation(camera, canvas);
    }
    private void SetCanvasPosition(Camera camera, GameObject canvas)
    {
        Vector3 menuPosition = canvas.transform.position;

        menuPosition.y = camera.transform.position.y;
        menuPosition.z = camera.transform.position.z + 2.0f;
        canvas.transform.position = menuPosition;
    }
    private void SetCanvasRotation(Camera camera, GameObject canvas)
    {
        canvas.transform.rotation = camera.transform.rotation;
        Vector3 newPosition = camera.transform.position + camera.transform.forward * 2.0f;
        canvas.transform.position = newPosition;
    }
    public void PlayAgain()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
