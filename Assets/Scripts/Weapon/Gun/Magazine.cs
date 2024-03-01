using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Magazine : MonoBehaviour, IReloadable
{
    #region ¸â¹ö º¯¼ö
    public int maxBullets = 20;
    public float chargeTime = 2;
    int currentBullets;
    int CurrentBullets
    {
        get => currentBullets;
        set
        {
            if (value < 0)
                currentBullets = 0;
            else if (value > maxBullets)
                currentBullets = maxBullets;
            else
                currentBullets = value;

            OnBulletsChanged?.Invoke(currentBullets);
            OnChargeChanged?.Invoke((float)currentBullets / maxBullets);
        }
    }

    public UnityEvent OnReloadStart;
    public UnityEvent OnReloadEnd;
    public UnityEvent<int> OnBulletsChanged;
    public UnityEvent<float> OnChargeChanged;
    #endregion

    private void Start()
    {
        CurrentBullets = maxBullets;
    }
    public bool Use(int amount = 1)
    {
        if (CurrentBullets >= amount)
        {
            CurrentBullets -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    //[ContextMenu("Reload")]
    public void StartReload()
    {
        if (currentBullets == maxBullets)
            return;

        StopAllCoroutines();
        StartCoroutine(ReloadProcess());
    }
    public void StopReload()
    {
        StopAllCoroutines();
    }
    IEnumerator ReloadProcess()
    {
        OnReloadStart?.Invoke();

        var beginTime = Time.time;
        var beginBullets = currentBullets;
        var enoughPercent = 1 - ((float)currentBullets / maxBullets);
        var enoughChargingTime = chargeTime * enoughPercent;

        while (true)
        {
            var t = (Time.time - beginTime) / enoughChargingTime;
            if (t >= 1)
                break;

            CurrentBullets = (int)Mathf.Lerp(beginBullets, maxBullets, t);
            yield return null;
        }

        currentBullets = maxBullets;
        OnReloadEnd?.Invoke();
    }
}

