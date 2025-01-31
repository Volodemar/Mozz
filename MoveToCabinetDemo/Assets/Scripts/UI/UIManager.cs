using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Менеджер интерфейса
/// </summary>	
public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

	public UIWindowHUD UIWindowHUD;
	public UIWindowCatalog UIWindowCatalog;

	private void Awake()
	{
        Instance = this;
	}

	public void ForcedCloseAllWindows()
	{
		foreach(Transform childTransform in this.transform)
		{
            if (childTransform.TryGetComponent(out UIBaseWindow childWindow))
            {
                childWindow.Hide();
            }
		}
	}
}
