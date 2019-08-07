using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Blazor.Offline
{
    public class Canvas2DContext
    {
        private readonly IJSRuntime jSRuntime;
        private readonly ElementRef canvasRef;

        public Canvas2DContext(IJSRuntime jSRuntime, ElementRef canvasRef)
        {
            this.jSRuntime = jSRuntime;
            this.canvasRef = canvasRef;
        }

        public async Task DrawLine(double startX, double startY, double endX, double endY)
        {
            await jSRuntime.InvokeAsync<object>("__blazorCanvasInterop.drawLine", canvasRef, startX, startY, endX, endY);
        }

        public async Task SetStrokeStyleAsync(string strokeStyle)
        {
            await jSRuntime.InvokeAsync<object>("__blazorCanvasInterop.setContextPropertyValue", canvasRef, "strokeStyle", strokeStyle);
        }
    }
}