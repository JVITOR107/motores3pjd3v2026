using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    [SerializeField]
    private TMP_Text coinText;

    private void OnEnable()
    {
        PlayerObserverManager.OnCoinCollected += UpdateCoins;
    }

    private void OnDisable()
    {
        PlayerObserverManager.OnCoinCollected -= UpdateCoins;
    }

    void Start()
    {
        coinText.text = "Moedas: 0";
    }

    void UpdateCoins(int amount)
    {
        coinText.text = "Moedas: " + amount;
    }
}