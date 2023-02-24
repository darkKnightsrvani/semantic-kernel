﻿// Copyright (c) Microsoft. All rights reserved.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.SemanticKernel.Connectors.Interfaces;

/// <summary>
/// Interface for organization hierarchy connections (e.g. Azure AD).
/// </summary>
public interface IOrganizationHierarchyConnector
{
    /// <summary>
    /// Get the user's direct reports' email addresses.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The user's direct reports' email addresses.</returns>
    Task<IEnumerable<string>> GetDirectReportsEmailAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the user's manager's email address.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The user's manager's email address.</returns>
    Task<string> GetManagerEmailAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the user's manager's name.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The user's manager's name.</returns>
    Task<string> GetManagerNameAsync(CancellationToken cancellationToken = default);
}
