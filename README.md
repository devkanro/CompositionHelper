# CompositionHelper
CompositionHelper for UWP Composition API.  
You can use Composition API by a easy way.

## Nuget Package
Install [CompositionHelper](https://www.nuget.org/packages/CompositionHelper/)
```PowerShell
PM> Install-Package CompositionHelper 
```

## Features
### Animation
Now we support all animation of Composition API.  
You can use it by classic way(XAML).  
```XAML
<anime:Storyboard x:Key="Storyboard" xmlns:anime="using:CompositionHelper.Animation">
    <anime:ScalarAnimationUseKeyFrame TargetName="TargetRect" Duration="0:0:1" TargetProperty="Opacity">
        <anime:ScalarKeyFrame Progress="0.0" Value="1.0" />
        <anime:ScalarKeyFrame Progress="1.0" Value="0.0" />
    </anime:ScalarAnimationUseKeyFrame>

    <anime:Vector3AnimationUseKeyFrame TargetName="TargetRect" Duration="0:0:1" TargetProperty="Offset">
        <anime:Vector3KeyFrame Progress="0.0" Value="0,0,0" />
        <anime:Vector3KeyFrame Progress="1.0" Value="100,100,100">
            <anime:Vector3KeyFrame.EasingFunction>
                <anime:CubicBezierEasingFunction ControlPoint1="0,0" ControlPoint2="0.5,1.0"></anime:CubicBezierEasingFunction>
            </anime:Vector3KeyFrame.EasingFunction>
        </anime:Vector3KeyFrame>
    </anime:Vector3AnimationUseKeyFrame>
</anime:Storyboard>
```

### Composition Properties warpper
You can use XAML to set UIElement's Visual composition properties.

EasyCompositionProperties can help you set it by String in XAML.
```XAML
<Rectangle xmlns:helper="using:CompositionHelper" 
           x:Name="TargetRect" Fill="#FF008BFF" Width="100" Height="100"
           
           helper:EasyCompositionProperties.Opacity="0.5" 
           helper:EasyCompositionProperties.Offset="50,50,0"
           helper:EasyCompositionProperties.RotationAngle="50"
           helper:EasyCompositionProperties.CenterPoint="0.5,0.5,0.5"/>
```

CompositionProperties can help you set it in C#.
```CSharp
var v3 = new Vector3(1, 2, 3);
var m4x4 = new Matrix4x4(11, 12, 13, 14, 21, 22, 23, 24, 31, 32,33, 34, 41, 42, 43, 44);

CompositionProperties.SetOffset(TargetRect,v3);
CompositionProperties.SetTransformMatrix(TargetRect,m4x4);
```

Also you can use it with Extension Method.
```CSharp
var v3 = new Vector3(1, 2, 3);
var m4x4 = new Matrix4x4(11, 12, 13, 14, 21, 22, 23, 24, 31, 32,33, 34, 41, 42, 43, 44);

TargetRect.SetOffset(v3);
TargetRect.SetTransformMatrix(m4x4);
```

### Effects
Processing...

## Update Log 

### 15/12/13
Add Composition Properties warpper.
- Add `EasyCompositionProperties` class.
- Add `CompositionProperties` class.

### 15/12/12
Update helper to base SDK 10586.  
- Add `ColorKeyFrame` and `ColorAnimationUseKeyFrame`.  
- Add `QuaternionKeyFrame` and `QuaternionAnimationUseKeyFrame`.  
- Add `QuaternionParameter`.  
- Remove `StoryBoard.Pause()` method.  
