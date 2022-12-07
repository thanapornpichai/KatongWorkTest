using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;
using TMPro;

public class Items : MonoBehaviour
{
    Action<string> _createItemsCallback;
    [SerializeField]
    Sprite[] katongImage,userPic;
    [SerializeField]
    SpriteRenderer[] katong,picPro;
    [SerializeField]
    TextMeshProUGUI[] wishes, userName;
    [SerializeField]
    InputField wishInput;
    int x,j, katongType;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(CallCreateUserItem());
    }

    public void CreateItems()
    {
        string userId = MainController.Instance.userInfo.UserID;
        StartCoroutine(MainController.Instance.webRequest.GetUsers(userId)); 
        StartCoroutine(MainController.Instance.webRequest.GetItemsIDs(userId, _createItemsCallback));
    }

    public void CreateFriendItems()
    {
        string userId = MainController.Instance.userInfo.FriendID;
        StartCoroutine(MainController.Instance.webRequest.GetFriendName(userId));
        StartCoroutine(MainController.Instance.webRequest.GetItemsIDs(userId, _createItemsCallback));
    }

    IEnumerator CreateItemsRoutine(string jsonArrayString)
    {
        //Parsing json array string as an array
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;

        for (int i = x; i < jsonArray.Count; i++)
        {
            bool isDone = false;
            string itemId = jsonArray[i].AsObject["itemID"];
            string itemWishes = jsonArray[i].AsObject["wishes"];
            wishes[i].text = itemWishes;
            userName[i].text = MainController.Instance.userInfo.FBname;
            JSONObject itemInfoJson = new JSONObject();

            Action<string> getItemInfoCallback = (itemInfo) =>
            {
                isDone = true;
                JSONArray tempArray = JSON.Parse(itemInfo) as JSONArray;
                itemInfoJson = tempArray[0].AsObject;
            };

            StartCoroutine(MainController.Instance.webRequest.GetItem(itemId, getItemInfoCallback));

            yield return new WaitUntil(() => isDone == true);

            if(i==x)
            {
                string katongType = itemInfoJson["name"];
                switch (katongType)
                {
                    case "katong1":
                        katong[i].sprite = katongImage[0];
                        break;
                    case "katong2":
                        katong[i].sprite = katongImage[1];
                        break;
                    case "katong3":
                        katong[i].sprite = katongImage[2];
                        break;
                    case "katong4":
                        katong[i].sprite = katongImage[3];
                        break;
                    case "katong5":
                        katong[i].sprite = katongImage[4];
                        break;
                    case "katong6":
                        katong[i].sprite = katongImage[5];
                        break;
                    case "katong7":
                        katong[i].sprite = katongImage[6];
                        break;
                    default:
                        break;
                }
            }

            if (i == x)
            {
                switch (userName[i].text)
                {
                    case "user001":
                        picPro[i].sprite = userPic[0];
                        break;
                    case "user002":
                        picPro[i].sprite = userPic[1];
                        break;
                    case "user003":
                        picPro[i].sprite = userPic[2];
                        break;
                    default:
                        break;
                }
            }
            x++;
        }
        StartCoroutine(CallFriendUserItem());
    }

    IEnumerator CreateFriendItemsRoutine(string jsonArrayString)
    {
        //Parsing json array string as an array
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;

        for (int i = 0; x<10 ; i++)
        {
            bool isDone = false;
            string itemId = jsonArray[i].AsObject["itemID"];
            string itemWishes = jsonArray[i].AsObject["wishes"];
            wishes[x].text = itemWishes;
            userName[x].text = MainController.Instance.userInfo.FriendName;
            JSONObject itemInfoJson = new JSONObject();

            Action<string> getItemInfoCallback = (itemInfo) =>
            {
                isDone = true;
                JSONArray tempArray = JSON.Parse(itemInfo) as JSONArray;
                itemInfoJson = tempArray[0].AsObject;
            };

            StartCoroutine(MainController.Instance.webRequest.GetItem(itemId, getItemInfoCallback));

            yield return new WaitUntil(() => isDone == true);

            if (i == j)
            {
                string katongType = itemInfoJson["name"];
                switch (katongType)
                {
                    case "katong1":
                        katong[x].sprite = katongImage[0];
                        break;
                    case "katong2":
                        katong[x].sprite = katongImage[1];
                        break;
                    case "katong3":
                        katong[x].sprite = katongImage[2];
                        break;
                    case "katong4":
                        katong[x].sprite = katongImage[3];
                        break;
                    case "katong5":
                        katong[x].sprite = katongImage[4];
                        break;
                    case "katong6":
                        katong[x].sprite = katongImage[5];
                        break;
                    case "katong7":
                        katong[x].sprite = katongImage[6];
                        break;
                    default:
                        break;
                }
            }

            if (i == j)
            {
                switch (userName[x].text)
                {
                    case "user001":
                        picPro[x].sprite = userPic[0];
                        break;
                    case "user002":
                        picPro[x].sprite = userPic[1];
                        break;
                    case "user003":
                        picPro[x].sprite = userPic[2];
                        break;
                    default:
                        break;
                }
            }

            x++;
            j++;
        }
    }

    IEnumerator CallCreateUserItem()
    {
        _createItemsCallback = (jsonArrayString) => {
            StartCoroutine(CreateItemsRoutine(jsonArrayString));

        };
        yield return new WaitForSeconds(1);
        CreateItems();
    }

    IEnumerator CallFriendUserItem()
    {
        _createItemsCallback = (jsonArrayString) => {
            StartCoroutine(CreateFriendItemsRoutine(jsonArrayString));

        };
        CreateFriendItems();
        yield return new WaitForSeconds(1);
    }

    public void KatongTypeSelect()
    {
        katongType = FindObjectOfType<KatongSelect>().GetKatongType();
    }

    public void SellItem()
    {
        string userId = MainController.Instance.userInfo.UserID;
        string userItemType = (katongType+1).ToString();
        string userWish = wishInput.text;
        StartCoroutine(MainController.Instance.webRequest.SellItem(userId, userItemType, userWish));
    }

}
