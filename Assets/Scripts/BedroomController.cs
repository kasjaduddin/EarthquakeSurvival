using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class BedroomController : MonoBehaviour
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
    private GameObject Pillow;
    [SerializeField]
    private GameObject PlayerCamera;
    [SerializeField]
    private GameObject LeftController;
    [SerializeField]
    private GameObject RightController;
    [SerializeField]
    private GameObject Video;
    [SerializeField]
    private VideoClip AroundFragle;
    [SerializeField]
    private VideoClip DoNothing;
    [SerializeField]
    private GameObject MoveController;

    private Animator HouseAnimator;
    private Animator FurnitureAnimator;
    private VideoPlayer videoPlayer;

    private int highScore;
    private float headPosition;
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
        headPosition = GetHeadPosition();
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

        FurnitureAnimator.Play("BedroomAnimation");
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
        if (CoverHeadWithPillow())
        {
            StopSimulation();
            WinEnding();
            ending = true;
        }
        else if (playerPosition.x < 0f && playerPosition.z < -2.5f)
        {
            StopSimulation();
            videoPlayer.clip = AroundFragle;
            videoPlayer.Play();

            if (PlayerPrefs.GetInt("SixthGuide") != 1)
                PlayerPrefs.SetInt("SixthGuide", 1);

            if (highScore < 25)
                PlayerPrefs.SetInt("ThirdHighScore", 25);

            Message[0].text = "PERHATIKAN SEKITAR!";
            Message[1].text = 25.ToString();
            Message[2].text = "Jauhi Benda-Benda Yang Mudah Pecah Dan Terjatuh";
            Invoke("ShowPoint", 1.8f);
            ending = true;
        }
        else if (Time.time - startTime >= 35f)
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
    private float GetHeadPosition()
    {
        return PlayerCamera.transform.position.y;
    }
    private bool GrabPillow()
    {
        float leftHandOffset = Vector3.Distance(Pillow.transform.position, LeftController.transform.position);
        float rightHandOffset = Vector3.Distance(Pillow.transform.position, RightController.transform.position);
        if (leftHandOffset < .65f || rightHandOffset < .65f)
            return true;
        else
            return false;
    }
    private bool CoverHeadWithPillow()
    {
        float leftHandPositionY = LeftController.transform.position.y;
        float rightHandPositionY = RightController.transform.position.y;
        float pillowPosition = Pillow.transform.position.y - .7f;
        Debug.Log(pillowPosition + "\n" + headPosition);
        if (pillowPosition > headPosition)
            return true;
        else
            return false;
    }
    private void WinEnding()
    {
        if (highScore < 100)
            PlayerPrefs.SetInt("ThirdHighScore", 100);

        Message[0].text = "IDE BAGUS!";
        Message[1].text = 100.ToString();
        Message[2].text = "Bantal Dapat Dapat Digunakan Sebagai Pelindung Kepala";
    }
    void ShowPoint()
    {
        Video.SetActive(false);
    }
}
