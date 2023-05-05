using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextSystemUI : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textUI;
    public string text1 = "";
    void Start()
    {
        textUI = GameObject.Find("TextSystem").GetComponent<TextMeshProUGUI>();
        textUI.GetComponent<TextMeshProUGUI>().enabled = false;
        textUI.text = text1;

    }

    // Update is called once per frame
    void Update()
    {
        if(textUI.GetComponent<TextMeshProUGUI>().enabled)
        {
            StartCoroutine("WaitForSeconds");
        }
    }

    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(5);
        disableText();
    }

    public void setTextIn(string t)
    {
        text1 = t;
        textUI.GetComponent<TextMeshProUGUI>().text = text1;
    }

    public void disableText()
    {
        textUI.GetComponent<TextMeshProUGUI>().enabled = false;
        textUI.SetText("");
    }

    public void enableText()
    {
        textUI.GetComponent<TextMeshProUGUI>().enabled = true;
    }

}
