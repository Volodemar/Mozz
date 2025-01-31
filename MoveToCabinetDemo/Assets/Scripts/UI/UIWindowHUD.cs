using SK.GyroscopeWebGL;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Окно с HUD навигатора
/// </summary>	
public class UIWindowHUD : UIBaseWindow
{
    [SerializeField] private Button accelerometrButton;
    [SerializeField] private Button geoLocationButton;
    [SerializeField] private Button walkButton;

	public override void Show()
    {    
        UIManager.Instance.ForcedCloseAllWindows();

        this.gameObject.SetActive(true);
    }

	public override void Hide()
    {    
        this.gameObject.SetActive(false);
    } 

    public void HideButtons(int notHideIndex)
    {
        if(notHideIndex != 0)
            accelerometrButton.gameObject.SetActive(false);

        if(notHideIndex != 1)
            geoLocationButton.gameObject.SetActive(false);

        walkButton.gameObject.SetActive(false);
    }

    public void ShowButtons()
    {
        accelerometrButton.gameObject.SetActive(true);
        geoLocationButton.gameObject.SetActive(true);
        walkButton.gameObject.SetActive(true);
    }
}
