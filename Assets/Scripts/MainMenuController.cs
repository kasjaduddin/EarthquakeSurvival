using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI ChapterDetail;
    [SerializeField]
    private TextMeshProUGUI ChapterScore;

    public int[] highScore;
    void Start()
    {
        SetCanvasPosition();
        highScore[0] = PlayerPrefs.GetInt("FirstHighScore");
        highScore[1] = PlayerPrefs.GetInt("SecondHighScore");
        highScore[2] = PlayerPrefs.GetInt("ThirdHighScore");
        highScore[3] = PlayerPrefs.GetInt("FourthHighScore");
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
        ChapterScore.text = "HIGHSCORE: " + highScore[0].ToString();
    }
    public void SecondChapterDetail()
    {
        ChapterDetail.text = "CHAPTER 2: Kitchen";
        ChapterScore.text = "HIGHSCORE: " + highScore[1].ToString();
    }
    public void ThirdChapterDetail()
    {
        ChapterDetail.text = "CHAPTER 3: Bedroom";
        ChapterScore.text = "HIGHSCORE: " + highScore[2].ToString();
    }
    public void FourthChapterDetail()
    {
        ChapterDetail.text = "CHAPTER 4: Outdoor";
        ChapterScore.text = "HIGHSCORE: " + highScore[3].ToString();
    }
    public void PlayChapterOne() 
    { 

    }
    public void PlayChapterTwo()
    {

    }
    public void PlayChapterThree()
    {

    }
    public void PlayChapterFour()
    {

    }
    public void PointerExitChapterButton()
    {
        ChapterDetail.text = "";
        ChapterScore.text = "";
    }
}
