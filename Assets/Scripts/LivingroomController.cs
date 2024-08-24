using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using TMPro;

public class LivingroomController : MonoBehaviour
{
    [SerializeField]
    private GameObject House;
    [SerializeField]
    private GameObject Furniture;
    [SerializeField]
    private GameObject Player;
    [SerializeField] 
    private TextMeshProUGUI Alert;
    [SerializeField]
    private GameObject Menu;
    [SerializeField]
    private List<TextMeshProUGUI> Message;

    private Animator HouseAnimator;
    private Animator FurnitureAnimator;

    private int highScore;

    private float startTime;
    void Start()
    {
        startTime = Time.time;

        PlaySimulation();

        highScore = PlayerPrefs.GetInt("FirstHighScore");
    }
    void Update()
    {
        Vector3 playerPosition = Player.transform.position;
        if (playerPosition.x < 11 && playerPosition.z < 4.2)
        {
            StopSimulation();
            WinEnding();
            Debug.Log("Win");
        }
        else if (playerPosition.x < 7.5)
        {
            StopSimulation();
            Debug.Log("Jangan Keluar Ruangan");

            if (highScore < 25)
                PlayerPrefs.SetInt("FirstHighScore", 25);

            Message[0].text = "HATI-HATI!";
            Message[1].text = 25.ToString();
            Message[2].text = "Sebaiknya Tetap Dalam Ruangan Hingga Kondisi Membaik";
        }
        else if (Time.time - startTime >= 20f)
        {
            StopSimulation();
            Debug.Log("Cari Tempat Berlindung");

            Message[0].text = "ADUH!";
            Message[1].text = 00.ToString();
            Message[2].text = "Carilah Tempat Berlindung";
        }
        else
        Debug.Log("Player Position: X = " + playerPosition.x + " --- Y = " + playerPosition.y + " --- Z = " + playerPosition.z);
    }

    private void PlaySimulation()
    {
        HouseAnimator = House.GetComponent<Animator>();
        FurnitureAnimator = Furniture.GetComponent<Animator>();

        HouseAnimator.enabled = true;
        FurnitureAnimator.enabled = true;

        HouseAnimator.Play("FurnitureAnimator");
        FurnitureAnimator.Play("LivingroomAnimation");
    }
    private void StopSimulation()
    {
        HouseAnimator.enabled = false;
        FurnitureAnimator.enabled = false;

        Alert.text = "";
        Menu.SetActive(true);
    }
    private void WinEnding()
    {
        if (highScore < 100)
            PlayerPrefs.SetInt("FirstHighScore", 100);

        Message[0].text = "HEBAT!";
        Message[1].text = 100.ToString();
        Message[2].text = "Meja Dapat Menjadi Tempat Berlindung";
    }
}
