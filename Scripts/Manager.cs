using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public List<GameObject> monsters;

    public GameObject selectedMonster;

    private List<GameObject> monsterPieces;

    public GameObject prefabButton;
    public RectTransform ParentPanel;
    public GameObject prefabText;

    private Color startcolor;

    public bool uiOpened = false;

    public Camera mainCam;

    public bool overUI = false;

    // Use this for initialization
    void Start()
    {
        loadMonsterList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadComponents()
    {
        if (selectedMonster != null)
        {
            int pieces = selectedMonster.transform.childCount;
            Debug.Log("Number of Children are: " + pieces);
            for (int i = 0; i < pieces; i++)
            {
                GameObject goButton = (GameObject)Instantiate(prefabButton);
                goButton.transform.SetParent(ParentPanel, false);
                goButton.transform.localScale = new Vector3(1, 1, 1);

                Button tempButton = goButton.GetComponent<Button>();
                tempButton.GetComponentInChildren<Text>().text = selectedMonster.transform.GetChild(i).name;
                int tempInt = i;

                tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
            }
        }

        GameObject backButton = (GameObject)Instantiate(prefabButton);
        backButton.transform.SetParent(ParentPanel, false);
        backButton.transform.localScale = new Vector3(1, 1, 1);

        Button bkButton = backButton.GetComponent<Button>();
        bkButton.GetComponentInChildren<Text>().text = "Return";
        int bkButInt = 1161;//Hardcoded for the moment

        bkButton.onClick.AddListener(() => ButtonClicked(bkButInt));
    }

    void MosterButtonClicked(int buttonNo)
    {
        selectedMonster = monsters[buttonNo];
        selectedMonster.SetActive(true);
        /*switch (buttonNo)
        {
            case 0:
                selectedMonster = monsters[0];
                selectedMonster.SetActive(true);
                break;
            case 1:
                selectedMonster = monsters[1];
                selectedMonster.SetActive(true);
                break;
            case 2:
                selectedMonster = monsters[2];
                selectedMonster.SetActive(true);
                break;
            case 3:
                selectedMonster = monsters[3];
                selectedMonster.SetActive(true);
                break;
            default:
                Debug.Log("How the hell this you reach here?");
                break;
        }*/
        if(selectedMonster != null)
        {
            removeChild(ParentPanel);
            loadComponents();
        }
        


    }

    void ButtonClicked(int buttonNo)
    {
        if (buttonNo < 1160)
        {
            Color partColour = selectedMonster.transform.GetChild(buttonNo).GetComponent<Renderer>().material.color;
            if (partColour != Color.yellow) { startcolor = partColour; }//Hardcoded = bad bad

            if(startcolor != null)
            {
                returnAllToStartColour(selectedMonster);
            }

            if (partColour != Color.yellow)
            {
                selectedMonster.transform.GetChild(buttonNo).GetComponent<Renderer>().material.color = Color.yellow;
            }

            uiOpened = true;
        }
        else
        {
            if(buttonNo > 1161)
            {
                removeChild(ParentPanel);
                loadComponents();
            }
            else
            {
                removeChild(ParentPanel);
                selectedMonster.SetActive(false);
                loadMonsterList();
            }
            mainCam.fieldOfView = mainCam.GetComponent<ZoomFOV>().defaultFov;
        }
    }

    public Rect windowRect = new Rect(20, 20, 800, 800);//Don't se
    void OnGUI()
    {
        if (uiOpened)
        {
            windowRect = GUI.Window(0, windowRect, DoMyWindow, "");//Draws UI Window
        }
    }

    void DoMyWindow(int windowID)//Different tabs on the UI
    {
        if (GUI.Button(new Rect(305, 20, 100, 20), "X"))
        {
            uiOpened = false;
            returnAllToStartColour(selectedMonster);
        }
    }

    void loadMonsterList()
    {
        Debug.Log("LoadMonsterList() is running");
        ParentPanel.transform.position = new Vector3(0F, 0F, 0F);//Resets the scroll bar
        int monsterSize = monsters.Capacity;
        for (int i = 0; i < monsterSize; i++)
        {
            GameObject goButton = (GameObject)Instantiate(prefabButton);
            goButton.transform.SetParent(ParentPanel, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);

            Button tempButton = goButton.GetComponent<Button>();
            tempButton.GetComponentInChildren<Text>().text = monsters[i].name;
            int tempInt = i;

            tempButton.onClick.AddListener(() => MosterButtonClicked(tempInt));


        }
    }

    void populateInfo(int num)
    {
        GameObject titleText = (GameObject)Instantiate(prefabText);
        titleText.transform.SetParent(ParentPanel, false);
        titleText.transform.localScale = new Vector3(1, 1, 1);

        Text headingTxt = titleText.GetComponent<Text>();
        headingTxt.text = selectedMonster.transform.GetChild(num).name;

        GameObject bodyText = (GameObject)Instantiate(prefabText);
        bodyText.transform.SetParent(ParentPanel, false);
        bodyText.transform.localScale = new Vector3(1, 1, 1);

        Text bodyTxt = titleText.GetComponent<Text>();
        bodyTxt.text = "I'm just some random text!!";



        GameObject backButton = (GameObject)Instantiate(prefabButton);
        backButton.transform.SetParent(ParentPanel, false);
        backButton.transform.localScale = new Vector3(1, 1, 1);

        Button bkButton = backButton.GetComponent<Button>();
        bkButton.GetComponentInChildren<Text>().text = "Return";
        int bkButInt = 1162;//Hardcoded for the moment

        bkButton.onClick.AddListener(() => ButtonClicked(bkButInt));

    }

    void removeChild(RectTransform parent)
    {
        for (int i = parent.transform.childCount - 1; i >= 0; i--)
        {
            // objectA is not the attached GameObject, so you can do all your checks with it.
            Transform child = parent.transform.GetChild(i);
            child.transform.parent = null;
            // Optionally destroy the objectA if not longer needed
            Destroy(child.gameObject);
        }
    }

    void returnAllToStartColour(GameObject monster)
    {
        for (int i = monster.transform.childCount - 1; i >= 0; i--)
        {
            Transform child = monster.transform.GetChild(i);
            selectedMonster.transform.GetChild(i).GetComponent<Renderer>().material.color = startcolor;
        }
    }

    void toggleOpen(bool open)
    {
        if(open == true)
        {
            open = false;
        }
        else
        {
            open = true;
        }
    }

}
