﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Materialium
{
    public class MaterialSelect : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            CaptureElementReference(builder, ref n);
            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        public bool Outlined { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool WithLeadingIcon { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return "mdc-select";

            if (Outlined)
            {
                yield return Classes.Outlined;
            }

            if (Disabled)
            {
                yield return Classes.Disabled;
            }

            if (WithLeadingIcon)
            {
                yield return Classes.WithLeadingIcon;
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeAsync<object>("Materialium.select.init", element);
            }
        }

        public static class Classes
        {
            public const string WithLeadingIcon = "mdc-select--with-leading-icon";
            public const string Disabled = "mdc-select--disabled";
            public const string Outlined = "mdc-select--outlined";
            public const string NativeControl = "mdc-select__native-control";
            public const string SelectedText = "mdc-select__selected-text";
            public const string DropdownIcon = "mdc-select__dropdown-icon";
            public const string Menu = "mdc-select__menu";
        }
    }
}