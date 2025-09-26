using Stride.Core;
using Stride.Core.Mathematics;
using Stride.Graphics;
using Stride.Rendering;
using Stride.Rendering.Compositing;

[DataContract(nameof(CircularProgressBarRenderer))]
[Display("Circular bar renderer")]
public sealed class CircularProgressBarRenderer : SceneRendererBase
{
    public Texture RenderTarget;

    bool _firstDraw = true;

    public Color CompleteBarColor;
    public Color IncompleteBarColor;
    public Color BackgroundColor;
    public float Progress;
    public float BarThickness;

    public CircularProgressBarRenderer()
    {
    }

    EffectInstance _shader;
    SpriteBatch _spriteBatch;

    protected override void DrawCore(RenderContext context, RenderDrawContext drawContext)
    {
        var graphicsDevice = drawContext.GraphicsDevice;
        var commandList = drawContext.CommandList;

        if(_firstDraw)
        {
            _shader = new EffectInstance(EffectSystem.LoadEffect("RadialProgressBar").WaitForResult());
            _spriteBatch = new SpriteBatch(graphicsDevice);

            _firstDraw = false;
        }

        commandList.SetRenderTargetAndViewport(null, RenderTarget);

        _spriteBatch.Begin(drawContext.GraphicsContext, SpriteSortMode.Immediate, _shader);

        _spriteBatch.Parameters.Set(RadialProgressBar.CompleteBarColor, CompleteBarColor);
        _spriteBatch.Parameters.Set(RadialProgressBar.IncompleteBarColor, IncompleteBarColor);
        _spriteBatch.Parameters.Set(RadialProgressBar.BackgroundColor, BackgroundColor);
        _spriteBatch.Parameters.Set(RadialProgressBar.Progress, Progress);
        _spriteBatch.Parameters.Set(RadialProgressBar.BarThickness, BarThickness);

        _spriteBatch.Draw(RenderTarget, new RectangleF(0, 0, (float)RenderTarget.Width, (float)RenderTarget.Height), Color.White);
        _spriteBatch.End();
    }
}