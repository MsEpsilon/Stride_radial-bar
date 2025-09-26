using Stride.Engine;
using Stride.Rendering.Compositing;
using Stride.UI;
using Stride.UI.Controls;
namespace MyGame
{
    public class RadialSlider : SyncScript
    {
        UIPage _page;
        Slider _slider;

        public override void Start()
        {
            base.Start();

            _page = Entity.Get<UIComponent>().Page;
            _slider = _page.RootElement.FindVisualChildOfType<Slider>("progr");
        }

        public override void Update()
        {
            var camera_renderer = (SceneCameraRenderer)SceneSystem.GraphicsCompositor.Game;
            var scene_renderer = (SceneRendererCollection)camera_renderer.Child;
            ((CircularProgressBarRenderer)(scene_renderer.Children[2])).Progress = _slider.Value;
        }
    }
}
