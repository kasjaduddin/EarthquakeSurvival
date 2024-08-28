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
    }
    private void PlaySimulation()
    {
        HouseAnimator = House.GetComponent<Animator>();
        FurnitureAnimator = Furniture.GetComponent<Animator>();

        HouseAnimator.enabled = true;
        FurnitureAnimator.enabled = true;

        HouseAnimator.Play("FurnitureAnimator");
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
            Debug.Log(playerPosition.x);
            if (playerPosition.z > 80f && (playerPosition.x > 2f && playerPosition.x < 6.5f))
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
                    Debug.Log("Cari Tempat Berlindung");

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
            Debug.Log("Kompor hidup");
            if (Time.time - startTime >= 30f)
            {
                StopSimulation();
                videoPlayer.clip = DoesntTurnOffStove;
                videoPlayer.Play();
                Debug.Log("Matikan api sebelum melakukan evakuasi");

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
            PlayerPrefs.SetInt("FirstHighScore", 100);

        Message[0].text = "Kerja Bagus!";
        Message[1].text = 100.ToString();
        Message[2].text = "Meja Dapat Menjadi Tempat Berlindung";
    }
    void ShowPoint()
    {
        Video.SetActive(false);
    }
}
