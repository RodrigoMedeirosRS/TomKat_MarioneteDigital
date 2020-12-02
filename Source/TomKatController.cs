using Godot;
using System;

public class TomKatController : Spatial
{
    public AnimationPlayer ControladorCorpo { get; set; }
    public AnimationPlayer ControladorBoca { get; set; }
    public AnimationPlayer ControladorSombrancelha { get; set; }
    public AnimationPlayer ControladorOlho { get; set; }
    public override void _Ready()
    {
        ControladorCorpo = GetNode<AnimationPlayer>("./AnimationPlayerCorpo");
        ControladorBoca = GetNode<AnimationPlayer>("./AnimationPlayerBoca");
        ControladorOlho = GetNode<AnimationPlayer>("./AnimationPlayerOlhos");
        ControladorSombrancelha = GetNode<AnimationPlayer>("./AnimationPlayerSombrancelhas");
    }

//  public override void _Process(float delta)
//  {
//      
//  }
}
