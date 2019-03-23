﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Materialium
{
    [Accepts(typeof(ButtonIcon), typeof(ButtonLabel))]
    public class Button : ButtonBase
    {
        protected override IEnumerable<string> GetClasses()
        {
            yield return Classes.Button;

            var b = base.GetClasses();

            foreach (var c in b)
            {
                yield return c;
            }
        }
    }
}