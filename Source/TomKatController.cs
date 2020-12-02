using Godot;
using System;
using BLL;
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

    public override void _Process(float delta)
    {
        ControlarBoca();
        ControlarOlho();
        ControlarSombrancelha();
        ControlarCorpo();
    }

    private void ControlarBoca()
    {
        if (InputEventBll.GetKey(InputAction.falar, KeyStatus.Hold))
            ControladorBoca.Play("Falando");
        else
            ControladorBoca.Play("Quieto");
    }
    
    private void ControlarOlho()
    {
        if (InputEventBll.GetKey(InputAction.olho_direito, KeyStatus.Hold) && InputEventBll.GetKey(InputAction.olho_esquerdo, KeyStatus.Hold))
            ControladorOlho.Play("Fechados");
        else
        {
            if (InputEventBll.GetKey(InputAction.olho_direito, KeyStatus.Hold))
                ControladorOlho.Play("Direito_Fechado");
            else if (InputEventBll.GetKey(InputAction.olho_esquerdo, KeyStatus.Hold))
                ControladorOlho.Play("Esquerdo_Fechado");
            else
                ControladorOlho.Play("Olhos_Abertos");
        }
    }
    private void ControlarSombrancelha()
    {
        if (InputEventBll.GetKey(InputAction.sombrancelha_1, KeyStatus.Hold) && InputEventBll.GetKey(InputAction.sombrancelha_2, KeyStatus.Hold))
            ControladorSombrancelha.Play("Raiva");
        else
        {
            if (InputEventBll.GetKey(InputAction.sombrancelha_1, KeyStatus.Hold))
                ControladorSombrancelha.Play("Erguida");
            else if (InputEventBll.GetKey(InputAction.sombrancelha_2, KeyStatus.Hold))
                ControladorSombrancelha.Play("Curiosidade");
            else
                ControladorSombrancelha.Play("Normal");
        }
    }

    private void ControlarCorpo()
    {
        ExecutaAnimacaoDisparada();
        var pressionado = false;
        var disparado = ((ControladorCorpo.CurrentAnimation == InputAction.Concordando.ToString()) ||
        (ControladorCorpo.CurrentAnimation == InputAction.Negando.ToString()) ||
        (ControladorCorpo.CurrentAnimation == InputAction.Hifi.ToString()));
        pressionado = ExecutaAnimacaoContinua();
        ExecutarIdle(pressionado, disparado);
    }

    private bool ExecutaAnimacaoContinua()
    {
        if (InputEventBll.GetKey(InputAction.Acenando, KeyStatus.Hold))
        {
            AnimationBll.PlayAnimation(ControladorCorpo, InputAction.Acenando.ToString());
            return true;
        } 
        if (InputEventBll.GetKey(InputAction.ByeBye, KeyStatus.Hold))
        {
            AnimationBll.PlayAnimation(ControladorCorpo, InputAction.ByeBye.ToString());
            return true;
        }
        if (InputEventBll.GetKey(InputAction.Confuso, KeyStatus.Hold))
        {
            AnimationBll.PlayAnimation(ControladorCorpo, InputAction.Confuso.ToString());
            return true;
        }
        if (InputEventBll.GetKey(InputAction.Desesperado, KeyStatus.Hold))
        {
            AnimationBll.PlayAnimation(ControladorCorpo, InputAction.Desesperado.ToString());
            return true;
        }
        if (InputEventBll.GetKey(InputAction.Digitando, KeyStatus.Hold))
        {
            AnimationBll.PlayAnimation(ControladorCorpo, InputAction.Digitando.ToString());
            return true;
        }
        if (InputEventBll.GetKey(InputAction.Impaciente, KeyStatus.Hold))
        {
            AnimationBll.PlayAnimation(ControladorCorpo, InputAction.Impaciente.ToString());
            return true;
        } 
        if (InputEventBll.GetKey(InputAction.Pensativo, KeyStatus.Hold))
        {
            AnimationBll.PlayAnimation(ControladorCorpo, InputAction.Pensativo.ToString());
            return true;
        }
        return false; 
    }

    private void ExecutaAnimacaoDisparada()
    {
        if (InputEventBll.GetKey(InputAction.Concordando, KeyStatus.Pressed))
        {
            ControladorCorpo.Play(InputAction.Concordando.ToString(), 0.35f);
        }            
        if (InputEventBll.GetKey(InputAction.Negando, KeyStatus.Pressed))
        {
            ControladorCorpo.Play(InputAction.Negando.ToString(), 0.35f);
        }
        if (InputEventBll.GetKey(InputAction.Hifi, KeyStatus.Pressed))
        {
            ControladorCorpo.Play(InputAction.Hifi.ToString(), 0.35f);
        }
    }

    private void ExecutarIdle(bool pressionado, bool disparado)
    {
        if (!pressionado)
        {
            if (!disparado)
                AnimationBll.PlayAnimation(ControladorCorpo, "Idle");
            else if (!ControladorCorpo.IsPlaying())
            {
                GD.Print("Aqui");
                AnimationBll.PlayAnimation(ControladorCorpo, "Idle");    
            }
                     
        }
    }
}
