using UnityEngine;
using TMPro;

public class WaveIndicator : MonoBehaviour
{
    public TextMeshProUGUI waveText;

    void Start()
    {
        UpdateWaveText(1);
    }

    public void UpdateWaveText(int currentWave)
    {
        if (waveText != null)
        {
            waveText.text = "Wave: " + currentWave + "/4";
        }
    }
}