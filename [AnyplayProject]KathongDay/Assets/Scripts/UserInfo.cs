using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public string UserID { get; private set; }
    public string FBname { get; private set; }
    string coins;
    string cash;

    public string FriendID { get; private set; }
    public string FriendName { get; private set; }

    public void SetCredentials(string userid)
    {
        userid = UserID;
    }

    public void SetID(string id)
    {
        UserID = id;
    }

    public void SetFBName(string fbname)
    {
        FBname = fbname;
    }

    public void SetFriend(string friendid)
    {
        FriendID = friendid;
    }

    public void SetFriendName(string friendname)
    {
        FriendName = friendname;
    }
}
