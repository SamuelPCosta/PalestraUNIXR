using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DynamicTable : MonoBehaviour
{
    [SerializeField] List<GameObject> table;
    [SerializeField] List<float> total;
    [SerializeField] List<float> dValue;

    [SerializeField] TextMeshProUGUI Portion;
    private int BasePortion = 0;

    [SerializeField] TMP_InputField input;

    void Start()
    {
        BasePortion = int.Parse(Portion.text.Replace("ml", ""));

        foreach (var line in table)
        {
            float value;
            if(float.TryParse(line.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text, out value))
                total.Add(value);
            else
                total.Add(0);

            string text = line.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text.Replace("-", "0");
            if (float.TryParse(text, out value))
                dValue.Add(value);
            else
                total.Add(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPortion()
    {
        if (BasePortion == 0)
            return;

        int inputValue = int.Parse(input.text);
        float newValue;

        for (int i = 0; i < table.Count; i++)
        {
            newValue = total[i] * inputValue / BasePortion;
            table[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = newValue +"";
            newValue = dValue[i] * inputValue / BasePortion;
            table[i].transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = newValue +"";
            Portion.text = inputValue + "ml";
        }
    }
}
