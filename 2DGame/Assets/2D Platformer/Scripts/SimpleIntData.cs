using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SimpleIntData : MonoBehaviour
{
    public int value;
    public event Action<int> OnValueChanged; // Event to notify changes

    public void UpdateValue(int amount)
    {
        value += amount;
        OnValueChanged?.Invoke(value); // Notify listeners of the change
    }

    public void SetValue(int amount)
    {
        value = amount;
        OnValueChanged?.Invoke(value); // Notify listeners of the change
    }
}
