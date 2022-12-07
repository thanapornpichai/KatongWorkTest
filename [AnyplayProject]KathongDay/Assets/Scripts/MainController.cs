using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public static MainController Instance;
    public WebRequest webRequest;
    public UserInfo userInfo;
    [SerializeField]
    GameObject katongSelect, katongBtn, errorPanel, popUpPanel;
    [SerializeField]
    GameObject noWishText, doneText, noMoneyText;
    [SerializeField]
    InputField katongWish;
    [SerializeField]
    Text countChar;
    [SerializeField]
    TextMeshProUGUI[] textWish, textUserName;
    [SerializeField]
    SpriteRenderer[] katongImage,userPic;
    [SerializeField]
    Sprite[] katongSprite,userProSprite;
    private int katongNum,katongType;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        webRequest = GetComponent<WebRequest>();
        userInfo = GetComponent<UserInfo>();
        katongWish.characterLimit = 32;
    }

    // Update is called once per frame
    void Update()
    {
        CountChar();
    }

    public void OpenKatongSelect()
    {
        katongSelect.SetActive(true);
        katongBtn.SetActive(false);
        katongWish.text = "";
    }

    public void BackToMain()
    {
        katongSelect.SetActive(false);
        katongBtn.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void CountChar()
    {
        string source = katongWish.text;
        int count = source.Length;
        countChar.text = count.ToString() + "/32";
    }

    public void CheckWord()
    {
        string source = katongWish.text;
        int count = source.Length;
        if (count == 0)
        {
            noWishText.SetActive(true);
            errorPanel.SetActive(true);
            popUpPanel.SetActive(true);
        }
    }

    public void LoyKatong()
    {
        string userName = MainController.Instance.userInfo.FBname;
        GetKatongNum();
        if (katongNum == 9)
        {
            textUserName[0].text = userName;
            textWish[0].text = katongWish.text;
            switch (userName)
            {
                case "user001":
                    userPic[0].sprite = userProSprite[0];
                    break;
                case "user002":
                    userPic[0].sprite = userProSprite[1];
                    break;
                case "user003":
                    userPic[0].sprite = userProSprite[2];
                    break;
                default:
                    break;
            }
        }
        else if (katongNum == 10)
        {
            textUserName[1].text = userName;
            textWish[1].text = katongWish.text;
            switch (userName)
            {
                case "user001":
                    userPic[1].sprite = userProSprite[0];
                    break;
                case "user002":
                    userPic[1].sprite = userProSprite[1];
                    break;
                case "user003":
                    userPic[1].sprite = userProSprite[2];
                    break;
                default:
                    break;
            }
        }
        else
          {
                textUserName[katongNum + 1].text = userName;
                textWish[katongNum + 1].text = katongWish.text;
            switch (userName)
            {
                case "user001":
                    userPic[katongNum + 1].sprite = userProSprite[0];
                    break;
                case "user002":
                    userPic[katongNum + 1].sprite = userProSprite[1];
                    break;
                case "user003":
                    userPic[katongNum + 1].sprite = userProSprite[2];
                    break;
                default:
                    break;
            }
        }
        katongType = FindObjectOfType<KatongSelect>().GetKatongType();
        switch (katongType)
        {
            case 0:
                if (katongNum == 9)
                {
                    katongImage[0].sprite = katongSprite[0];
                }
                else if (katongNum == 10)
                {
                    katongImage[1].sprite = katongSprite[0];
                }
                else
                {
                    katongImage[katongNum + 1].sprite = katongSprite[0];
                }
                break;
            case 1:
                if (katongNum == 9)
                {
                    katongImage[0].sprite = katongSprite[1];
                }
                else if (katongNum == 10)
                {
                    katongImage[1].sprite = katongSprite[1];
                }
                else
                {
                    katongImage[katongNum + 1].sprite = katongSprite[1];
                }
                break;
            case 2:
                if (katongNum == 9)
                {
                    katongImage[0].sprite = katongSprite[2];
                }
                else if (katongNum == 10)
                {
                    katongImage[1].sprite = katongSprite[2];
                }
                else
                {
                    katongImage[katongNum + 1].sprite = katongSprite[2];
                }
                break;
            case 3:
                if (katongNum == 9)
                {
                    katongImage[0].sprite = katongSprite[3];
                }
                else if (katongNum == 10)
                {
                    katongImage[1].sprite = katongSprite[3];
                }
                else
                {
                    katongImage[katongNum + 1].sprite = katongSprite[3];
                }
                break;
            case 4:
                if (katongNum == 9)
                {
                    katongImage[0].sprite = katongSprite[4];
                }
                else if (katongNum == 10)
                {
                    katongImage[1].sprite = katongSprite[4];
                }
                else
                {
                    katongImage[katongNum + 1].sprite = katongSprite[4];
                }
                break;
            case 5:
                if (katongNum == 9)
                {
                    katongImage[0].sprite = katongSprite[5];
                }
                else if (katongNum == 10)
                {
                    katongImage[1].sprite = katongSprite[5];
                }
                else
                {
                    katongImage[katongNum + 1].sprite = katongSprite[5];
                }
                break;
            case 6:
                if (katongNum == 9)
                {
                    katongImage[0].sprite = katongSprite[6];
                }
                else if (katongNum == 10)
                {
                    katongImage[1].sprite = katongSprite[6];
                }
                else
                {
                    katongImage[katongNum + 1].sprite = katongSprite[6];
                }
                break;
            default:
                break;
        }
        BackToMain();

    }

    public void CloseNoti()
    {
        noWishText.SetActive(false);
        doneText.SetActive(false);
        noMoneyText.SetActive(false);
        errorPanel.SetActive(false);
        popUpPanel.SetActive(false);
    }

    public void GetKatongNum()
    {
        katongNum = FindObjectOfType<CountKatong>().GetKatongPass();
    }
}
