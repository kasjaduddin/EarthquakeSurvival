using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class KitchenController : MonoBehaviour
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
    private GameObject Fire;
    [SerializeField]
    private VideoClip DoesntTurnOffStove;
    [SerializeField]
    private VideoClip JustTurnOffStove;
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
        highScore = PlayerPrefs.GetInt("SecondHighScore");
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

        FurnitureAnimator.Play("KitchenAnimation");
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
        if (!Fire.activeSelf)
        {
            if (playerPosition.z > 82.8f && (playerPosition.x > -6.7f && playerPosition.x < -5.4f))
            {
                StopSimulation();
                WinEnding();
                ending = true;
            }
            else
            {
                if (Time.time - startTime >= 30f)
                {
                    StopSimulation();
                    videoPlayer.clip = JustTurnOffStove;
                    videoPlayer.Play();

                    if (highScore < 50)
                        PlayerPrefs.SetInt("SecondHighScore", 50);

                    Message[0].text = "ADUH!";
                    Message[1].text = 50.ToString();
                    Message[2].text = "Carilah Tempat Berlindung";
                    Invoke("ShowPoint", 1.8f);
                    ending = true;
                }
            }
        }
        else 
        {
            if (Time.time - startTime >= 30f)
            {
                StopSimulation();
                videoPlayer.clip = DoesntTurnOffStove;
                videoPlayer.Play();

                if (PlayerPrefs.GetInt("FifthGuide") != 1)
                    PlayerPrefs.SetInt("FifthGuide", 1);

                Message[0].text = "KEBAKARAN!";
                Message[1].text = 00.ToString();
                Message[2].text = "Matikan Api Sebelum Melakukan Evakuasi Gempa";
                Invoke("ShowPoint", 1.8f);
                ending = true;
            }
        }
    }
    private void WinEnding()
    {
        if (highScore < 100)
            PlayerPrefs.SetInt("SecondHighScore", 100);

        Message[0].text = "Kerja Bagus!";
        Message[1].text = 100.ToString();
        Message[2].text = "Meja Dapat Menjadi Tempat Berlindung";
    }
    void ShowPoint()
    {
        Video.SetActive(false);
    }
}
