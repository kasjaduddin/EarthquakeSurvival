using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using TMPro;
using UnityEngine.Video;

public class LivingroomController : MonoBehaviour
{
    [SerializeField]
    private GameObject House;
    [SerializeField]
    private GameObject Furniture;
    [SerializeField]
    private GameObject Player;
    [SerializeField] 
    private List<TextMeshProUGUI> Alert;
    [SerializeField]
    private GameObject Menu;
    [SerializeField]
    private List<TextMeshProUGUI> Message;
    [SerializeField]
    private GameObject Video;
    [SerializeField]
    private VideoClip ExitRoom;
    [SerializeField]
    private VideoClip DoNothing;
    [SerializeField]
    private GameObject MoveController;

    private Animator HouseAnimator;
    private Animator FurnitureAnimator;
    private VideoPlayer videoPlayer;

    private int highScore;
    private float startTime;
    private bool ending;
    void Start()
    {
        videoPlayer = Video.GetComponentInChildren<VideoPlayer>();
        highScore = PlayerPrefs.GetInt("FirstHighScore");
        startTime = Time.time;
        ending = false;
        PlaySimulation();
    }
    void Update()
    {
        if (!ending)
            DetermineEnding();
        else
            MoveController.SetActive(false);
    }
    private void PlaySimulation()
    {
        HouseAnimator = House.GetComponent<Animator>();
        FurnitureAnimator = Furniture.GetComponent<Animator>();

        HouseAnimator.enabled = true;
        FurnitureAnimator.enabled = true;

        FurnitureAnimator.Play("LivingroomAnimation");
    }
    private void StopSimulation()
    {
        HouseAnimator.enabled = false;
        FurnitureAnimator.enabled = false;

        Alert[0].text = Alert[1].text = "";
        Menu.SetActive(true);
    }
    private void DetermineEnding()
    {
        Vector3 playerPosition = Player.transform.position;
        if (playerPosition.x < 11 && playerPosition.z < 4.5)
        {
            StopSimulation();
            WinEnding();
            ending = true;
        }
        else if (playerPosition.x < 7.5)
        {
            StopSimulation();
            videoPlayer.clip = ExitRoom;
            videoPlayer.Play();
            Debug.Log("Jangan Keluar Ruangan");

            if (highScore < 25)
                PlayerPrefs.SetInt("FirstHighScore", 25);

            Message[0].text = "HATI-HATI!";
            Message[1].text = 25.ToString();
            Message[2].text = "Sebaiknya Tetap Dalam Ruangan Hingga Kondisi Membaik";
            Invoke("ShowPoint", 1.8f);
            ending = true;
        }
        else if (Time.time - startTime >= 45f)
        {
            StopSimulation();
            videoPlayer.clip = DoNothing;
            videoPlayer.Play();
            Debug.Log("Cari Tempat Berlindung");

            Message[0].text = "ADUH!";
            Message[1].text = 00.ToString();
            Message[2].text = "Carilah Tempat Berlindung";
            Invoke("ShowPoint", 1.8f);
            ending = true;
        }
    }
    private void WinEnding()
    {
        if (highScore < 100)
            PlayerPrefs.SetInt("FirstHighScore", 100);

        Message[0].text = "HEBAT!";
        Message[1].text = 100.ToString();
        Message[2].text = "Meja Dapat Menjadi Tempat Berlindung";
    }
    void ShowPoint()
    {
        Video.SetActive(false);
    }
}
