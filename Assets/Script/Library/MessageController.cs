using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageController : MonoBehaviour
{
    private AndroidJavaObject currentActivity;
    private AndroidJavaClass unityPlayer;
    private AndroidJavaObject context;
    private AndroidJavaClass Toast;
    private AndroidJavaObject javaString;
    private AndroidJavaObject makeToast;
    private string messageText;
    private bool longDuration;

    public void Show(string messageTextInput = "", bool longDurationInput = false)
    {
        messageText = messageTextInput;
        longDuration = longDurationInput;
        if (Application.platform == RuntimePlatform.Android)
        {
            unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
            currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(AndroidToastShow));
        }
        else
        {
            Debug.Log(messageText);
        }
    }

    void AndroidToastShow()
    {
        string duration = "LENGTH_SHORT";
        if (longDuration)
        {
            duration = "LENGTH_LONG";
        }
        Toast = new AndroidJavaClass("android.widget.Toast");
        javaString = new AndroidJavaObject("java.lang.String", messageText);
        makeToast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>(duration));
        makeToast.Call("show");
    }

    public void AndroidToastCancel()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (makeToast != null)
            {
                makeToast.Call("cancel");
            }
        }
    }
}
