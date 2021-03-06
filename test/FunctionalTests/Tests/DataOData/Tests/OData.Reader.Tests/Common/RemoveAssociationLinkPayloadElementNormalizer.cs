﻿//---------------------------------------------------------------------
// <copyright file="RemoveAssociationLinkPayloadElementNormalizer.cs" company="Microsoft">
//      Copyright (C) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.
// </copyright>
//---------------------------------------------------------------------

namespace Microsoft.Test.Taupo.OData.Reader.Tests.Common
{
    #region Namespaces
    using System.Linq;
    using Microsoft.Test.Taupo.Astoria.Common;
    using Microsoft.Test.Taupo.Astoria.Contracts.OData;
    #endregion Namespaces

    /// <summary>
    /// Removes association links from the payload.
    /// </summary>
    /// <remarks>
    /// In certain cases (requests, MPV less then V3) association links are ignored, and thus we need to normalize the payload before comparison
    /// by removing them.
    /// </remarks>
    public class RemoveAssociationLinkPayloadElementNormalizer : ODataPayloadElementVisitorBase
    {
        /// <summary>
        /// Normalizes the payload by removing association links.
        /// </summary>
        /// <param name="payloadElement">The payload element to normalize.</param>
        /// <returns>The normalized payload element.</returns>
        public static ODataPayloadElement Normalize(ODataPayloadElement payloadElement)
        {
            new RemoveAssociationLinkPayloadElementNormalizer().Recurse(payloadElement);
            return payloadElement;
        }

        /// <summary>
        /// Visits the entity instance.
        /// </summary>
        /// <param name="payloadElement">The payload element being visited.</param>
        public override void Visit(EntityInstance payloadElement)
        {
            base.Visit(payloadElement);

            foreach (var navPropWithAssociationLink in payloadElement.Properties.OfType<NavigationPropertyInstance>().Where(p => p.AssociationLink != null).ToArray())
            {
                if (navPropWithAssociationLink.Value == null)
                {
                    payloadElement.Remove(navPropWithAssociationLink);
                }
                else
                {
                    navPropWithAssociationLink.AssociationLink = null;
                }
            }
        }
    }
}