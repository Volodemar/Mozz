using SK.GeolocatorWebGL;
using SK.GeolocatorWebGL.Models;
using TMPro;
using UnityEngine;

/// <summary>
/// Кнопка включения выключения трекинга по геолокации
/// </summary>	
public class UIGeolocationButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private bool isGeolocationEnabled = false;

	private void OnDisable()
	{
        if (isGeolocationEnabled)
        {
            SK_Geolocator.ClearWatch();
        }		
	}

	private void OnDestroy()
    {    
        if (isGeolocationEnabled)
        {
            SK_Geolocator.ClearWatch();
        }
    }

    public void OnGeolocationError(GeolocationPositionError error)
    {
		//if(error.message.Length > 0)
		//	text.text = "Нет доступа";
    }

	private void OnReadingGeolocation(GeolocationPosition position)
	{
		if ((float)position.coords.speed > 0.2f)
		{
			PlayerController.Instance.StepMove(forceSpeed: 3f);
		}
	}

	public void OnClickGeolocationButton()
    {
		#if UNITY_EDITOR || !UNITY_WEBGL
			Debug.LogWarning("Geolocation is not supported in this platform.");
		#else
			isGeolocationEnabled = !isGeolocationEnabled;

			if (isGeolocationEnabled)
			{
				text.text = "Включено";
				UIManager.Instance.UIWindowHUD.HideButtons(notHideIndex: 1);
			}
			else
			{
				text.text = "Геолокация";
				UIManager.Instance.UIWindowHUD.ShowButtons();
			}

			if (isGeolocationEnabled)
			{
				var options = new PositionOptions
				{
					enableHighAccuracy = true,
					maximumAge = 100,
					timeout = 200
				};

				SK_Geolocator.WatchLocation((s) => OnReadingGeolocation(s), (e) => OnGeolocationError(e), options);
			}
			else
			{
				SK_Geolocator.ClearWatch();
			}
		#endif
	}
}
