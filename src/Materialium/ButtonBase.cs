﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    public abstract class ButtonBase : MaterialComponentBase
    {
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            var n = OpenElementWithCommonAttributes(builder, string.IsNullOrWhiteSpace(Href) ? "button" : "a");

            if (!string.IsNullOrWhiteSpace(Href))
            {
                builder.AddAttribute(n++, "href", Href);

                if (!string.IsNullOrWhiteSpace(Title))
                {
                    builder.AddAttribute(n++, "title", Title);
                }

                if (!string.IsNullOrWhiteSpace(Target))
                {
                    builder.AddAttribute(n++, "target", Target);
                }
            }
            else
            {
                if (Disabled)
                {
                    builder.AddAttribute(n++, "disabled", "true");
                }
            }

            BuildAttributes(builder, ref n);

            builder.AddContent(n++, ChildContent);
            builder.CloseElement();
        }

        [Parameter]
        public bool Outlined { get; set; }

        [Parameter]
        public bool Unelevated { get; set; }

        [Parameter]
        public bool Raised { get; set; }

        [Parameter]
        public bool Dense { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Target { get; set; }

        [Parameter]
        public string Href { get; set; }

        internal virtual void BuildAttributes(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder builder, ref int n)
        {

        }

        protected override IEnumerable<string> GetClasses()
        {
            if (Outlined)
            {
                yield return Classes.Outlined;
            }

            if (Raised)
            {
                yield return Classes.Raised;
            }

            if (Unelevated)
            {
                yield return Classes.Unelevated;
            }

            if (Dense)
            {
                yield return Classes.Dense;
            }
        }

        public static class Classes
        {
            public const string Button = "mdc-button";
            public const string Outlined = "mdc-button--outlined";
            public const string Raised = "mdc-button--raised";
            public const string Unelevated = "mdc-button--unelevated";
            public const string Dense = "mdc-button--dense";

            public const string ButtonLabel = "mdc-button__label";
            public const string ButtonIcon = "mdc-button__icon";

            public const string IconButton = "mdc-icon-button";
            public const string IconButtonIcon = "mdc-icon-button__icon";
        }
    }
}