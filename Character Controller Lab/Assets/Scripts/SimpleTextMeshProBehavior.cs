using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

[RequireComponent(typeof (TextMeshProUGUI))]
public class SimpleTextMeshProBehavior : MonoBehaviour
{
    private TextMeshProUGUI textObj;
    public SimpleIntBehavior dataObj;

    private void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        UpdateWithIntData();

    }
    public void UpdateWithIntData()
    {
        textObj.text = "Score: " + dataObj.value.ToString(CultureInfo.InvariantCulture);
    }
}
