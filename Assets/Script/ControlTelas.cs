using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;

public class ControlTelas : MonoBehaviour
{
    [SerializeField] List<Transform> _panelInicial = new List<Transform>();
    [SerializeField] float timeAnim;
    [SerializeField] List<Transform> _panelPause = new List<Transform>();
    [SerializeField] List<Transform> _panelFinal = new List<Transform>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // using var _ = PanelInicial();
    }


    public void PainelInicialOn(bool value)
    {
        using var _ = PanelInicial(value);
    }
    async Task PanelInicial(bool value)
    {
        if (value)
        {
            for (int i = 0; i < _panelInicial.Count; i++)
            {
                _panelInicial[i].localScale = Vector3.zero;
            }

            for (int i = 0; i < _panelInicial.Count; i++)
            {
                await Awaitable.WaitForSecondsAsync(timeAnim);
                _panelInicial[i].DOScale(Vector3.one, timeAnim);
            }
        }
        else
        {
            for (int i = 0; i < _panelInicial.Count; i++)
            {
                _panelInicial[i].localScale = Vector3.zero;
            }
            //await Awaitable.WaitForSecondsAsync(2);
        }
        
        
        
    }

    public void PainelPauseOn()
    {
        using var _ = PanelPause();
    }

    async Task PanelPause()
    {
        for (int i = 0; i < _panelPause.Count; i++)
        {
            _panelPause[i].localScale = Vector3.zero;
        }

        for (int i = 0; i < _panelPause.Count; i++)
        {
            await Awaitable.WaitForSecondsAsync(timeAnim);
            _panelPause[i].DOScale(Vector3.one, timeAnim);
        }
    }
    public void PainelFinalOn()
    {
        using var _ = PanelFinal();
    }

    async Task PanelFinal()
    {
        for (int i = 0; i < _panelFinal.Count; i++)
        {
            _panelFinal[i].localScale = Vector3.zero;
        }

        for (int i = 0; i < _panelFinal.Count; i++)
        {
            await Awaitable.WaitForSecondsAsync(timeAnim);
            _panelFinal[i].DOScale(Vector3.one, timeAnim);
        }
    }
}
