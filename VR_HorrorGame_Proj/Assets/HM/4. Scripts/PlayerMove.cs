using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject ForwardDirection;
    public GameObject CenterEyeCamera;

    private Vector3 PositonPreviousFrameLeftHand;
    private Vector3 PositonPreviousFrameRightHand;
    private Vector3 PlayerPositionPreviousFrame;
    private Vector3 PlayerPositionThisFrame;
    private Vector3 PositionThisFrameLeftHand;
    private Vector3 PositionThisFrameRightHand;

    public float Speed = 50;
    private float HandSpeed;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPositionPreviousFrame = transform.position;
        PositonPreviousFrameLeftHand = LeftHand.transform.position;
        PositonPreviousFrameRightHand = RightHand.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float yRotation = CenterEyeCamera.transform.eulerAngles.y;
        ForwardDirection.transform.eulerAngles = new Vector3(0, yRotation, 0);

        PositionThisFrameLeftHand = LeftHand.transform.position;
        PositionThisFrameRightHand = RightHand.transform.position;
        PlayerPositionThisFrame = transform.position;

        var playerDistanceMoved = Vector3.Distance(PlayerPositionThisFrame, PlayerPositionPreviousFrame);
        var leftHandDistanceMoved = Vector3.Distance(PositonPreviousFrameLeftHand, PositionThisFrameLeftHand);
        var rightHandDistanceMoved = Vector3.Distance(PositonPreviousFrameRightHand, PositionThisFrameRightHand);
        HandSpeed = ((leftHandDistanceMoved - playerDistanceMoved) + (rightHandDistanceMoved - playerDistanceMoved));
        if (leftHandDistanceMoved <= 0.02f || rightHandDistanceMoved <= 0.02f)
        {
            HandSpeed = 0;
        }

        if (Time.timeSinceLevelLoad > 1f)
        {
            transform.position += ForwardDirection.transform.forward *
                HandSpeed * Speed * Time.deltaTime;
        }

        PositonPreviousFrameLeftHand = PositionThisFrameLeftHand;
        PositonPreviousFrameRightHand = PositionThisFrameRightHand;
        PlayerPositionPreviousFrame = PlayerPositionThisFrame;

    }
}
