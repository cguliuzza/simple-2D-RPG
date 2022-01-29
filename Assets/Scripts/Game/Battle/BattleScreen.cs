using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BattleMenuState
{
    Main,
    Fight,
    Team,
    Bag
}

public class BattleScreen : MonoBehaviour
{
    public GameObject canvas;
    public List<BattleButton> battleButtons = new List<BattleButton>();
    public List<BattlePanel> battlePanels = new List<BattlePanel>();
    public TextMeshProUGUI text;
    public bool isBattleScreenOpen = false;

    [Range(0.0f, 1.0f)]
    public float escapeChance = 0.5f;

    public string[] mainMenuButtons =  new string[] { "FIGHT", "TEAM", "BAG", "RUN" };
    public string[] fightMenuButtons = new string[] { };
    public string[] bagMenuButtons = new string[] { };

    private BattleMenuState _battleMenuState = BattleMenuState.Main;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetupTrainerBattle(NPCData npc)
    {
        battleButtons[0].arrow.SetActive(true);

        SetupBattleArea(GameController.Instance.monsters[0], true);
        SetupBattleArea(npc.npcMonsters[0], false);

    }

    private void SetupBattleArea(Monster monster, bool isPlayer)
    {
        BattlePanel panel = battlePanels.Find(p => p.isPlayer == isPlayer);
        panel.Setup(monster);
    }


    public void OpenBattleScreen(bool isTrainerBattle)
    {
        if (isTrainerBattle)
        {
            SetupTrainerBattle(BattleController.Instance.npcTrainer);
        } 
        else
        {
            //Setup();
        }
        
        isBattleScreenOpen = true;
        canvas.SetActive(true);
        AudioController.Instance.PlayBGM(AudioIdentifier.BGM_Battle);
    }

    public void CloseBattleScreen()
    {
        isBattleScreenOpen = false;
        canvas.SetActive(false);
        AudioController.Instance.StopBGM();
        AudioController.Instance.PlayBGM(AudioIdentifier.BGM_Main);
    }

    public void OnBattleButtonPressed(string button)
    {

        if (_battleMenuState == BattleMenuState.Main)
        {
            if (button == mainMenuButtons[0]) // fight
            {
                UpdateMenuButtons(BattleMenuState.Fight);
            }
            else if (button == mainMenuButtons[1]) // team
            {

            }
            else if (button == mainMenuButtons[2]) // bag
            {
                UIController.Instance.OpenInventoryScreen();
            }
            else if (button == mainMenuButtons[3]) // run
            {
                AttemptRun();
            }
        }
        else if (_battleMenuState == BattleMenuState.Fight)
        {

        }
        else if (_battleMenuState == BattleMenuState.Bag)
        {

        }
        else if (_battleMenuState == BattleMenuState.Team)
        {

        }
    }


    private void AttemptRun()
    {
        float chance = Random.Range(0.0f, 1.0f);
        if (chance > 1 - escapeChance)
        {
            Run();
        } 
        else
        {

        }
    }

    private void Run()
    {

    }


    private void UpdateMenuButtons(BattleMenuState state)
    {
        _battleMenuState = state;
        if (_battleMenuState == BattleMenuState.Fight)
        {
            for(int i = 0; i < mainMenuButtons.Length; i++)
            {
                battleButtons[i].ChangeLabelText(mainMenuButtons[i]);
            }
        }
    }
}
