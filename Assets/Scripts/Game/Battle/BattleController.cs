using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BattleController : BaseSingletonBehaviour<BattleController>
{
    [Range(0.0f, 1.0f)]
    public float wildAttackProbability = 0.30f;

    public NPCData npcTrainer = null;

    public bool InBattle 
    {
        get { return _inBattle;  }
    }

    //public TilemapCollider2D wildGrassCollider;
    private bool _isAttackable = false;
    private bool _inBattle = false;

    private int _monsterIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAttackable && !_inBattle && PlayerController.Instance.canMove)
        {
            float chance = Random.Range(0.0f, 1.0f);
            if (chance > 1.0f - wildAttackProbability)
            {
                //StartBattle(false);
            }
        }
    }

    private void FixedUpdate()
    {
        
    }

    public void OnEnterWildgrass()
    {
        SetAttackable(true);
    }

    public void OnExitWildgrass()
    {
        SetAttackable(false);
    }

    public void SetAttackable(bool value)
    {
        _isAttackable = value;
    }


    public void StartBattle(bool isTrainerBattle)
    {
        _inBattle = true;
        _isAttackable = false;
        AudioController.Instance.PlaySFX(AudioIdentifier.Battle_Start);
        UIController.Instance.OpenBattleScreen(isTrainerBattle);
    }

    public void StartTrainerBattle(NPCData npc)
    {
        Debug.Log("Start trainer battle");
        npcTrainer = npc;
        StartBattle(true);
    }

}
