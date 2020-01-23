using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LambdaButtons : MonoBehaviour
{

    public GameObject prefabButton;
    public RectTransform ParentPanel;

    // Use this for initialization
    void Start()
    {

        for (int i = 0; i < 5; i++)
        {
            GameObject goButton = (GameObject)Instantiate(prefabButton);
            goButton.transform.SetParent(ParentPanel, false);
            goButton.transform.localScale = new Vector3(1, 1, 1);

            Button tempButton = goButton.GetComponent<Button>();
            int tempInt = i;

            tempButton.onClick.AddListener(() => ButtonClicked(tempInt));
        }


    }

    void ButtonClicked(int buttonNo)
    {
        Debug.Log("Button clicked = " + buttonNo);
    }

}