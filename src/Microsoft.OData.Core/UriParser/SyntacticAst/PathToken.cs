﻿//---------------------------------------------------------------------
// <copyright file="PathToken.cs" company="Microsoft">
//      Copyright (C) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
// </copyright>
//---------------------------------------------------------------------

#if ASTORIA_CLIENT
namespace Microsoft.OData.Client.ALinq.UriParser
#else
namespace Microsoft.OData.Core.UriParser.Syntactic
#endif
{
    #region Namespaces
    using System;
    using Microsoft.OData.Core.UriParser.Semantic;
    #endregion Namespaces

    /// <summary>
    /// Lexical token representing a segment in a path.
    /// </summary>
    /// 
    internal abstract class PathToken : QueryToken
    {
        /// <summary>
        /// The NextToken in the path(can either be the parent or the child depending on whether the tree has
        /// been normalized for expand or not.
        /// TODO: need to revisit this and the rest of the syntactic parser to make it ready for public consumption.
        /// </summary>
        public abstract QueryToken NextToken { get; set; }

        /// <summary>
        /// The name of the property to access.
        /// </summary>
        public abstract string Identifier { get; }
    }
}