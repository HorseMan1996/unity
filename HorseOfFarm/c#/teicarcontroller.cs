using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teicarcontroller : MonoBehaviour
{

    //dashboard
    [SerializeField] GameObject speedstick;
    float speedrotation;
    Quaternion rotationspeed;

    [SerializeField] GameObject redlinestick;
    float redlinerotation;
    Quaternion rotationredline;
    float redline = -30;

    bool startengine = false;

    float minDist = 4;
    public float dist = 5f;
    bool incar = false;

    static GameObject headlights;
    static GameObject rightsignal;
    static GameObject leftsignal;
    static GameObject armright;
    [SerializeField] GameObject leftbrakelights;
    [SerializeField] GameObject rightbrakelights;
    [SerializeField] GameObject reargearlights;

    [SerializeField] GameObject outcharacter;
    [SerializeField] GameObject incharacter;
    [SerializeField] GameObject incharacterhand;
    [SerializeField] GameObject freezecharacter;

    [SerializeField] GameObject gearsticks;

    [SerializeField] Rigidbody carrg;
    [SerializeField] float speed;

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentsteerangle;

    private float currentsteersecond;
    private float currenthandbrake;
    private float currentbreakforce;
    [SerializeField] private float breakforce;
    [SerializeField] private float handbreakforce;
    private bool isbreaking;
    private bool ishandbreaking;

    [SerializeField] private float motorforce;
    [SerializeField] private float maxsteerangle;

    [SerializeField] private GameObject steeringwheel;
    [SerializeField] private Vector3 steeringwheelvector;

    [SerializeField] private WheelCollider frontleftwheelcollider;
    [SerializeField] private WheelCollider frontrightwheelcollider;
    [SerializeField] private WheelCollider rearleftwheelcollider;
    [SerializeField] private WheelCollider rearrightwheelcollider;

    [SerializeField] private Transform frontleftwheeltransform;
    [SerializeField] private Transform frontrightwheeltransform;
    [SerializeField] private Transform rearleftwheeltransform;
    [SerializeField] private Transform rearrightwheeltransform;

    [SerializeField] static private GameObject lightsbtn;
    bool lights = false;

    [SerializeField] private AudioSource incarsound;
    [SerializeField] private AudioSource inkeysound;
    [SerializeField] private AudioSource inkeyturnsound;
    [SerializeField] private AudioSource enginestart;
    [SerializeField] private AudioSource enginesound;
    [SerializeField] private AudioSource handbrakesound;
    [SerializeField] private AudioSource wind1sound;
    [SerializeField] private AudioSource wind2sound;
    [SerializeField] private AudioSource gearup;
    [SerializeField] private AudioSource geardown;
    [SerializeField] private AudioSource accelerationsound;
    [SerializeField] private AudioSource accelerationloopsound;
    [SerializeField] private AudioSource signalsound;
    [SerializeField] private AudioSource enginestop;

    [SerializeField] private AudioSource speaker1;
    [SerializeField] private AudioSource speaker2;
    static public bool radioin = false;
    bool radioon = false;
    static public bool radioscrool = false;
    static public float carsound = 1f;

    int gear = 0;
    bool pushctrl = false;
    bool pushshift = false;

    [SerializeField] int count = 0;

    [SerializeField] private float enginespeed = 0f;

    static public bool signalgive = false;
    static public int forsignal = 1;
    private void Start()
    {
        armright = GameObject.Find("rightarm");
        rightsignal = GameObject.Find("carrightsignallights");
        leftsignal = GameObject.Find("carleftsignallights");
        rightsignal.SetActive(false);
        leftsignal.SetActive(false);
        headlights = GameObject.Find("carheadslights");
        headlights.SetActive(false);
        lightsbtn = GameObject.Find("lightsopen");
    }
    private void Update()
    {
        if (incar)
        {
            GetInput();
            handleMotor();
            handlesteering();
            updatewheels();
            getspeed();
            gearbox();
            controlkey();
            acceleration();
            if (radioin == true)
            {
                radioin = false;
                radioon =! radioon;
                Debug.Log(radioon);
                radio();
            }
            if (radioscrool)
            {
                radioscrool = false;
                radiosound();
            }
            if (signalgive == true)
            {
                StartCoroutine(signallights());
            }
            //headlightsopen();
            outcharacter.transform.position = freezecharacter.transform.position;
            if (Input.GetMouseButtonDown(1))
            {
                getoutcar();
            }
        }
    }
    private void OnMouseOver()
    {
        if (!incar)
        {
            dist = Vector3.Distance(outcharacter.transform.position, this.gameObject.transform.position);
            if (dist < minDist)
            {
                usepanelactive.takepanel.SetActive(true);
                usepanelactive.whichobject.text = "My Car";
                if (Input.GetMouseButtonDown(0))
                {
                    getincar();
                }
                if (Input.GetMouseButtonDown(2) && !incar)
                {
                    this.gameObject.transform.position = incharacterhand.transform.position;
                    this.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                }
            }
            else
            {
                usepanelactive.takepanel.SetActive(false);
                usepanelactive.whichobject.text = "";
            }
        }
    }
    private void OnMouseExit()
    {
        usepanelactive.takepanel.SetActive(false);
    }
    private void radiosound()
    {
        speaker1.volume = carsound;
       // speaker2.volume = carsound;
    }
    private void radio()
    {
        if (radioon)
        {
            speaker1.Play();
            //speaker2.Play();
        }
        else if (!radioon)
        {
            speaker1.Pause();
            //speaker2.Pause();
        }
    }
    private void acceleration()
    {
        /*accelerationsound.volume = enginespeed;
        if (startengine)
        {
            if (gear == 0)
            {
                //accelerationsound.Play();
                if (verticalInput > 0 && enginespeed <= 1f)
                {
                    enginespeed = enginespeed + 0.01f;
                }
                if (verticalInput == 0 && enginespeed >= 0f)
                {
                    enginespeed = enginespeed - 0.01f;
                }
            }
            if (gear == 1)
            {

            }
        }*/
    }
    private void controlkey()
    {
        if (Input.GetKeyDown(KeyCode.E) && !startengine)
        {
            StartCoroutine(startengines());
        }
        else if (Input.GetKeyDown(KeyCode.E) && startengine)
        {
            enginesound.Stop();
            enginestop.Play();
            startengine = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            handbrakesound.Play();
        }
    }
    private IEnumerator startengines()
    {
        enginestart.Play();
        yield return new WaitForSecondsRealtime(2f);
        enginesound.Play();
        startengine = true;
    }
    static public void headlightsopen()
    {
        if (headlights.activeSelf)
        {
            lightsbtn.transform.localPosition = lightsbtn.transform.localPosition - new Vector3(0f, 0f, 0.02f);
            headlights.SetActive(false);
        }
        else
        {
            lightsbtn.transform.localPosition = lightsbtn.transform.localPosition + new Vector3(0f, 0f, 0.02f);
            headlights.SetActive(true);
        }
    }
    public IEnumerator signallights()
    {
        signalgive = false;
        if (forsignal == 0)
        {
            signalsound.Play();
            armright.transform.localEulerAngles = new Vector3(0f, -0f, 13.863f);
            leftsignal.SetActive(true);
            yield return new WaitForSecondsRealtime(0.4f);
            leftsignal.SetActive(false);
            yield return new WaitForSecondsRealtime(0.4f);
            StartCoroutine(signallights());
        }
        else if (forsignal == 1)
        {
            forsignal = 3;
            armright.transform.localEulerAngles = new Vector3(0f, -0f, 11.416f);
            leftsignal.SetActive(false);
            rightsignal.SetActive(false);
            signalsound.Stop();
        }
        else if (forsignal == 2)
        {
            signalsound.Play();
            armright.transform.localEulerAngles = new Vector3(0f, -0f, 7.61f);
            rightsignal.SetActive(true);
            yield return new WaitForSecondsRealtime(0.4f);
            rightsignal.SetActive(false);
            yield return new WaitForSecondsRealtime(0.4f);
            StartCoroutine(signallights());
        }
    }
    private void gearbox()
    {
        if (incar)
        {

                if (Input.GetKeyUp(KeyCode.LeftControl))
                {
                pushctrl = true;
                    if (gear == 0)
                    {
                    gearsticks.transform.localEulerAngles = new Vector3(-10f, 0f, -10f);
                    pushctrl = false;
                        geardown.Play();
                        gear = -1;
                    }
                    else if (gear == 1)
                    {
                    gearsticks.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                    pushctrl = false;
                        geardown.Play();
                        gear = 0;
                    }
                    else if (gear == 2)
                    {
                    gearsticks.transform.localEulerAngles = new Vector3(-9f, 0f, 9f);
                    pushctrl = false;
                        geardown.Play();
                        gear = 1;
                    }
                    else if (gear == 3)
                    {
                    gearsticks.transform.localEulerAngles = new Vector3(-9f, 0f, 9f);
                    pushctrl = false;
                        geardown.Play();
                        gear = 2;
                    }
                    else if (gear == 4)
                    {
                    gearsticks.transform.localEulerAngles = new Vector3(9f, 0f, 0f);
                    pushctrl = false;
                        geardown.Play();
                        gear = 3;
                    }
                    else if (gear == 5)
                    {
                    gearsticks.transform.localEulerAngles = new Vector3(-9f, 0f, 0f);
                    pushctrl = false;
                        geardown.Play();
                        gear = 4;
                    }
                }
                else if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                pushshift = true;
                    if (gear == 4)
                    {
                    gearsticks.transform.localEulerAngles = new Vector3(9f, 0f, -9f);
                    pushshift = false;
                    gearup.Play();
                        gear = 5;
                    }
                    else if (gear == 3)
                {
                    gearsticks.transform.localEulerAngles = new Vector3(-9f, 0f, 0f);
                    pushshift = false;
                    gearup.Play();
                    gear = 4;
                    }
                    else if (gear == 2)
                {
                    gearsticks.transform.localEulerAngles = new Vector3(9f, 0f, 0f);
                    pushshift = false;
                    gearup.Play();
                    gear = 3;
                    }
                    else if (gear == 1)
                {
                    gearsticks.transform.localEulerAngles = new Vector3(-9f, 0f, 9f);
                    pushshift = false;
                    gearup.Play();
                    gear = 2;
                    }
                    else if (gear == 0)
                {
                    gearsticks.transform.localEulerAngles = new Vector3(9f, 0f, 9f);
                    pushshift = false;
                    gearup.Play();
                    gear = 1;
                    }
                    else if (gear == -1)
                {
                    gearsticks.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
                    pushshift = false;
                    gearup.Play();
                    gear = 0;
                    }
                }
            
           // Debug.Log(gear);

        }
    }
    private void getspeed()
    {
        speed = carrg.velocity.magnitude * 3.6f;

        //enginesound.volume = speed / 70f;
        wind1sound.volume = speed / 150f;
        wind2sound.volume = speed / 150f;

        speedrotation = speed - 40f;
        rotationspeed = Quaternion.AngleAxis (-speedrotation,new Vector3(0f,0f,1f));
        speedstick.transform.localRotation = rotationspeed;

        if (startengine)
        {
            if (gear == 0)
            {
                if (verticalInput > 0 && redline < 106f)
                {
                    redline = redline + 2f;
                }
                if (verticalInput <= 0 && redline > 0f)
                {
                    redline = redline - 1f;
                }
            }
            else if (gear == -1)
            {
                redline = speed * 3.5f;
            }
            else if (gear == 1)
            {
                    redline = speed * 3.5f;
            }
            else if (gear == 2)
            {
                    redline = speed * 2.12f;
            }
            else if (gear == 3)
            {
                redline = speed * 1.17f;
            }
            else if (gear == 4)
            {
                redline = speed * 0.75f;
            }
            else if (gear == 5)
            {
                redline = speed * 0.50f;
            }
            rotationredline = Quaternion.AngleAxis(-redline + 30, new Vector3(0f, 0f, 1f));
            redlinestick.transform.localRotation = rotationredline;

            Debug.Log(redline);
            enginesound.volume = (redline/100) + 0.3f;
        }
    }
    private void getoutcar()
    {
        if (speed <= 0.1f && speed >= -0.1)
        {
            incar = false;
            incarsound.Play();
            incharacter.SetActive(false);
            outcharacter.SetActive(true);
            outcharacter.transform.position = this.transform.position - new Vector3(2f, 0f, 0f);
        }
    }
    private void updatewheels()
    {
        UpdateSingleWheel(frontleftwheelcollider, frontleftwheeltransform);
        UpdateSingleWheel(frontrightwheelcollider, frontrightwheeltransform);
        UpdateSingleWheel(rearleftwheelcollider, rearleftwheeltransform);
        UpdateSingleWheel(rearrightwheelcollider, rearrightwheeltransform);
    }
    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheeltransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheeltransform.rotation = rot;
        wheeltransform.position = pos;
    }
    private void handlesteering()
    {
        currentsteerangle = maxsteerangle * horizontalInput;
        frontleftwheelcollider.steerAngle = currentsteerangle;
        frontrightwheelcollider.steerAngle = currentsteerangle;

        if (horizontalInput != 0 && count < 90)
        {
            count++; 
            steeringwheelvector = new Vector3(0f, currentsteerangle * 7, 0f);
            steeringwheel.transform.Rotate(steeringwheelvector * Time.deltaTime);
            currentsteersecond = currentsteerangle;
        }
        if(horizontalInput == 0 && count > 0)
        {
            count--;
            steeringwheelvector = new Vector3(0f, -currentsteersecond * 14, 0f);
            steeringwheel.transform.Rotate(steeringwheelvector * Time.deltaTime);
        }
        

        /*if (horizontalInput == 0)
        {
            count = 0;
            steeringwheel.transform.localEulerAngles = new Vector3(-72.169f, -33.592f, 32.305f);
        }*/
        /*if (horizontalInput < 0)
        {
            if (currentsteerangle * 7 > -210)
            {
                steeringwheelvector = new Vector3(0f, currentsteerangle * 7, 0f);
                steeringwheel.transform.Rotate(steeringwheelvector * Time.deltaTime);
            }
            if (horizontalInput == 0)
            {
                    steeringwheelvector = new Vector3(0f, -currentsteerangle * 7, 0f);
                    steeringwheel.transform.Rotate(steeringwheelvector * Time.deltaTime);
            }
        }
        if(horizontalInput > 0)
        {
            if (currentsteerangle * 7 > 210)
            {
                steeringwheelvector = new Vector3(0f, -currentsteerangle * 7, 0f);
                steeringwheel.transform.Rotate(steeringwheelvector * Time.deltaTime);
            }
            if (horizontalInput == 0)
            {
                steeringwheelvector = new Vector3(0f, currentsteerangle * 7, 0f);
                steeringwheel.transform.Rotate(steeringwheelvector * Time.deltaTime);
            }
        }*/


    }
    private void handleMotor()
    {
        if (startengine)
        {
            Debug.Log(gear);
            if (gear >= 0)
            {
                reargearlights.SetActive(false);
                if (gear == 0)
                {
                    frontleftwheelcollider.motorTorque = verticalInput * 0f;
                    frontrightwheelcollider.motorTorque = verticalInput * 0f;
                }
                else if (gear == 1)
                {
                    if (speed < 30f)
                    {
                        frontleftwheelcollider.motorTorque = verticalInput * motorforce;
                        frontrightwheelcollider.motorTorque = verticalInput * motorforce;
                    }
                    else
                    {
                        frontleftwheelcollider.motorTorque = 0f;
                        frontrightwheelcollider.motorTorque = 0f;
                    }
                }
                else if (gear == 2)
                {
                    if (speed > 20f && speed <= 50f)
                    {
                        frontleftwheelcollider.motorTorque = verticalInput * motorforce;
                        frontrightwheelcollider.motorTorque = verticalInput * motorforce;
                    }
                    else if (speed <= 20f)
                    {
                        frontleftwheelcollider.motorTorque = verticalInput * motorforce/1.5f;
                        frontrightwheelcollider.motorTorque = verticalInput * motorforce/1.5f;
                    }
                    else
                    {
                        frontleftwheelcollider.motorTorque = 0f;
                        frontrightwheelcollider.motorTorque = 0f;
                    }
                }
                else if (gear == 3)
                {
                    if (speed > 50f && speed <= 90f)
                    {
                        frontleftwheelcollider.motorTorque = verticalInput * motorforce;
                        frontrightwheelcollider.motorTorque = verticalInput * motorforce;
                    }
                    else if (speed <= 20f)
                    {
                        frontleftwheelcollider.motorTorque = verticalInput * motorforce / 3f;
                        frontrightwheelcollider.motorTorque = verticalInput * motorforce / 3f;
                    }
                    else if (speed >= 20f && speed <= 50)
                    {
                        frontleftwheelcollider.motorTorque = verticalInput * motorforce / 1.5f;
                        frontrightwheelcollider.motorTorque = verticalInput * motorforce / 1.5f;
                    }
                    else
                    {
                        frontleftwheelcollider.motorTorque = 0f;
                        frontrightwheelcollider.motorTorque = 0f;
                    }
                }
                else if (gear == 4)
                {
                    if (speed > 90f && speed <= 140f)
                    {
                        frontleftwheelcollider.motorTorque = verticalInput * motorforce;
                        frontrightwheelcollider.motorTorque = verticalInput * motorforce;
                    }
                    else if (speed <= 20f)
                    {
                        frontleftwheelcollider.motorTorque = verticalInput * motorforce / 5f;
                        frontrightwheelcollider.motorTorque = verticalInput * motorforce / 5f;
                    }
                    else if (speed >= 20f && speed <= 50)
                    {
                        frontleftwheelcollider.motorTorque = verticalInput * motorforce / 3f;
                        frontrightwheelcollider.motorTorque = verticalInput * motorforce / 3f;
                    }
                    else if (speed >= 50f && speed <= 90)
                    {
                        frontleftwheelcollider.motorTorque = verticalInput * motorforce / 1.5f;
                        frontrightwheelcollider.motorTorque = verticalInput * motorforce / 1.5f;
                    }
                    else
                    {
                        frontleftwheelcollider.motorTorque = 0f;
                        frontrightwheelcollider.motorTorque = 0f;
                    }
                }
                else if (gear == 5)
                {
                    if (speed >= 200)
                    {
                        frontleftwheelcollider.motorTorque = verticalInput * motorforce / 2f;
                        frontrightwheelcollider.motorTorque = verticalInput * motorforce / 2f;
                    }
                    else if (speed > 140f && speed <= 200f)
                    {
                        frontleftwheelcollider.motorTorque = verticalInput * motorforce;
                        frontrightwheelcollider.motorTorque = verticalInput * motorforce;
                    }
                    else if (speed <= 20f)
                    {
                        frontleftwheelcollider.motorTorque = verticalInput * motorforce / 8f;
                        frontrightwheelcollider.motorTorque = verticalInput * motorforce / 8f;
                    }
                    else if (speed >= 20f && speed <= 50)
                    {
                        frontleftwheelcollider.motorTorque = verticalInput * motorforce / 5f;
                        frontrightwheelcollider.motorTorque = verticalInput * motorforce / 5f;
                    }
                    else if (speed >= 50f && speed <= 90)
                    {
                        frontleftwheelcollider.motorTorque = verticalInput * motorforce / 3f;
                        frontrightwheelcollider.motorTorque = verticalInput * motorforce / 3f;
                    }
                    else if (speed >= 90f && speed <= 140)
                    {
                        frontleftwheelcollider.motorTorque = verticalInput * motorforce / 1.5f;
                        frontrightwheelcollider.motorTorque = verticalInput * motorforce / 1.5f;
                    }
                    else
                    {
                        frontleftwheelcollider.motorTorque = 0f;
                        frontrightwheelcollider.motorTorque = 0f;
                    }
                }
                else
                {

                }
            }

            else if (gear < 0)
            {
                reargearlights.SetActive(true);
                if (speed < 30f)
                {
                    frontleftwheelcollider.motorTorque = -verticalInput * motorforce;
                    frontrightwheelcollider.motorTorque = -verticalInput * motorforce;
                }
            }
            currenthandbrake = ishandbreaking ? handbreakforce : 0f;
            applyhandbreaking();
            currentbreakforce = isbreaking ? breakforce : 0f;
            applybreaking();
        }
    }
    private void applyhandbreaking()
    {
        rearleftwheelcollider.brakeTorque = currenthandbrake;
        rearrightwheelcollider.brakeTorque = currenthandbrake;
    }
    private void applybreaking()
    {
        frontleftwheelcollider.brakeTorque = currentbreakforce;
        frontrightwheelcollider.brakeTorque = currentbreakforce;
        rearleftwheelcollider.brakeTorque = currentbreakforce;
        rearrightwheelcollider.brakeTorque = currentbreakforce;
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);


        if (verticalInput >= 0)
        {
            leftbrakelights.SetActive(false);
            rightbrakelights.SetActive(false);
            isbreaking = false;
        }
        if (verticalInput < 0)
        {
            leftbrakelights.SetActive(true);
            rightbrakelights.SetActive(true);
            isbreaking = true;
        }

        ishandbreaking = Input.GetKey(KeyCode.Space);
    }
   /* private void OnMouseOver()
    {
        dist = Vector3.Distance(outcharacter.transform.position, this.gameObject.transform.position);
        if (dist < minDist && !incar)
        {
            usepanelactive.takepanel.SetActive(true);
            usepanelactive.whichobject.text = "My Car";
        }
        else
        {
            usepanelactive.takepanel.SetActive(false);
            usepanelactive.whichobject.text = "";
        }
    }
    private void OnMouseExit()
    {
        usepanelactive.takepanel.SetActive(false);
        usepanelactive.whichobject.text = "";
    }
    private void OnMouseDown()
    {
        if (!incar)
        {
            dist = Vector3.Distance(outcharacter.transform.position, this.gameObject.transform.position);
            if (dist < minDist)
            {
                usepanelactive.takepanel.SetActive(false);
                usepanelactive.whichobject.text = "";
                incharacter.SetActive(true);
                outcharacter.SetActive(false);
                incar = true;
            }
        }
    }*/
   private void getincar()
    {
        incarsound.Play();
        usepanelactive.takepanel.SetActive(false);
        usepanelactive.whichobject.text = "";
        incharacter.SetActive(true);
        outcharacter.SetActive(false);
        incar = true;
    }
}
