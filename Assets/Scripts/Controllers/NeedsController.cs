using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    public int coins;
    public int food, happiness, energy;
    public int foodTickRate, happinessTickRate, energyTickRate, coinGetRate;
    public DateTime lastTimeFood, lastTimeHappy, lastTimeGainedEnergy, lastTimeCoin;

    private void Awake()
    {
        Initialize(50,100, 100, 100, 5, 10, 7, 5);
    }
    public void Initialize(int coins, int food, int happiness, int energy,int foodTickRate, int happinessTickRate, int energyTickRate, int coinGetRate)
    {
        this.coins = coins;

        lastTimeFood = DateTime.Now;
        lastTimeHappy = DateTime.Now;
        lastTimeGainedEnergy = DateTime.Now;

        lastTimeCoin = DateTime.Now;

        this.food = food;
        this.happiness = happiness;
        this.energy = energy;
        this.foodTickRate = foodTickRate;
        this.happinessTickRate = happinessTickRate;
        this.energyTickRate = energyTickRate;

        this.coinGetRate = coinGetRate;
    }

    public void Initialize(int coins, int food, int happiness, int energy, int coinGetRate,
        int foodTickRate, int happinessTickRate, int energyTickRate,
        DateTime lastTimeFood, DateTime LastTimeHappy, DateTime LastTimeGainedEnergy, DateTime lastTimeCoin)
    {
        this.coins = coins;

        this.lastTimeFood = lastTimeFood;
        this.lastTimeHappy = lastTimeHappy;
        this.lastTimeGainedEnergy = lastTimeGainedEnergy;

        this.lastTimeCoin = lastTimeCoin;

        this.food = food;
        this.happiness = happiness;
        this.energy = energy;

        this.coinGetRate = coinGetRate;

        this.foodTickRate = foodTickRate;
        this.happinessTickRate = happinessTickRate;
        this.energyTickRate = energyTickRate;
        PetUIController.instance.UpdateImages(food, happiness, energy);
        CoinController.instance.UpdateText(coins);
    }

    public void Update()
    {
        if (TimingManager.gameHourTimer < 0)
        {
            ChangeFood(-foodTickRate);
            ChangeHappiness(-happinessTickRate);
            ChangeEnergy(-energyTickRate);
            ChangeCoin(+coinGetRate);

            PetUIController.instance.UpdateImages(food, happiness, energy);
        }
        
    }
    public void ChangeCoin(int amount)
    {
        coins += amount;
        if (amount > 0)
        {
            lastTimeCoin = DateTime.Now;
        }
    }

    public void ChangeFood(int amount)
    {
        food += amount;
        if (amount > 0)
        {
            lastTimeFood = DateTime.Now;
        }
        if (food > 100) { food = 100; }
    }

    public void ChangeHappiness(int amount)
    {
        happiness += amount;
        if (amount > 0)
        {
            lastTimeHappy = DateTime.Now;
        }
        if (happiness > 100) { happiness = 100; }
    }

    public void ChangeEnergy(int amount)
    {
        energy += amount;
        if (amount > 0)
        {
            lastTimeGainedEnergy = DateTime.Now;
        }
        if (energy > 100) { energy = 100; }
    }

}
