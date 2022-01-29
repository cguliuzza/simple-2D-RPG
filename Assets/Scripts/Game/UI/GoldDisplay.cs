using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldDisplay : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    private int _currentGold = 0;
    /// <summary>
    /// Start listening to relevant events
    /// </summary>
    private void OnEnable()
    {
        GameEvents.OnGoldChanged.AddListener(OnGoldChanged);
    }

    //Stop listening from all events
    private void OnDisable()
    {
        GameEvents.OnGoldChanged.RemoveListener(OnGoldChanged);
    }

    private void OnGoldChanged(int value)
    {
        Debug.Log("On Gold Changed: " + value.ToString());
        UpdateGoldValue(value);
    }

    public void UpdateGoldValue(int value)
    {
        StartCoroutine(UpdateGoldText(_currentGold, value));
        _currentGold = value;
        
    }

    private IEnumerator UpdateGoldText(int from, int to)
    {
        for (int i = from; i <= to; i++)
        {
            goldText.text = i.ToString();
            yield return null;
        }
    }
}
