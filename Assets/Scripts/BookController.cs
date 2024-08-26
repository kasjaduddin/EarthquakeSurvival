using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> GuideImage;
    [SerializeField]
    private List<GameObject> ImageNumber;
    [SerializeField]
    private TextMeshProUGUI Title;
    [SerializeField]
    private TextMeshProUGUI Body;
    [SerializeField]
    private TextMeshProUGUI TextButton;
    [SerializeField]
    private GameObject GameName;
    [SerializeField]
    private GameObject ButtonMenu;
    [SerializeField]
    private GameObject SafetyBook;

    string[,] Guide = new string[7,2];
    int[] unlockedGuide = new int[7];
    int guideIndex;

    private void Awake()
    {
        unlockedGuide[0] = unlockedGuide[1] = unlockedGuide[2] = 1;
    }
    void Start()
    {
        guideIndex = 0;
        AssignGuide();
        GetUnlockedGuide();
        ShowGuide(guideIndex);
    }
    void Update()
    {
        
    }
    private void AssignGuide()
    {
        Guide[0, 0] = "DROP";
        Guide[0, 1] = "Keseimbangan adalah kunci menghindari cedera. Jaga keseimbanganmu selagi mencari tempat berlindung!";
        Guide[1, 0] = "COVER";
        Guide[1, 1] = "Lindungi kepalamu! Berbagai objek bisa saja terjatuh dari atas";
        Guide[2, 0] = "HOLD ON";
        Guide[2, 1] = "Berpeganglah pada benda yang melindungimu! Pastikan dirimu tetap terlindungi";
        Guide[3, 0] = "STAY INDOOR";
        Guide[3, 1] = "Tidak ada yang tahu kondisi di luar. Sebaiknya tetap dalam ruangan hingga kondisi membaik";
        Guide[4, 0] = "AVOID FRAGLE";
        Guide[4, 1] = "Gempa mampu memberi guncangan yang besar. Jauhi benda-benda yang mudah pecah dan terjatuh";
        Guide[5, 0] = "TURN OFF FIRE";
        Guide[5, 1] = "Perhatikan api, air, dan listrik! Pastikan tidak terjadi bencana lain karena kelalaian";
        Guide[6, 0] = "AVOID TREE";
        Guide[6, 1] = "Tetaplah di ruang terbuka! Pohon, tiang, hingga bangunan bisa saja terjatuh";
    }
    private void GetUnlockedGuide()
    {
        unlockedGuide[3] = PlayerPrefs.GetInt("FourthGuide");
        unlockedGuide[4] = PlayerPrefs.GetInt("FifthGuide");
        unlockedGuide[5] = PlayerPrefs.GetInt("SixthGuide");
        unlockedGuide[6] = PlayerPrefs.GetInt("SeventhGuide");
    }
    private void ShowGuide(int index)
    {
        if (unlockedGuide[index] != 1)
        {
            Title.text = "????";
            Body.text = "Panduan keselamatan belum ditemukan. Ayo eksplorasi lagi untuk menemukan halaman ini!";
            if (index - 4 >= 0)
            {
                ImageNumber[index - 4].SetActive(false);
            }
            ImageNumber[index - 3].SetActive(true);
        }
        else
        {
            Title.text = Guide[index, 0];
            Body.text = Guide[index, 1];
            GuideImage[index].SetActive(true);
        }
    }
    public void NextGuide()
    {
        if (guideIndex < 6)
        {
            guideIndex++;
            GuideImage[guideIndex-1].SetActive(false);
            ShowGuide(guideIndex);

            if (guideIndex == 6)
            {
                TextButton.text = "Main Menu";
            }
        }
        else
        {
            ResetGuide();
            GameName.SetActive(true);
            ButtonMenu.SetActive(true);
            SafetyBook.SetActive(false);
        }
        Debug.Log(guideIndex);
    }
    private void ResetGuide()
    {
        guideIndex = 0;
        ImageNumber[3].SetActive(false);
        ShowGuide(guideIndex);
    }
}
