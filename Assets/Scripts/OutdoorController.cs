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
    [SerializeField]
    private GameObject MoveController;

    private Animator HouseAnimator;
    private Animator TreesAnimator;
    private VideoPlayer videoPlayer;

    private int highScore;
    private float startTime;
    private bool ending;
    void Start()
    {
        videoPlayer = Video.GetComponentInChildren<VideoPlayer>();
        highScore = PlayerPrefs.GetInt("ThirdHighScore");
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
        TreesAnimator = Trees.GetComponent<Animator>();

        HouseAnimator.enabled = true;
        TreesAnimator.enabled = true;

        TreesAnimator.Play("TreesAnimation");
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
        if (AroundSectorOne(playerPosition) || AroundSectorTwo(playerPosition) || AroundSectorThree(playerPosition))
        {
            StopSimulation();
            videoPlayer.clip = AroundTree;
            videoPlayer.Play();

            if (PlayerPrefs.GetInt("SixthGuide") != 1)
                PlayerPrefs.SetInt("SixthGuide", 1);

            Message[0].text = "AWAS!";
            Message[1].text = 00.ToString();
            Message[2].text = "Pohon, Tiang, Ataupun Bangunan Bisa Saja Terjatuh";
            Invoke("ShowPoint", 1.8f);
            ending = true;
        }
        else 
        {
            if (Time.time - startTime >= 20f)
            {
                StopSimulation();
                WinEnding();
                ending = true;
            }
        }
    }
    private bool AroundSectorOne(Vector3 playerPosition)
    {
        if (playerPosition.x > 50f)
            return true;
        else
            return false;
    }
    private bool AroundSectorTwo(Vector3 playerPosition)
    {
        if ((playerPosition.x < 22f && playerPosition.x > 12f) && playerPosition.z > 55f)
            return true;
        else 
            return false;
    }
    private bool AroundSectorThree(Vector3 playerPosition)
    {
        if ((playerPosition.x < -3f && playerPosition.x > -13f) && playerPosition.z > 55f)
            return true;
        else
            return false;
    }
    private void WinEnding()
    {
        ShowPoint();
        if (highScore < 100)
            PlayerPrefs.SetInt("ThirdHighScore", 100);

        Message[0].text = "Pilihan Bijak!";
        Message[1].text = 100.ToString();
        Message[2].text = "Ruang Terbuka Adalah Tempat Paling Aman";
    }
    void ShowPoint()
    {
        Video.SetActive(false);
    }
}
