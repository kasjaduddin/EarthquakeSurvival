using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class OutdoorController : MonoBehaviour
{
    [SerializeField]
    private GameObject House;
    [SerializeField]
    private GameObject Trees;
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
    private VideoClip AroundTree;

    private Animator HouseAnimator;
    private Animator TreesAnimator;
    private VideoPlayer videoPlayer;

    private int highScore;
    private float startTime;
    private bool ending;
    void Start()
    {
        videoPlayer = Video.GetComponentInChildren<VideoPlayer>();
        highScore = PlayerPrefs.GetInt("FourthHighScore");
        startTime = Time.time;
        ending = false;
        PlaySimulation();
    }
    void Update()
    {
        if (!ending)
            DetermineEnding();
    }
    private void PlaySimulation()
    {
        HouseAnimator = House.GetComponent<Animator>();
        TreesAnimator = Trees.GetComponent<Animator>();

        HouseAnimator.enabled = true;
        TreesAnimator.enabled = true;

        HouseAnimator.Play("TreesAnimation");
        TreesAnimator.Play("LivingroomAnimation");
    }
    private void StopSimulation()
    {
        HouseAnimator.enabled = false;
        TreesAnimator.enabled = false;

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
            videoPlayer.clip = AroundTree;
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
            videoPlayer.clip = AroundTree;
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
