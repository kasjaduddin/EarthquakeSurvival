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

        SetCanvasRotation(camera, canvas);
    }
    private void SetCanvasRotation(Camera camera, GameObject canvas)
    {
        canvas.transform.rotation = camera.transform.rotation;
        Vector3 newPosition = camera.transform.position + camera.transform.forward * .85f;
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
