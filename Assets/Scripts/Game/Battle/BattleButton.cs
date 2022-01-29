using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BattleButton : MonoBehaviour
{
    public GameObject arrow;
    public TextMeshProUGUI labelText;

    // Start is called before the first frame update
    void Start()
    {
        arrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLabelText(string text)
    {
        labelText.text = text;
    }
}
