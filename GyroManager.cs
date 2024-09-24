using UnityEngine;
public class GyroManager : MonoBehaviour
{
    private static GyroManager instance;
    public static GyroManager instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GyroManager>();
                if(instance == null)
                {
                    instance = new GameObject("Spawned GyroManager",typeof(GyroManager)).GetComponent<GyroManager>();
                }
            }

            return instance;
        }
        set
        {
            instance = value;
        }

    }



     [Header("Logic")]
     private Gyroscope gyro;
     private Quaternion rotation;
     private bool gyroActive;
     public void EnableGyro()
     {
        if (gyroActive)
            return;

        if(SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroActive = gyro.enabled;
        } 
        else
        {
            Debug.Log("Gyro is not supported on this device");
        }   

        

     }

    private void Update()
    {
        if(gyroActive)
        {
            rotation = gyro.attitude;
            Debug.Log(rotation);
        }
    }

    public Quaternion GetGyroRotation()
    {
        return rotation
    }
}     