﻿// ==========================================================================
//  FieldShown.cs
//  PinkParrot Headless CMS
// ==========================================================================
//  Copyright (c) PinkParrot Group
//  All rights reserved.
// ==========================================================================

using PinkParrot.Infrastructure;

namespace PinkParrot.Events.Schemas
{
    [TypeName("FieldShownEvent")]
    public class FieldShown : AppEvent
    {
        public long FieldId { get; set; }
    }
}
