using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExplainUI : MonoBehaviour
{
    private static ExplainUI ui;
    
    [SerializeField] private List<ExplainInfo> explainList;
    [SerializeField] private TextMeshProUGUI text;

    public static void AddExplain(string text, float t, int priority)
    {
        ui.explainList.Add(new ExplainInfo(text,Time.time, t, priority));
        var sorted = ui.explainList.OrderBy(e => e.priority).ThenByDescending(e => e.startTime).ToList();
        ui.explainList = sorted;
    }
    
    private void Awake() 
    {
        ui = this;
    }

    private void Update()
    {
        if(explainList.Count > 0)
        {
            text.gameObject.SetActive(true);
            text.text = explainList[0].text;
            for(int i = 0; i < explainList.Count;)
            {
                explainList[i].currentShowTime -= Time.deltaTime;
                if(explainList[i].currentShowTime <= 0) explainList.RemoveAt(i);
                else i++;
            }
        }
        else
        {
            text.gameObject.SetActive(false);
        }
    }
}
