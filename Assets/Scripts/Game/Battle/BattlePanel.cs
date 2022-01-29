using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattlePanel : MonoBehaviour
{
    public bool isPlayer = true;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI levelText;
    public Slider hpSlider;
    public Image hpFill;
    public Image monsterImage;

    public Color hpGreen = Color.green;
    public Color hpYellow = Color.yellow;
    public Color hpRed = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Setup(Monster monster)
    {
        hpText.text = monster.monsterCurrentHP.ToString() + "/" + monster.monsterMaxHP.ToString();
        nameText.text = monster.monsterName;
        levelText.text = "Lv" + monster.monsterLevel.ToString();
        hpSlider.value = (float)monster.monsterCurrentHP / monster.monsterMaxHP;
        monsterImage.sprite = monster.monsterSprite;
        UpdateHPColor();
    }

    private void UpdateHPColor()
    {
        if (hpSlider.value < 0.3f)
        {
            hpFill.color = hpRed;
        }
        else if (hpSlider.value >= 0.3f && hpSlider.value < 0.7f)
        {
            hpFill.color = hpYellow;
        }
        else
        {
            hpFill.color = hpGreen;
        }
    }

}
