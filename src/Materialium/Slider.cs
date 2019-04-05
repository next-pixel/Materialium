﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public class Slider : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            var n = OpenElementWithCommonAttributes(builder, "div");
            builder.AddAttribute(n++, "role", "slider");

            if (Disabled)
            {
                builder.AddAttribute(n++, "aria-disabled", "true");
            }

            builder.AddAttribute(n++, "aria-valuemin", Minimum.ToString());
            builder.AddAttribute(n++, "aria-valuemax", Maximum.ToString());
            builder.AddAttribute(n++, "aria-valuenow", Value.ToString());
            if (Step != null)
            {
                builder.AddAttribute(n++, "data-step", Step.Value.ToString());
            }

            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter] bool Discrete { get; set; }
        [Parameter] bool DisplayMarkers { get; set; }

        [Parameter] bool Disabled { get; set; }

        [Parameter] float Minimum { get; set; }
        [Parameter] float Maximum { get; set; }
        [Parameter] float Value { get; set; }
        [Parameter] float? Step { get; set; }

        protected override IEnumerable<string> GetClasses()
        {
            yield return Classes.Slider;

            if (Discrete)
            {
                yield return Classes.Discrete;

                if (DisplayMarkers)
                {
                    yield return Classes.DisplayMarkers;
                }
            }
        }

        bool isFirstRender = true;
        protected override async Task OnAfterRenderAsync()
        {
            if (isFirstRender && ComponentContext.IsConnected)
            {
                await JSRuntime.InvokeAsync<object>("Materialium.slider.init", element);
                isFirstRender = false;
            }
        }

        public static class Classes
        {
            public const string Slider = "mdc-slider";
            public const string Discrete = "mdc-slider--discrete";
            public const string DisplayMarkers = "mdc-slider--display-markers";
            public const string TrackContainer = "mdc-slider__track-container";
            public const string Track = "mdc-slider__track";
            public const string ThumbContainer = "mdc-slider__thumb-container";
            public const string Thumb = "mdc-slider__thumb";
            public const string Pin = "mdc-slider__pin";
            public const string PinValueMarker = "mdc-slider__pin-value-marker";
            public const string FocusRing = "mdc-slider__focus-ring";
        }
    }
}