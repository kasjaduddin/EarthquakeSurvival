using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreditController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Title;
    [SerializeField]
    TextMeshProUGUI Body;
    [SerializeField]
    TextMeshProUGUI ButtonText;
    [SerializeField]
    GameObject GameName;
    [SerializeField]
    GameObject MainMenuButton;
    [SerializeField]
    GameObject CreditPage;

    string[,] text = new string[4, 2];
    int page;
    void Start()
    {
        page = -1;

        text[0, 0] = "DEVELOPER";
        text[0, 1] = "Kholil Asjaduddin";
        text[1, 0] = "ASSETS";
        text[1, 1] = "UNITY\r\nVR Template\r\n\r\nUNITY ASSET\r\nVefects\r\n\r\nMETA\r\nOculus Hand\r\n\r\nGOOGLE\r\nGoogle Fonts";
        text[2, 0] = "ASSETS";
        text[2, 1] = "FLATICON\r\nFreepik\r\nKiranshastry\r\nLeremy\r\nverry purnomo\r\nnawicon\r\nSaepul Nahwa\r\nkerismaker";
        text[3, 0] = "ASSETS";
        text[3, 1] = "CGTRADER\r\nbalintpeter\r\nkarthikeyan1331\r\nmiska-tervo05\r\nsaar137\r\ntangquidong\r\ncavitbarisbalta\r\namaan-des1\r\nxfrog\r\n3DHaupt";

        NextCredit();
    }
    void Update()
    {
        
    }
    public void NextCredit()
    {
        page++;
        switch (page) 
        {
            case 0:
                Title.text = text[0, 0];
                Body.text = text[0, 1];
                Body.fontSize = 98;
                break;
            case 1:
                Title.text = text[1, 0];
                Body.text = text[1, 1];
                Body.fontSize = 70;
                break;
            case 2:
                Title.text = text[2, 0];
                Body.text = text[2, 1];
                Body.fontSize = 85;
                break;
            case 3:
                Title.text = text[3, 0];
                Body.text = text[3, 1];
                Body.fontSize = 82;

                ButtonText.text = "Main Menu";
                break;
            default:
                page = 0;

                Title.text = text[0, 0];
                Body.text = text[0, 1];
                
                GameName.SetActive(true);
                MainMenuButton.SetActive(true);
                CreditPage.SetActive(false);
                break;
        }
    }
}
