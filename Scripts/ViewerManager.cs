using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewerManager : MonoBehaviour
{

    public List<GameObject> monsters;

    public GameObject selectedMonster;

    private List<GameObject> monsterPieces;

    public GameObject prefabButton;
    public RectTransform ParentPanel;
    public GameObject prefabText;

    public GameObject viewerParent;

    // Use this for initialization
    void Start()
    {
        loadMonsterList();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void loadMonsterList()
    {
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

    void MosterButtonClicked(int buttonNo)
    {
        selectedMonster = Instantiate(monsters[buttonNo], viewerParent.transform.position, transform.rotation);
        //selectedMonster.SetActive(true);
        /*if (selectedMonster != null)
        {
            removeChild(ParentPanel);
            loadComponents();
        }*/
    }
}
