using UnityEngine;
using UnityEngine.UI;

public class HealthCount : MonoBehaviour
{
    //script untuk menampilkan dan menentukan banyak darah/nyawa yang bisa diatur
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
