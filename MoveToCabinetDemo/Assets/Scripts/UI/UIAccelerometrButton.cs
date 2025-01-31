using SK.GyroscopeWebGL;
using TMPro;
using UnityEngine;

/// <summary>
/// Кнопка включения и выключения трекинга по геолокации
/// </summary>	
public class UIAccelerometrButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private bool isAccelerometerEnabled = false;
    private Vector3 _lastAcceleration;

	private void OnEnable()
	{
        _lastAcceleration = Vector3.zero;		
	}

	private void OnDisable()
	{
        if (isAccelerometerEnabled)
        {
            SK_DeviceSensor.StopAccelelometerListener();
        }		
	}

	private void OnDestroy()
    {    
        if (isAccelerometerEnabled)
        {
            SK_DeviceSensor.StopAccelelometerListener();
        }
    }

    private void OnReadingAccselerometr(AccelerometerData reading)
    {
        var acc = SK_DeviceSensor.SensorVectorToUnityVector(reading.AccelerationX, 0, reading.AccelerationZ);
        var diff = _lastAcceleration - acc;
        if (Mathf.Abs(diff.x) < 0.1f && Mathf.Abs(diff.z) > 0.20f)
        {
            PlayerController.Instance.StepMove(forceSpeed: 1f);
        }
        _lastAcceleration = acc;        
    }

    public void OnClickAccelerometrButton()
    {
		#if UNITY_EDITOR || !UNITY_WEBGL
			Debug.LogWarning("Accelerometr is not supported in this platform.");
		#else
            isAccelerometerEnabled = !isAccelerometerEnabled;

            if(isAccelerometerEnabled)
            {
                text.text = "Включено";
                UIManager.Instance.UIWindowHUD.HideButtons(notHideIndex: 0);
            }
            else
            {
                text.text = "Акселерометр";
                UIManager.Instance.UIWindowHUD.ShowButtons();
            }
        
            if (isAccelerometerEnabled)
            {
                SK_DeviceSensor.StartAccelerometerListener(OnReadingAccselerometr);
            }
            else
            {
                SK_DeviceSensor.StopAccelelometerListener();
            }
		#endif
    }
}
