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

### Fluent interface of animation  
You can build composition animations by fluent interface.  
你可以通过流式接口来构建 Composition API 的动画。

Fluent interface can make your code easier to read.  
流式接口可以让你的代码更加的易于理解。  

01.Use the extension method `StartBuildAnimation` to create a storyborad context.  
01.使用针对 Visual 的拓展方法 `StartBuildAnimation` 来创建一个故事版上下文。
```CSharp
Rectangle.GetVisual().StartBuildAnimation();
```

02.`Animate` can build simple "From-To" animation, `AnimateWithKeyFrame` can build keyframe animation, `AnimateWithExpression` can build expression animation.  
02.`Animate` 可以创建简单的 "From-To" 动画，`AnimateWithKeyFrame` 可以创建关键帧动画，`AnimateWithExpression` 则可以创建表达式动画。
```CSharp
Rectangle.GetVisual().StartBuildAnimation()
    .Animate(AnimateProperties.Offset.Y)
    .ToExpression("this.target.Offset.y + 100")
    .Spend(TimeSpan.FromSeconds(0.5))
```

03.Use `Over` method to go back to storyboard context.  
03.使用 `Over` 结束动画的创建，返回到故事版上下文。
```CSharp
Rectangle.GetVisual().StartBuildAnimation()
    .Animate(AnimateProperties.Offset.Y)
    .ToExpression("this.target.Offset.y + 100")
    .Spend(TimeSpan.FromSeconds(0.5))
    .Over();
```

04.`Start` and `Wait` the storyboard.  
04.使用 `Start` 开始故事版，并用 `Wait` 等待动画结束。
```CSharp
await Rectangle.GetVisual().StartBuildAnimation()
    .Animate(AnimateProperties.Offset.Y)
    .ToExpression("this.target.Offset.y + 100")
    .Spend(TimeSpan.FromSeconds(0.5))
    .Over()
	.Start().Wait();
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
We found there are some Airspace issue between Composition API visual tree and XAML visual tree, so we remove shadow effect, but you can still find those codes in early Commit.  
我们发现在 Composition API 的视觉树与 XAML 的视觉树之间有空域问题，所以我们移除了阴影特效，你仍然可以在之前的 Commit 上找到这些代码。

## Update Log 

### 16/08/07
Add fluent animation APIs.

添加了流式动画接口 API。

### 16/01/11
Remove ShadowEffect and Clear up APIs.
- Remove `ShadowEffect` class.
- Remove `Microsoft.UI.Composition.Toolkit` library.
- Clear up some APIs.

移除阴影特效，清理一些 API。
- 移除 `ShadowEffect` 类。
- 移除 `Microsoft.UI.Composition.Toolkit` 库。
- 清理一些 API 的代码。

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
