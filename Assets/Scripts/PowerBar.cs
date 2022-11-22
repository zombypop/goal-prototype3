using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBar : MonoBehaviour
{
    private BarSystem barSystem;
    public void Setup(BarSystem barSystem)
    {
        this.barSystem = barSystem;
        this.barSystem.OnPowerChanged += BarSystem_OnPowerChanged;
    }

    private void BarSystem_OnPowerChanged(object sender, System.EventArgs e)
    {
        transform.Find("Bar").localScale = new Vector3(barSystem.GetPowerPercent(), 1);
    }

    private void Update()
    {
        //transform.Find("Bar").localScale = new Vector3 (barSystem.GetPowerPercent(), 1);
    }
}
