using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetValueFromDropdown : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    public int index;

    public void GetDropdownValue()
    {
        index = dropdown.value;

    }
}
