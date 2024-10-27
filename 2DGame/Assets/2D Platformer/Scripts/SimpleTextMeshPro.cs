using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Globalization;

[RequireComponent(typeof(TextMeshProUGUI))]
public class SimpleTextMeshProBehaviour : MonoBehaviour
{
    private TextMeshProUGUI textObj;
    public SimpleIntData dataObj;

    private void Start()
    {
        textObj = GetComponent<TextMeshProUGUI>();
        UpdateWithIntData(dataObj.value); // Initial update
        if (dataObj != null)
        {
            dataObj.OnValueChanged += UpdateWithIntData; // Subscribe to the event
        }
    }

    private void OnDestroy()
    {
        if (dataObj != null)
        {
            dataObj.OnValueChanged -= UpdateWithIntData; // Unsubscribe when destroyed
        }
    }

    public void UpdateWithIntData(int newValue) // Now takes the new value
    {
        textObj.text = "Coins: " + newValue.ToString(CultureInfo.InvariantCulture);
    }
}