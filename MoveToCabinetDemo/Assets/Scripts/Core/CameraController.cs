using UnityEngine;

/// <summary>
/// Управление камерой
/// </summary>	
public class CameraController : MonoBehaviour
{
    public static CameraController Instance { get; private set; }

	private void Awake()
	{
        Instance = this;
	}

	private void Update()
	{
		var player = PlayerController.Instance;

		if(player != null)
		{
			this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
		}
	}
}
