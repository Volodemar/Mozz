using UnityEngine;

/// <summary>
/// Базовый класс окон
/// </summary>	
public class UIBaseWindow : MonoBehaviour
{
	public virtual void Show()
    {    
        UIManager.Instance.ForcedCloseAllWindows();

        this.gameObject.SetActive(true);
    }

	public virtual void Hide()
    {    
        this.gameObject.SetActive(false);
    }
}
