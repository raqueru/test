using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Grimoire : MonoBehaviour
{
    public VerticalLayoutGroup LayoutGroup;
    public MagicInfoUI magicinfoPrefab;
    public GameObject magicElements;
    public static Grimoire instance;



    private void Awake()
    {
        instance = this;
        OpenGrimoire();
    }


    public void OpenGrimoire()
    {
        this.gameObject.SetActive(!this.gameObject.activeSelf);
    }
    public void UpdateGrimoire()
    {
        foreach (Transform child in LayoutGroup.transform)
        {
            Destroy(child.gameObject);
        }
        ShowMagics(Player.instance.lv1Magics);
        ShowMagics(Player.instance.lv2Magics);
        ShowMagics(Player.instance.lv3Magics);
    }

    void ShowMagics(List<Magic> list)
    {


        for (int i = 0; i < list.Count; i++)
        {
            MagicInfoUI magic = Instantiate(magicinfoPrefab, LayoutGroup.transform);
            magic.Name.text = list[i].Name;
            magic.Description.text = list[i].Description;
            magic.LV.text = "LV." + list[i].Level.ToString();
            magic.Type.text = "Tipo: ";
            int element = (int)list[i].Element[0];
            magic.Elements.transform.GetChild(0).gameObject.GetComponent<Image>().sprite =
            magicElements.transform.GetChild(element).GetComponent<Image>().sprite;
            if (list[i].Element.Count > 1)
            {
                element = (int)list[i].Element[1];
                magic.Elements.transform.GetChild(1).gameObject.SetActive(true);
                magic.Elements.transform.GetChild(1).gameObject.GetComponent<Image>().sprite =
                magicElements.transform.GetChild(element).GetComponent<Image>().sprite;

            }
            for (int j = 0; j < list[i].Type.Count; j++)
            {
                magic.Type.text += list[i].Type[j];
                if (j < Player.instance.lv1Magics[i].Type.Count - 1)
                {
                    magic.Type.text += "/ ";
                }
            }
        }
    }
}
