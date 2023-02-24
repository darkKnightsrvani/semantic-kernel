﻿// Copyright (c) Microsoft. All rights reserved.

using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel.AI;
using Microsoft.SemanticKernel.Reliability;
using Moq;
using Xunit;

namespace SemanticKernelTests.Reliability;

public class PassThroughWithoutRetryTests
{
    [Fact]
    public async Task ItDoesNotRetryOnExceptionAsync()
    {
        // Arrange
        var retry = new PassThroughWithoutRetry();
        var action = new Mock<Func<Task>>();
        action.Setup(a => a()).Throws(new AIException(AIException.ErrorCodes.Throttling, "Throttling Test"));

        // Act
        await Assert.ThrowsAsync<AIException>(() => retry.ExecuteWithRetryAsync(action.Object, Mock.Of<ILogger>()));

        // Assert
        action.Verify(a => a(), Times.Once);
    }

    [Fact]
    public async Task NoExceptionNoRetryAsync()
    {
        // Arrange
        var log = new Mock<ILogger>();
        var retry = new PassThroughWithoutRetry();
        var action = new Mock<Func<Task>>();

        // Act
        await retry.ExecuteWithRetryAsync(action.Object, log.Object);

        // Assert
        action.Verify(a => a(), Times.Once);
    }
}
