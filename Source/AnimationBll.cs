using Godot;
using System.Collections.Generic;

namespace BLL
{
    public static class AnimationBll
    {
        public static void PlayAnimation(AnimationPlayer animationPlayer, string animationName)
        {
            if (animationPlayer.CurrentAnimation != animationName || !animationPlayer.IsPlaying())
            {
                animationPlayer.Play(animationName, 0.35f);
            }
        }
    }
}