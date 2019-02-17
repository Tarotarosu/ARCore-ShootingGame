using System.Collections.Generic;
using GoogleARCore;
using GoogleARCore.Examples.Common;
using UnityEngine;

#if UNITY_EDITOR
    using Input = GoogleARCore.InstantPreviewInput;
#endif

public class NewGameController : MonoBehaviour
{

    public Camera FirstPersonCamera;

    public List<GameObject> ball_list = new List<GameObject>();
    public GameObject ball;

    private const float k_ModelRotation = 180.0f;

    private bool m_IsQuitting = false;

    public int score;


    public void Update()
    {
        _UpdateApplicationLifecycle();

        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        GameObject shoot = GameObject.Instantiate(ball, FirstPersonCamera.transform.TransformPoint(0, 0, 0.5f), Quaternion.identity);
        //GameObject ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //ball.transform.position = FirstPersonCamera.transform.TransformPoint(0,0,0.5f);
        //ball.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        //ball.AddComponent<Rigidbody>();
        //ball.GetComponent<Rigidbody>().useGravity = false;
        shoot.GetComponent<Rigidbody>().AddForce(FirstPersonCamera.transform.TransformDirection(0, 0, 10.0f), ForceMode.Impulse);
        ball_list.Add(ball);
   
    }

    private void _UpdateApplicationLifecycle()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Session.Status != SessionStatus.Tracking)
        {
            const int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;
        }
        else
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        if (m_IsQuitting)
        {
            return;
        }
        if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
        {
            _ShowAndroidToastMessage("Camera permission is needed to run this application.");
            m_IsQuitting = true;
            Invoke("_DoQuit", 0.5f);
        }
        else if (Session.Status.IsError())
        {
            _ShowAndroidToastMessage("ARCore encountered a problem connecting.  Please start the app again.");
            m_IsQuitting = true;
            Invoke("_DoQuit", 0.5f);
        }
    }

    private void _DoQuit()
    {
        Application.Quit();
    }
    private void _ShowAndroidToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity,
                    message, 0);
                toastObject.Call("show");
            }));
        }
    }

    public void SetScore(int score)
    {
        this.score += score;
    }
    public int GetScore()
    {
        return this.score;
    }

}

