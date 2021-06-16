using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMovies.Client.Pages
{
    public partial class Counter
    {
        [Inject] 
        SingletonService singleton { get; set; }
        [Inject]
        TransientService transient { get; set; }
        [Inject]
        IJSRuntime js { get; set; }
        private int currentCount = 0;
        private static int currentCountStatic = 0;

        [JSInvokable]
        public async Task IncrementCount()
        {
            currentCount++;
            singleton.Value += 1;
            transient.Value += 1;
            currentCountStatic++;
            await js.InvokeVoidAsync("dotNetStaticInvokation");
        }

        [JSInvokable]
        public static Task<int> GetCurrentCount()
        {
            return Task.FromResult(currentCountStatic);
        }

        private async Task IncrementCountJavascript()
        {
            await js.InvokeVoidAsync("dotNetInstanceInvokation", DotNetObjectReference.Create(this));
        }
    }
}
