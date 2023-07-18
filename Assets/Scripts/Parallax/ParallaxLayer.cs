//https://www.youtube.com/watch?v=XMZqQ4iPhkQ
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParallaxLayer : MonoBehaviour
{
      public float parallaxFactor;

      public void Move(float delta)
      {
          Vector3 newPos = transform.localPosition;
          newPos.x -= delta * parallaxFactor;

          transform.localPosition = newPos;
      }

}
