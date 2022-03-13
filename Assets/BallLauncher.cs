using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour
{

	public Rigidbody ball;
	public Transform target;
	public Transform ballPos;
	private float h = 25;
	public float gravity = -18;



    private void Update()
    {
		h = Mathf.Clamp(Vector3.Distance(target.position, ballPos.position) - 3f, 10, 25);


    }

    public void Launch()
	{
		Physics.gravity = Vector3.up * gravity;
		ball.useGravity = true;

		ball.velocity = CalculateLaunchData().initialVelocity;
	}

	LaunchData CalculateLaunchData()
	{
		float displacementY = target.position.y - ball.position.y;
		Vector3 displacementXZ = new Vector3(target.position.x - ball.position.x, 0, target.position.z - ball.position.z);
		float time = Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity);
		Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
		Vector3 velocityXZ = displacementXZ / time;

		return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
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
