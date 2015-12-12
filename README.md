# CompositionHelper
CompositionHelper for UWP Composition API.  
You can use Composition API by a easy way.

## Features
### Animation
Now we support all animation of Composition API.  
You can use it by classic way(XAML).  
```XML
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

### Effects
Processing...

### Composition Properties warpper
Processing...

## Update Log 

### 15/12/12
Update helper to base SDK 10586.  
- Add `ColorKeyFrame` and `ColorAnimationUseKeyFrame`.  
- Add `QuaternionKeyFrame` and `QuaternionAnimationUseKeyFrame`.  
- Add `QuaternionParameter`.  
- Remove `StoryBoard.Pause()` method.  
