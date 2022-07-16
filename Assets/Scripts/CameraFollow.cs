using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private float offset;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        offset = Camera.main.transform.position.z - player.transform.position.z;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!PlayerController.gameOver)
        {
            Vector3 playerPos = player.transform.position;
            Vector3 cameraPos = Camera.main.transform.position;
            Camera.main.transform.position = new Vector3(cameraPos.x, cameraPos.y, playerPos.z + offset);
        }
    }
}
