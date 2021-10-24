using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextBoxManager : MonoBehaviour
{
    public GameObject TextBox;

    public Text TheText;
    public Text Name;

    public int CurrentLine;
    public int EndLine;

    private  string previousname= "";

    public TextAsset textFile;
    public string[] textLines;
    public bool IsActive = true;
    // Start is called before the first frame update
    void Start()
    {
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }


    }

    private void Update()
    {
        if (EndLine == 0)
        {
            EndLine = textLines.Length - 1;
        }

        if (CurrentLine > EndLine)
        {
            EnableTextBox(false);
            IsActive = false;

        }

        string[] splitArray = textLines[CurrentLine].Split(char.Parse(":")); //Here we assing the splitted string to array by that char
        name = splitArray[0]; //Here we assign the first part to the name


        if (splitArray.Length < 2)
        {
            Name.text = previousname;
            TheText.text = name;
        }
        else
        {

              Name.text= CheckDictionary(name);
              previousname=CheckDictionary(name);
              TheText.text = splitArray[1];
        }
        if (IsActive && Input.GetKeyDown("z"))
        {
            CurrentLine++;
        }


        EnableTextBox(IsActive);

        if (!IsActive)
        {
            return;
        }
    }
    public void EnableTextBox(bool enabled)
    {
        TextBox.SetActive(enabled);
        IsActive = enabled;

    }
    public void ReloadScript(TextAsset text)
    {
        if (text != null)
        {
            textLines = new string[1];
            textLines = (text.text.Split('\n'));
        }
    }


    string CheckDictionary(string name){
        string result="";
        if (Balance.VisualNovel.names.ContainsKey(name))
            {
               result= Balance.VisualNovel.names[name];

            }
        else{

              result =name;
            }
            return result;

    }

}
