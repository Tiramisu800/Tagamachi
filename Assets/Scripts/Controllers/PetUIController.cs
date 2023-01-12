using UnityEngine;
using UnityEngine.UI;

public class PetUIController : MonoBehaviour
{
    public Image foodImg, happinessImg, energyImg;

    public static PetUIController instance;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("More than one PetUIController in the Scene");
        }
    }
    public void UpdateImages(int food, int happiness, int energy)
    {
        foodImg.fillAmount = (float) food / 100;
        happinessImg.fillAmount = (float)happiness / 100;
        energyImg.fillAmount = (float)energy / 100;
    }
}
