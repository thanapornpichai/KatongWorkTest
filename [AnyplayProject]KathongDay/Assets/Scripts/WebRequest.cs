using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class WebRequest : MonoBehaviour
{
    [SerializeField]
    GameObject popUpPanel, errorPanel, nomoneyText, doneText;
    void Start()
    {
        string userNameTest = "test2";
        StartCoroutine(Login(userNameTest));
        StartCoroutine(GetUsers(userNameTest));
        StartCoroutine(GetFriends(userNameTest));
        //StartCoroutine(RegisterUser("test3","user003"));
    }

    public IEnumerator GetUsers(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", userid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityTest/GetUser.php", form))
        {

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                //Debug.Log(www.downloadHandler.text);
                string fbname = MainController.Instance.userInfo.FBname;
                fbname = www.downloadHandler.text;
                MainController.Instance.userInfo.SetFBName(fbname);
            }
        }
    }

    IEnumerator Login(string userid)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUserID", userid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityTest/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                MainController.Instance.userInfo.SetCredentials(userid);
                MainController.Instance.userInfo.SetID(www.downloadHandler.text);

                if(www.downloadHandler.text.Contains("Wrong Credentials.") || www.downloadHandler.text.Contains("UserID does not exists"))
                {
                    Debug.Log("Try Again");
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                }
            }
        }
    }

        IEnumerator RegisterUser(string userid,string fbname)
        {
            WWWForm form = new WWWForm();
            form.AddField("loginUserID", userid);
            form.AddField("loginfbname", fbname);

            using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityTest/RegisterUser.php", form))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                }
            }
        }

    public IEnumerator GetItemsIDs(string userID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", userID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityTest/GetItemsIDs.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;

                callback(jsonArray);

                //Call callback function to pass results
            }
        }
    }

    public IEnumerator GetItem(string itemID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("itemID", itemID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityTest/GetItem.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;

                callback(jsonArray);

                //Call callback function to pass results
            }
        }
    }

    public IEnumerator SellItem(string userID, string itemID, string wishes)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", userID);
        form.AddField("itemID", itemID);
        form.AddField("wishes", wishes);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityTest/SellItem.php", form))
        {
            yield return www.Send();

            if (www.downloadHandler.text.Contains("already free."))
            {
                popUpPanel.SetActive(true);
                errorPanel.SetActive(true);
                doneText.SetActive(true);
            }
            else if (www.downloadHandler.text.Contains("no money."))
            {
                popUpPanel.SetActive(true);
                errorPanel.SetActive(true);
                nomoneyText.SetActive(true);
            }
            else
            {
                FindObjectOfType<KatongSelect>().PurcheaseKatong();
                FindObjectOfType<MainController>().LoyKatong();
                FindObjectOfType<MainController>().CloseNoti();
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator GetFriends(string userID)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", userID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityTest/GetFriends.php", form))
        {

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string friendid = www.downloadHandler.text;
                MainController.Instance.userInfo.SetFriend(friendid);
            }
        }
    }

    public IEnumerator GetFriendName(string freindid)
    {
        WWWForm form = new WWWForm();
        form.AddField("userid", freindid);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityTest/GetUser.php", form))
        {

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string friendname = www.downloadHandler.text;
                MainController.Instance.userInfo.SetFriendName(friendname);
            }
        }
    }


}