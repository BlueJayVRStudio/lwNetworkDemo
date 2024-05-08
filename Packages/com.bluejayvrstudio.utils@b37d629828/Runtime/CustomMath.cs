using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace bluejayvrstudio
{
    public class CustomM
    {
        public static Vector3 XZPlane(Vector3 vec)
        {
            return new Vector3(vec.x,0,vec.z);
        }
        public static Vector3 XYPlane(Vector3 vec)
        {
            return new Vector3(vec.x,vec.y,0);
        }
        public static Vector3 YZPlane(Vector3 vec)
        {
            return new Vector3(0,vec.y,vec.z);
        }
        
        public static Vector3 XZPlane(Vector3 vec, float replace)
        {
            return new Vector3(vec.x,replace,vec.z);
        }
        public static Vector3 XYPlane(Vector3 vec, float replace)
        {
            return new Vector3(vec.x,vec.y,replace);
        }
        public static Vector3 YZPlane(Vector3 vec, float replace)
        {
            return new Vector3(replace,vec.y,vec.z);
        }
        public static Vector3 ScaleBy(Vector3 vec, float x, float y, float z)
        {
            return new Vector3(vec.x * x, vec.y * y, vec.z * z);
        }
        public static Vector3 TranslateBy(Vector3 vec, float x, float y, float z)
        {
            return new Vector3(vec.x + x, vec.y + y, vec.z + z);
        }

        public static Vector3 GetWorldPosition(Vector3 localPosition, GameObject anchor) {
            return anchor.transform.TransformPoint(localPosition);
        }
        
        public static Quaternion GetWorldRotation(Quaternion localRotation, GameObject anchor) {
            return anchor.transform.rotation * localRotation;
        }

        public static Vector3 GetRelativePosition(GameObject subject, GameObject anchor) {
            return anchor.transform.InverseTransformPoint(subject.transform.position);
        }

        public static Quaternion GetRelativeRotation(GameObject subject, GameObject anchor) {
            return Quaternion.Inverse(anchor.transform.rotation) * subject.transform.rotation;
        }

    }

    public class TimeFormatter
    {
        public static string mmss(float _Time)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(_Time);
            DateTime dateTime = DateTime.Today.Add(timeSpan);
            string formattedTime = dateTime.ToString("mm:ss");
            return formattedTime;
        }
    }
}