using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxTrigger : MonoBehaviour
{
    public TextAsset text;

    public int startLine;
    public int EndLine;

    public bool destroyWhenActivated;
    public TextBoxManager textBoxManager;

    // Start is called before the first frame update
    void Start()
    {
        textBoxManager = FindObjectOfType<TextBoxManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            textBoxManager.ReloadScript(text);
            textBoxManager.CurrentLine = startLine;
            textBoxManager.EndLine = EndLine;
            textBoxManager.EnableTextBox(true);

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
    }
}
