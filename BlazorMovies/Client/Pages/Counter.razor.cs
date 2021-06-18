using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BlazorMovies.Client.Shared.MainLayout;

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
        [CascadingParameter]
        public AppState AppState { get; set; }
        private int currentCount = 0;
        private static int currentCountStatic = 0;
        private IJSObjectReference module;

        [JSInvokable]
        public async Task IncrementCount()
        {
            module = await js.InvokeAsync<IJSObjectReference>("import", "./js/Counter.js");
            await module.InvokeVoidAsync("displayAlert", "Hello world");
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
