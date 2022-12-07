using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KatongSelect : MonoBehaviour
{
    public GameObject[] katongImage;
    public GameObject[] selectFrame;

    [SerializeField]
    GameObject popUpPanel, freePanel, buyPanel, goldCoin, cashCoin;
    [SerializeField]
    Text priceText;

    public int katongType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KatongReset()
    {
        for (int i = 0; i < katongImage.Length; i++)
        {
            katongImage[i].SetActive(false);
            selectFrame[i].SetActive(false);
        }
        katongImage[0].SetActive(true);
        selectFrame[0].SetActive(true);
        katongType = 0;
    }

    public void KatongType(int katong)
    {
        for(int i=0;i<katongImage.Length;i++)
        {
            katongImage[i].SetActive(false);
            selectFrame[i].SetActive(false);
        }
        katongImage[katong].SetActive(true);
        selectFrame[katong].SetActive(true);

        katongType = katong;

    }

    public void BuyKatong()
    {
        popUpPanel.SetActive(true);
        switch (katongType)
        {
            case 0:
                freePanel.SetActive(true);
                buyPanel.SetActive(false);
                break;
            case 1:
                freePanel.SetActive(false);
                buyPanel.SetActive(true);
                goldCoin.SetActive(true);
                priceText.text = "10 k";
                break;
            case 2:
                freePanel.SetActive(false);
                buyPanel.SetActive(true);
                goldCoin.SetActive(true);
                priceText.text = "50 k";
                break;
            case 3:
                freePanel.SetActive(false);
                buyPanel.SetActive(true);
                goldCoin.SetActive(true);
                priceText.text = "100 k";
                break;
            case 4:
                freePanel.SetActive(false);
                buyPanel.SetActive(true);
                goldCoin.SetActive(true);
                priceText.text = "200 k";
                break;
            case 5:
                freePanel.SetActive(false);
                buyPanel.SetActive(true);
                cashCoin.SetActive(true);
                priceText.text = "30";
                break;
            case 6:
                freePanel.SetActive(false);
                buyPanel.SetActive(true);
                cashCoin.SetActive(true);
                priceText.text = "30";
                break;
            default:
                break;
        }

    }

    public int GetKatongType()
    {
        return katongType;
    }

    public void PurcheaseKatong()
    {
        popUpPanel.SetActive(false);
        freePanel.SetActive(false);
        buyPanel.SetActive(false);
        goldCoin.SetActive(false);
        cashCoin.SetActive(false);
    }

    public void CancelBuy()
    {
        popUpPanel.SetActive(false);
        freePanel.SetActive(false);
        buyPanel.SetActive(false);
    }
}
