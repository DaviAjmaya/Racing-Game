using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarColor : MonoBehaviour {
    public static Color bodyColor, wheelsColor, interiorColor;
    Text txt;
    Renderer body, body2, body3, interior;
    Renderer[] wheels;
    string toastString;
    AndroidJavaObject currentActivity;

    // Use this for initialization
    void Start () {
        body = GameObject.Find("SkyCarBody").GetComponent<Renderer>();
        body2 = GameObject.Find("SkyCarMudGuardFrontLeft").GetComponent<Renderer>();
        body3 = GameObject.Find("SkyCarMudGuardFrontRight").GetComponent<Renderer>();
        body.material.color = bodyColor;
        body2.material.color = bodyColor;

        wheels = new Renderer[4];
        wheels[0] = GameObject.Find("SkyCarWheelFrontLeft").GetComponent<Renderer>();
        wheels[1] = GameObject.Find("SkyCarWheelFrontRight").GetComponent<Renderer>();
        wheels[2] = GameObject.Find("SkyCarWheelRearLeft").GetComponent<Renderer>();
        wheels[3] = GameObject.Find("SkyCarWheelRearRight").GetComponent<Renderer>();
        for (int i = 0; i < 4; i++)
        {
            wheels[i].material.color = wheelsColor;
        }
        interior = GameObject.Find("SkyCarComponents").GetComponent<Renderer>();
        if (interiorColor.a != 0)
        {
            interior.materials[0].color = interiorColor;
        }


    }
    public void SetColor(Color color)
    {
        txt = GameObject.Find("ScrollText").GetComponent<Text>();
         
        if (txt.text.ToString() == "Body" && body != null && body2 != null)
        {
            bodyColor = color;
            body.material.color = bodyColor;
            body2.material.color = bodyColor;
            body3.material.color = bodyColor;
        }
        else if (txt.text.ToString() == "Interior" && interior.materials[0] != null)
        {
            interiorColor = color;
            interior.materials[0].color = interiorColor;
        }
        else if (txt.text.ToString() == "Wheels" && wheels != null)
        {
            wheelsColor = color;
            for (int i = 0; i < 4; i++)
            {
                wheels[i].material.color = wheelsColor;
            }
        }
        
    }

    public void SetColor1(Color color,string text)
    {
        string part = text;

        if (part== "Body")
        {
            bodyColor = color;
            body.material.color = bodyColor;
            body2.material.color = bodyColor;
            body3.material.color = bodyColor;
        }
        else if (part== "Interior")
        {
            interiorColor = color;
            interior.materials[0].color = interiorColor;
        }
        else if (part == "Wheels")
        {
            wheelsColor = color;
            for (int i = 0; i < 4; i++)
            {
                wheels[i].material.color = wheelsColor;
            }
        }

    }

    public void SaveColor1()
    {
        PlayerPrefsX.SetColor("colorbody", bodyColor);
        PlayerPrefsX.SetColor("colorinterior", interiorColor);
        PlayerPrefsX.SetColor("colorwheels", wheelsColor);

        PlayerPrefs.Save();

        MyShowToastMethod("Your color has been saved!");
        

    }

    public void SaveColor2()
    {
        PlayerPrefsX.SetColor("colorbody1", bodyColor);
        PlayerPrefsX.SetColor("colorinterior1", interiorColor);
        PlayerPrefsX.SetColor("colorwheels1", wheelsColor);

        PlayerPrefs.Save();

        MyShowToastMethod("Your color has been saved!");
    }
	// Update is called once per frame
	void Update () {
		
	}

    public void Color1()
    {
        SetColor1(PlayerPrefsX.GetColor("colorbody"),"Body");
        if (PlayerPrefsX.GetColor("colorinterior").a != 0)
        {
            SetColor1(PlayerPrefsX.GetColor("colorinterior"), "Interior");
        }
        SetColor1(PlayerPrefsX.GetColor("colorwheels"), "Wheels");
    }

    public void Color2()
    {
        SetColor1(PlayerPrefsX.GetColor("colorbody1"), "Body");
        if (PlayerPrefsX.GetColor("colorinterior1").a != 0)
        {
            SetColor1(PlayerPrefsX.GetColor("colorinterior1"), "Interior");
        }
        SetColor1(PlayerPrefsX.GetColor("colorwheels1"), "Wheels");
    }

    public void MyShowToastMethod(string message)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            showToastOnUiThread(message);
        }
    }

    void showToastOnUiThread(string toastString)
    {
        AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        this.toastString = toastString;

        currentActivity.Call("runOnUiThread", new AndroidJavaRunnable(showToast));
    }

    void showToast()
    {
        Debug.Log("Running on UI thread");
        AndroidJavaObject context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
        AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");
        AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", toastString);
        AndroidJavaObject toast = Toast.CallStatic<AndroidJavaObject>("makeText", context, javaString, Toast.GetStatic<int>("LENGTH_SHORT"));
        toast.Call("show");
    }
}
