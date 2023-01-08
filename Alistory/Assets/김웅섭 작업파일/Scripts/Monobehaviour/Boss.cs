using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    private static Boss boss;

    [SerializeField] private bool bossDisplayed;
    [SerializeField] private float deathRange;
    [SerializeField] private Image panel;

    public static bool BossDisplayed { get {return boss.bossDisplayed; } }

    private void Awake()
    {
        boss = this;
    }

    private void Update()
    {
        var player = Physics2D.CircleCast(transform.position, deathRange, Vector2.zero, 0, LayerMask.GetMask("Player"));
        if (player.collider != null && !Player.currentPlayer.isHiding)
        {
            Player.currentPlayer.gameObject.SetActive(false);
        }

        if (!bossDisplayed && Player.currentPlayer.items.Count > 0 && Mathf.Abs(Player.currentPlayer.transform.position.x - (-2.5f)) > 4)
        {
            Debug.Log("Boss is Move!");
            bossDisplayed = true;
            StartCoroutine(BossAnimation());
        }
    }

    IEnumerator BossAnimation()
    {
        var color = panel.color;
        color.a = 1f;
        panel.color = color;

        yield return new WaitForSeconds(0.5f);

        color = panel.color;
        color.a = 0.5f;
        panel.color = color;

        yield return new WaitForSeconds(2);
        ExplainUI.AddExplain("무언가 다가온다", 5, 2);

        yield return new WaitForSeconds(3);

        for (float t = 0; t < 2; t += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(new Vector3(-20, 0, -1.9f), new Vector3(20, 0, -1.9f), t / 2);
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, deathRange);
    }
}
