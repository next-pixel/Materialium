﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class FloatingActionButton : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "button");
            builder.AddAttribute(n++, "aria-label", "Favorite");
            CaptureElementReference(builder, ref n);
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter] bool Mini { get; set; }
        [Parameter] bool Extended { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-fab";

            if (Extended)
            {
                yield return "mdc-fab--extended";
            }

            if (Mini)
            {
                yield return "mdc-fab--mini";
            }
        }

        bool isFirstRender = true;
        protected override async Task OnAfterRenderAsync()
        {
            if (isFirstRender && ComponentContext.IsConnected)
            {
                await JSRuntime.InvokeAsync<object>("Materialium.ripple.init", element);
                isFirstRender = false;
            }
        }
    }
}