using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplicationManager : MonoBehaviour {
    public static ApplicationManager instance;

    public GameObject Class;
    public GameObject AccessDate;
    public GameObject Name;
    public GameObject Gender;
    public GameObject BirthDay;
    public GameObject PhoneNumber;
    public GameObject Email;
    public GameObject Address;
    public GameObject Teacher;

    private string s_Class;
    private string s_AccessDate;
    private string s_Name;
    private string s_Gender;
    private string s_BirthDay;
    private string s_PhoneNumber;
    private string s_Email;
    private string s_Address;
    private string s_Teacher;

    public Toggle GenderMale;
    public Toggle GenderFemale;

    [SerializeField]
    private string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSelbRVle6kewx6UDYJ2HECcq1VR5Cdo93Dc0ywa8xnm_gVsSg/formResponse";

    public GameObject DrawingObject;
    public GameObject AlphaObject;
    public bool SetSignMode = false;

    public float perspectiveZoomSpeed = 0.1f;        // The rate of change of the field of view in perspective mode.
    public float orthoZoomSpeed = 0.0005f;        // The rate of change of the orthographic size in orthographic mode.
    public float dragSpeed = 0.5f;

    public GameObject scaleObject;
    public float defaultSizeX;
    public float defaultSizeY;

    public float changedSizeX;
    public float changedSizeY;

    public Camera applicationCamera;

    public bool StartAlphaObjectFlag = false;

    public bool ZoomFlg = false;
    public bool DoubleTouchedFlg = false;
    public bool TripleTouchMode = false;

    public Vector3 ScaleObjectDefaultPosition;

    private Touch tempTouchs;

    private Vector2 touchPrevPos;
    private Vector2 touchNextPos;

    public GameObject ErrorMessageText;

    void Awake()
    {
        instance = this;

        SetSignMode = false;
        ZoomFlg = false;
        DrawingObject.SetActive(false);
        AlphaObject.SetActive(false);
        ErrorMessageText.SetActive(false);

        ScaleObjectDefaultPosition = scaleObject.transform.localPosition;
        defaultSizeX = changedSizeX = scaleObject.transform.localScale.x;
        defaultSizeY = changedSizeY = scaleObject.transform.localScale.y;
        Application.targetFrameRate = 30;
    }

	// Use this for initialization
	void Start () {
        Screen.SetResolution(Screen.width, Screen.height, true);

        Debug.Log("Class : " + Class.GetComponent<InputField>().text);
        Debug.Log("Name : " + Name.GetComponent<InputField>().text);

        Debug.Log("BirthDay : " + BirthDay.GetComponent<InputField>().text);
        Debug.Log("PhoneNumber : " + PhoneNumber.GetComponent<InputField>().text);
        Debug.Log("Email : " + Email.GetComponent<InputField>().text);
        Debug.Log("Address : " + Address.GetComponent<InputField>().text);
        Debug.Log("Teacher : " + Teacher.GetComponent<InputField>().text);

        if(Teacher.GetComponent<InputField>().text == "")
        {
            Debug.Log("Teacher NULL");
        }
    }

    IEnumerator StartQuitSquence()
    {
        yield return new WaitForSeconds(2);
        Application.Quit();
    }

    // Update is called once per frame
    void Update ()
    {
        //Screen.SetResolution(1536, 2048, false);

        if (Input.GetKeyUp(KeyCode.Semicolon))
        {
            if (!TripleTouchMode && !SetSignMode && !StartAlphaObjectFlag)
            {
                SendWWWTextForm();
            }
        }

        
        if (Input.touchCount == 1)
        {
            tempTouchs = Input.GetTouch(0);

            if (tempTouchs.phase == TouchPhase.Began && ZoomFlg && !SetSignMode)
            {
                touchPrevPos = tempTouchs.position - tempTouchs.deltaPosition;
            }
                
            if(tempTouchs.phase == TouchPhase.Moved && ZoomFlg && !SetSignMode)
            {
                touchNextPos = tempTouchs.position - tempTouchs.deltaPosition;

                Vector2 calcVector2Position = (touchPrevPos - touchNextPos) * dragSpeed;

                scaleObject.transform.localPosition = new Vector3(scaleObject.transform.localPosition.x + calcVector2Position.x, scaleObject.transform.localPosition.y + calcVector2Position.y, 0);

                if(scaleObject.transform.localPosition.x > 1070)
                {
                    scaleObject.transform.localPosition = new Vector3(1070, scaleObject.transform.localPosition.y, 0);
                }

                if (scaleObject.transform.localPosition.x < -1240)
                {
                    scaleObject.transform.localPosition = new Vector3(-1240, scaleObject.transform.localPosition.y, 0);
                }

                if (scaleObject.transform.localPosition.y < -770)
                {
                    scaleObject.transform.localPosition = new Vector3(scaleObject.transform.localPosition.x, -770, 0);
                }

                if (scaleObject.transform.localPosition.y > 2300)
                {
                    scaleObject.transform.localPosition = new Vector3(scaleObject.transform.localPosition.x, 2300, 0);
                }
            }
        }

        // If there are two touches on the device...
        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            changedSizeX += -deltaMagnitudeDiff * orthoZoomSpeed;
            changedSizeY += -deltaMagnitudeDiff * orthoZoomSpeed;
            if (changedSizeX <= 1)
            {
                changedSizeX = 1;
            }

            if (changedSizeY <= 1)
            {
                changedSizeY = 1;
            }

            if (changedSizeX >= 3)
            {
                changedSizeX = 3;
            }

            if (changedSizeY >= 3)
            {
                changedSizeY = 3;
            }

            scaleObject.transform.localScale = new Vector3(changedSizeX, changedSizeY, scaleObject.transform.localScale.z);


            //if (changedSizeX < defaultSizeX || changedSizeY < defaultSizeY)
            //{
            //    changedSizeX = defaultSizeX;
            //    changedSizeY = defaultSizeY;
            //}

            //if (changedSizeX > 2 || changedSizeY > 2)
            //{
            //    changedSizeX = 2;
            //    changedSizeY = 2;
            //}
        }

        if (Input.touchCount == 3)
        {
            ResetScaleObjectPosition();
        }

    }

    

    public void StartSighMode()
    {
        SetSignMode = true;
        DrawingObject.SetActive(true);

    }

    public void EndSighMode()
    {
        SetSignMode = false;
        DrawingObject.SetActive(false);
    }

    public void ResetScaleObjectPosition()
    {
        scaleObject.transform.localScale = new Vector3(1, 1, scaleObject.transform.localScale.z);
        scaleObject.transform.localPosition = ScaleObjectDefaultPosition;
        ZoomFlg = false;
    }

    IEnumerator Post(string SClass, string AccessDate, string Name, string Gender, string Birthday, string PhoneNumber, string Email, string Address, string Teacher)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.28949401", SClass);
        form.AddField("entry.1152087542", AccessDate);
        form.AddField("entry.809811336", Name);
        form.AddField("entry.387057387", Gender);
        form.AddField("entry.1821707031", Birthday);
        form.AddField("entry.1115046098", PhoneNumber);
        form.AddField("entry.101146246", Email);
        form.AddField("entry.829094402", Address); 
        form.AddField("entry.1311218632", Teacher);
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www;
    }

    public void SendTextForm()
    {
        s_Class = Class.GetComponent<InputField>().text;
        s_AccessDate = AccessDate.GetComponent<Text>().text;
        s_Name = Name.GetComponent<InputField>().text;
        s_Gender = "미정";
        if (GenderMale.isOn)
        {
            s_Gender = "남";
        }
        if (GenderFemale.isOn)
        {
            s_Gender = "여";
        }
        s_BirthDay = BirthDay.GetComponent<InputField>().text;
        s_PhoneNumber = PhoneNumber.GetComponent<InputField>().text;
        s_Email = Email.GetComponent<InputField>().text;
        s_Address = Address.GetComponent<InputField>().text;
        s_Teacher = Teacher.GetComponent<InputField>().text;

        StartCoroutine(Post(s_Class, s_AccessDate, s_Name, s_Gender, s_BirthDay, s_PhoneNumber, s_Email, s_Address, s_Teacher));
    }

    public void StartAlphaObjectSquence()
    {
        AlphaObject.SetActive(true);
        StartAlphaObjectFlag = true;
    }

    public void SendWWWTextForm()
    {

        TripleTouchMode = true;
            
        SendTextForm();
        ResetScaleObjectPosition();
        string fileName = System.DateTime.Now.ToString("yyyy_MM_dd hh_mm_ss") + "_ProfileData" + ".png";
        ScreenCapture.CaptureScreenshot(fileName);
        //StartAlphaObjectSquence();
        StartCoroutine(StartQuitSquence());

    }

}
