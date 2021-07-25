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

        for (int i = 0; i < Player.instance.lv1Magics.Count; i++)
        {
            MagicInfoUI magic = Instantiate(magicinfoPrefab, LayoutGroup.transform);
            magic.Name.text = Player.instance.lv1Magics[i].Name;
            magic.Description.text = Player.instance.lv1Magics[i].Description;
            magic.LV.text = "LV." + Player.instance.lv1Magics[i].Level.ToString();
            magic.Type.text = "Tipo: ";
            int element = (int)Player.instance.lv1Magics[i].Element[0];
            magic.Elements.transform.GetChild(0).gameObject.GetComponent<Image>().sprite =
            magicElements.transform.GetChild(element).GetComponent<Image>().sprite;
            if (Player.instance.lv1Magics[i].Element.Count > 1)
            {
                element = (int)Player.instance.lv1Magics[i].Element[1];
                magic.Elements.transform.GetChild(1).gameObject.SetActive(true);
                magic.Elements.transform.GetChild(1).gameObject.GetComponent<Image>().sprite =
                magicElements.transform.GetChild(element).GetComponent<Image>().sprite;

            }
            for (int j = 0; j < Player.instance.lv1Magics[i].Type.Count; j++)
            {
                magic.Type.text += Player.instance.lv1Magics[i].Type[j];
                if (j < Player.instance.lv1Magics[i].Type.Count - 1)
                {
                    magic.Type.text += "/ ";
                }
            }
        }
    }
}
