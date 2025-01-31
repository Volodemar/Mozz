using UnityEngine;

public class UIMenu: MonoBehaviour
{
    public void OnClickShowCatalog()
    {
        UIManager.Instance.UIWindowCatalog.Show();
    }
}
