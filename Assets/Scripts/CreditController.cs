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

    string[,] text = new string[3, 2];
    int page;
    void Start()
    {
        page = -1;

        text[0, 0] = "DEVELOPER";
        text[0, 1] = "Kholil Asjaduddin";
        text[1, 0] = "ASSETS";
        text[1, 1] = "UNITY\r\nVR Template\r\n\r\nMETA\r\nOculus Hand\r\n\r\nGOOGLE\r\nGoogle Fonts";
        text[2, 0] = "";
        text[2, 1] = "";

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
                break;
            case 1:
                Title.text = text[1, 0];
                Body.text = text[1, 1];
                break;
            case 2:
                Title.text = text[2, 0];
                Body.text = text[2, 1];
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
