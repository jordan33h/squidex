// ==========================================================================
//  CreateSchema.cs
//  PinkParrot Headless CMS
// ==========================================================================
//  Copyright (c) PinkParrot Group
//  All rights reserved.
// ==========================================================================

using PinkParrot.Core.Schemas;

namespace PinkParrot.Write.Schemas.Commands
{
    public class CreateSchema : AppCommand
    {
        public string Name { get; set; }

        public SchemaProperties Properties { get; set; }
    }
}