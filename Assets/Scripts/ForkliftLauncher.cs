using UnityEngine;

public class ForkliftLauncher : MonoBehaviour
{
	private const float GRAVITY = -9.8f;

	[SerializeField] GameObject prefab;
	private GameObject trashBox;
	private LoadTrigger loadTrigger;
	private Transform target;

	[SerializeField] private float h;
	[SerializeField] private GameObject Truck;

	private bool canLaunch = false;

    private void Start()
    {
		loadTrigger = GetComponentInChildren<LoadTrigger>();
		target = Truck.transform;
    }
    private void Update()
	{

        if (Vector3.Distance(Truck.transform.position, transform.position) <= 10f && loadTrigger.charged == true)
        {
			canLaunch = true;
			Debug.Log("Loaded and ready to shoot");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
			Launch();
        }
	}

	public void Launch()
	{
		if (canLaunch && trashBox == null)
		{
			loadTrigger.Unload();
			trashBox = Instantiate(prefab, loadTrigger.target.transform.position, Quaternion.identity);
			trashBox.transform.tag = "ReadyTrashBox";
			trashBox.layer = 8;
			trashBox.GetComponent<Rigidbody>().velocity = CalculateLaunchData().initialVelocity;
			trashBox = null;

		}
	}

	LaunchData CalculateLaunchData()
	{
		float displacementY = target.position.y - trashBox.transform.position.y;
		Vector3 displacementXZ = new Vector3(target.position.x - trashBox.transform.position.x, 0, target.position.z - trashBox.transform.position.z);
		float time = Mathf.Sqrt(-2 * h / GRAVITY) + Mathf.Sqrt(2 * (displacementY - h) / GRAVITY);
		Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * GRAVITY * h);
		Vector3 velocityXZ = displacementXZ / time;

		return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(GRAVITY), time);
	}


	struct LaunchData
	{
		public readonly Vector3 initialVelocity;
		public readonly float timeToTarget;

		public LaunchData(Vector3 initialVelocity, float timeToTarget)
		{
			this.initialVelocity = initialVelocity;
			this.timeToTarget = timeToTarget;
		}

	}
}
