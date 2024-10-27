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

    private IEnumerator BounceText(float duration, float bounceScale)
    {
        Vector3 originalScale = textObj.transform.localScale;

        float elapsed = 0f;
        while (elapsed < duration)
        {
            float scale = Mathf.Lerp(1f, bounceScale, Mathf.PingPong(elapsed * 5, 1)); // Bouncing effect
            textObj.transform.localScale = originalScale * scale;

            elapsed += Time.deltaTime;
            yield return null;
        }

        textObj.transform.localScale = originalScale; // Reset to original scale
    }

    public void UpdateWithIntData(int newValue)
    {
        textObj.text = "Coins: " + newValue.ToString(CultureInfo.InvariantCulture);
        StartCoroutine(BounceText(0.5f, 1.2f)); // Bounce for 0.5 seconds to 1.2 scale
    }

}