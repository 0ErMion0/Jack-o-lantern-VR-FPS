using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WeaponStand : MonoBehaviour
{
    public void OnSoketed(SelectEnterEventArgs args)
    {
        var reloadable = args.interactableObject.transform.GetComponent<IReloadable>();
        reloadable?.StartReload();
    }

    public void OnUnsoketed(SelectExitEventArgs args)
    {
        var reloadable = args.interactableObject.transform.GetComponent<IReloadable>();
        reloadable?.StopReload();
    }
}
