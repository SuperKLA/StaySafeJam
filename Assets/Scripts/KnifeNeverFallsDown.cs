using UnityEngine;

public class KnifeNeverFallsDown : MonoBehaviour
{
    public Knife Knife;

    public void Update()
    {
        var position = this.transform.position;
        if (position.y < -100)
        {
            this.transform.position = new Vector3(0,1,0);
            this.Knife.OwnRigidbody.velocity = Vector3.zero;
            this.Knife.OwnRigidbody.angularVelocity = Vector3.zero;
        }
    }

}