using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rainbowwheel
{
    public class WheelController : MonoBehaviour
    {
        private float rotateSpeed = 500f;
        private float wheelPositionY = -3.5f;
        private float wheelPositionLimitX = 1.5f;
        private Vector2 lastFrameTouchPosition;
        private Touch touch;
        [SerializeField] Camera mainCam;

        void Update()
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                Move();
                lastFrameTouchPosition = touch.position;
            }
        }

        private void Move()
        {
            switch(touch.phase)
            {
                case TouchPhase.Began:
                    lastFrameTouchPosition = touch.position;
                    break;
                case TouchPhase.Moved:
                    transform.position = Vector3.Lerp(
                        transform.position,
                        ClampPosition(mainCam.ScreenToWorldPoint(touch.position), wheelPositionLimitX),
                        0.05f
                    );
                    if (lastFrameTouchPosition.y > touch.position.y)
                    {
                        transform.Rotate(Vector3.back, rotateSpeed * Time.deltaTime);
                    }
                    else if (lastFrameTouchPosition.y < touch.position.y)
                    {
                        transform.Rotate(Vector3.back, -rotateSpeed * Time.deltaTime);
                    }
                    break;
            }
        }

        private Vector2 ClampPosition(Vector3 pos, float clampPos)
        {
            return new Vector2(Mathf.Clamp(pos.x, -clampPos, clampPos), wheelPositionY);
        }
    }
}
