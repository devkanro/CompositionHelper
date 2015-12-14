# CompositionHelper
Helper for UWP Composition API.    
You can use Composition API by a easy way.  

为 UWP 的 Composition API 提供助手。  
CompositionHelper 提供更为简单的使用 Composition API 的方式。  

## Nuget Package
Install [CompositionHelper](https://www.nuget.org/packages/CompositionHelper/)
```PowerShell
PM> Install-Package CompositionHelper 
```

## Features
### Animation
Now we support all animation of Composition API.   
现在我们支持所有的 Composition API 的动画 API。  

You can use it by classic way(XAML).   
你可以通过经典的 XAML 来创建 Composition 的动画。  
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
你能使用 XAML 来设置 UIElement 的在 Composition API 表现的呈现相关的属性。 

EasyCompositionProperties can help you set it by String in XAML.  
EasyCompositionProperties 能帮助你在 XAML 中使用字符串设置各种不同属性。
```XAML
<Rectangle xmlns:helper="using:CompositionHelper" 
           x:Name="TargetRect" Fill="#FF008BFF" Width="100" Height="100"
           
           helper:EasyCompositionProperties.Opacity="0.5" 
           helper:EasyCompositionProperties.Offset="50,50,0"
           helper:EasyCompositionProperties.RotationAngle="50"
           helper:EasyCompositionProperties.CenterPoint="0.5,0.5,0.5"/>
```

CompositionProperties can help you set it in C#.  
CompositionProperties 能帮助你通过对象设置属性。  
```CSharp
var v3 = new Vector3(1, 2, 3);
var m4x4 = new Matrix4x4(11, 12, 13, 14, 21, 22, 23, 24, 31, 32,33, 34, 41, 42, 43, 44);

CompositionProperties.SetOffset(TargetRect,v3);
CompositionProperties.SetTransformMatrix(TargetRect,m4x4);
```

Also you can use it with Extension Method.  
你也可以使用提供的拓展方法。
```CSharp
var v3 = new Vector3(1, 2, 3);
var m4x4 = new Matrix4x4(11, 12, 13, 14, 21, 22, 23, 24, 31, 32,33, 34, 41, 42, 43, 44);

TargetRect.SetOffset(v3);
TargetRect.SetTransformMatrix(m4x4);
```

### Effects
We have added the ShadowEffect, you can add shadow for UIElement by XAML, need not to add any controls.  
我们添加了阴影特效，现在你能够使用 XAML 为 UIElement 添加阴影，而无需任何的控件。  
```XAML
<Rectangle x:Name="TargetRect" Fill="#FF008BFF" Width="100" Height="100" Opacity="1">
        <effects:ShadowEffect.ShadowEffect>
            <effects:ShadowEffect ShadowColor="Black" BlurAmount="5" Depth="10" Direction="233"/>
        </effects:ShadowEffect.ShadowEffect>
</Rectangle>
```

## Update Log 

### 15/12/15
Add ShadowEffect.
- Add `ShadowEffect` class.
- Add `Microsoft.UI.Composition.Toolkit` library.

添加阴影特效。
- 添加 `ShadowEffect` 类。
- 添加 `Microsoft.UI.Composition.Toolkit` 库。

### 15/12/14
Add ExpressionAnimation and ReferenceParameter support.
- Perfect the `ExpressionAnimation` and `ReferenceParameter` class.
- Add `Completed` event for `Storyboard` class.

添加 ExpressionAnimation 与 ReferenceParameter 支持。
- 完善 `ExpressionAnimation` 与 `ReferenceParameter` 类，现在可更方便的使用表达式动画，与添加引用参数。
- 为 `Storyboard` 类添加 `Completed` 事件。

### 15/12/13
Add Composition Properties warpper.
- Add `EasyCompositionProperties` class.
- Add `CompositionProperties` class.

添加 Composition 呈现属性封装。
- 添加 `EasyCompositionProperties` 类。
- 添加 `CompositionProperties` 类。

### 15/12/12
Update helper to base SDK 10586.  
- Add `ColorKeyFrame` and `ColorAnimationUseKeyFrame`.  
- Add `QuaternionKeyFrame` and `QuaternionAnimationUseKeyFrame`.  
- Add `QuaternionParameter`.  
- Remove `StoryBoard.Pause()` method.  

更新助手基于 SDK 10586。
- 添加 `ColorKeyFrame` 和 `ColorAnimationUseKeyFrame`。
- 添加 `QuaternionKeyFrame` 和 `QuaternionAnimationUseKeyFrame`。
- 添加 `QuaternionParameter`。
- 移除 `StoryBoard.Pause()` 方法。
