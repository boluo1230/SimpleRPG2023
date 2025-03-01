using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI contextText;
    public Button continueButton;

    public List<string> contentList;
    private int contentIndex = 0;
  

    private void Start()
    {
        //如果 nameText 是 private 修饰，也可以通过这种方式赋值
        //nameText = transform.Find("Image_Name/Name_Text").GetComponent<TextMeshProUGUI>();

        hidden();

        //监听继续按钮的点击
        continueButton.onClick.AddListener(this.OnContinueButtonClick);
    }

    public void show()
    {
        gameObject.SetActive(true);
    }

    public void show(string name, string[] content)
    {
        nameText.text = name;

        contentList = new List<string>();
        contentList.AddRange(content);
        contentIndex = 0;
        contextText.text = contentList[0];

        show();

    }

    public void hidden()
    {
        gameObject.SetActive(false);
    }

    public void OnContinueButtonClick()
    {
        contentIndex++;

        if (contentIndex >= contentList.Count)
        {
            hidden();
            return;
        }

        contextText.text = contentList[contentIndex];

       
    }
}
