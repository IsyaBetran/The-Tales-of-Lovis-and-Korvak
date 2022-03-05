using UnityEngine;
using UnityEngine.UI;

public class HealthCount : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthCount;
    [SerializeField] private Image healthCountSaatIni;

    private void Start()
    {
        totalHealthCount.fillAmount = playerHealth.healthSaatIni / 5;
    }

    private void Update()
    {
        healthCountSaatIni.fillAmount = playerHealth.healthSaatIni / 5;
    }
}
