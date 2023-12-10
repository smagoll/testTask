using Unity.VectorGraphics;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SettingsController : WindowManager
{
    [SerializeField]
    private GameObject volume;
    [SerializeField]
    private GameObject sfx;
    [SerializeField]
    private Image fade;
    [SerializeField]
    private SVGImage volumeImage;
    [SerializeField]
    private SVGImage sfxImage;
    [SerializeField]
    private AudioManager audioManager;

    private bool isVolume = true;
    private bool isSfx = true;

    public bool IsVolume
    {
        get { return isVolume; }
        set
        {
            isVolume = value;
            audioManager.musicSource.enabled = isVolume;
            var color = volumeImage.color;
            if (isVolume)
            {
                color.a = 1f;
            }
            else
            {
                color.a = 0.6f;
            }
            volumeImage.DOColor(color, 0.3f);
        }
    }
    
    public bool IsSfx
    {
        get { return isSfx; }
        set
        {
            isSfx = value;
            audioManager.sfxSource.enabled = isSfx;
            var color = sfxImage.color;
            if (isSfx)
            {
                color.a = 1f;
            }
            else
            {
                color.a = 0.5f;
            }
            sfxImage.DOColor(color, 0.3f);
        }
    }

    public void ChangeVolume()
    {
        IsVolume = !IsVolume;
    }

    public void ChangeSFX()
    {
        IsSfx = !IsSfx;
    }

    public override void Disable()
    {
        var sequence = DOTween.Sequence();
        fade.raycastTarget = false;

        sequence.Append(transform.DOScale(new Vector3(0f, 0f, 0f), 0.3f));
        sequence.AppendCallback(() =>
        {
            gameObject.SetActive(false);
            fade.gameObject.SetActive(false);
            sequence.Kill();
        });
    }

    public override void Enable()
    {
        transform.localScale = new Vector3(0, 0, 0);
        var sequence = DOTween.Sequence();
        gameObject.SetActive(true);
        fade.gameObject.SetActive(true);
        fade.raycastTarget = true;

        sequence.Append(transform.DOScale(new Vector3(1, 1, 1), 0.3f));
        sequence.AppendCallback(() =>
        {
            sequence.Kill();
        });
    }
}
