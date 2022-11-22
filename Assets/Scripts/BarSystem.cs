using System;

public class BarSystem 
{
    public event EventHandler OnPowerChanged;

    private int power;
    private int powerMax = 100;


    public BarSystem(int power)
    {
        this.power = power;
    }

    public int GetPower()
    {
        return power;
    }

    public void Increase(int powerIncrease)
    {
        power += powerIncrease;
        if (power > powerMax ) power = powerMax;
        if (OnPowerChanged != null) OnPowerChanged(this,EventArgs.Empty);
    }
    public float GetPowerPercent()
    {
        return (float)power / powerMax;
    }

}
