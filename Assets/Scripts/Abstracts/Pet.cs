using System;

[Serializable]
public class Pet{
    public string lastTimeFood,
         lastTimeHappy,
         lastTimeGainedEnergy,
        lastTimeCoin;
    public int food, happiness, energy, coins;

    public Pet
        (string lastTimeFood,
        string lastTimeHappy,
        string lastTimeGainedEnergy, 
        string lastTimeCoin,
        int food, 
        int happiness, 
        int energy,
        int coins)
    {
        this.lastTimeFood = lastTimeFood;
        this.lastTimeHappy = lastTimeHappy;
        this.lastTimeGainedEnergy = lastTimeGainedEnergy;
        this.lastTimeCoin = lastTimeCoin;

        this.food = food;
        this.happiness = happiness;
        this.energy = energy;
        this.coins = coins;
    }
}
