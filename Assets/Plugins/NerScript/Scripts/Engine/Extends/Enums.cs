using UnityEngine;

namespace NerScript
{
    public enum SpaceType
    {
        World = 1,
        Local,
        Virtual
    }
    public enum TransformType
    {
        Position = 1,
        Rotation,
        Scale,
        Transform
    }
    public enum TransformProperty
    {
        Position,
        Rotation,
        Scale,
        Transform,
        LocalPosition,
        LocalRotation,
        LocalScale,
        LocalTransform,
    }
    public enum Axis
    {
        X = 1,
        Y,
        Z,
        W
    }
}