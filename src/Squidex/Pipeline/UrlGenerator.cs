﻿// ==========================================================================
//  Squidex Headless CMS
// ==========================================================================
//  Copyright (c) Squidex UG (haftungsbeschränkt)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using System;
using Microsoft.Extensions.Options;
using Squidex.Config;
using Squidex.Domain.Apps.Core.HandleRules;
using Squidex.Domain.Apps.Entities.Apps;
using Squidex.Domain.Apps.Entities.Assets;
using Squidex.Domain.Apps.Entities.Contents;
using Squidex.Domain.Apps.Entities.Contents.GraphQL;
using Squidex.Domain.Apps.Entities.Schemas;
using Squidex.Infrastructure;
using Squidex.Infrastructure.Assets;

namespace Squidex.Pipeline
{
    public sealed class UrlGenerator : IGraphQLUrlGenerator, IRuleUrlGenerator
    {
        private readonly IAssetStore assetStore;
        private readonly MyUrlsOptions urlsOptions;

        public bool CanGenerateAssetSourceUrl { get; }

        public UrlGenerator(IOptions<MyUrlsOptions> urlsOptions, IAssetStore assetStore, bool allowAssetSourceUrl)
        {
            this.assetStore = assetStore;
            this.urlsOptions = urlsOptions.Value;

            CanGenerateAssetSourceUrl = allowAssetSourceUrl;
        }

        public string GenerateAssetThumbnailUrl(IAppEntity app, IAssetEntity asset)
        {
            if (!asset.IsImage)
            {
                return null;
            }

            return urlsOptions.BuildUrl($"api/assets/{asset.Id}?version={asset.Version}&width=100&mode=Max");
        }

        public string GenerateAssetUrl(IAppEntity app, IAssetEntity asset)
        {
            return urlsOptions.BuildUrl($"api/assets/{asset.Id}?version={asset.Version}");
        }

        public string GenerateContentUrl(IAppEntity app, ISchemaEntity schema, IContentEntity content)
        {
            return urlsOptions.BuildUrl($"api/content/{app.Name}/{schema.Name}/{content.Id}");
        }

        public string GenerateContentUIUrl(NamedId<Guid> appId, NamedId<Guid> schemaId, Guid contentId)
        {
            return urlsOptions.BuildUrl($"app/{appId.Name}/content/{schemaId.Name}/{contentId}/history");
        }

        public string GenerateAssetSourceUrl(IAppEntity app, IAssetEntity asset)
        {
            return assetStore.GenerateSourceUrl(asset.Id.ToString(), asset.FileVersion, null);
        }
    }
}
