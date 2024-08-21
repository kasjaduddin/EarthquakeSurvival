using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ChapterDetail;
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
    public void QuitGame()
    {
        Application.Quit();
    }
    public void FirtsChapterDetail()
    {
        ChapterDetail.text = "CHAPTER 1: Livingroom";
    }
    public void SecondChapterDetail()
    {
        ChapterDetail.text = "CHAPTER 2: Kitchen";
    }
    public void ThirdChapterDetail()
    {
        ChapterDetail.text = "CHAPTER 3: Bedroom";
    }
    public void FourthChapterDetail()
    {
        ChapterDetail.text = "CHAPTER 4: Outdoor";
    }
}
