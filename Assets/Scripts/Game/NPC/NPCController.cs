using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public NPCData npcData;
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && BattleController.Instance.InBattle)
        {
            StartCoroutine(StartBattle());
        }
    }

    private IEnumerator StartBattle()
    {
        StartCoroutine(MoveToPlayer());
        Debug.Log("Start battle");
        yield return new WaitForSeconds(1.0f);
        BattleController.Instance.StartTrainerBattle(npcData);
    }

    private IEnumerator MoveToPlayer()
    {

        GameObject player = GameController.Instance.player;
        Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();

        Vector2 currentPos = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        Vector2 targetPos = new Vector2(playerRB.position.x, playerRB.position.y + 1.5f);

        StartCoroutine(this.gameObject.transform.MoveCoroutine(targetPos, 40.0f * Time.deltaTime));


        yield return null;
    }


}
