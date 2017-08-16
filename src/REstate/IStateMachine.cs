﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using REstate.Schematics;

namespace REstate
{
    public interface IStateMachine<TState, TInput>
    {
        Task<ISchematic<TState, TInput>> GetSchematicAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        string MachineId { get; }

        Task<IReadOnlyDictionary<string, string>> GetMetadataAsync(
            CancellationToken cancellationToken = default(CancellationToken));

        Task<Status<TState>> SendAsync<TPayload>(
            TInput input,
            TPayload payload, 
            CancellationToken cancellationToken = default(CancellationToken));

        Task<Status<TState>> SendAsync<TPayload>(
            TInput input,
            TPayload payload, 
            Guid lastCommitTag,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<Status<TState>> SendAsync(
            TInput input,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<Status<TState>> SendAsync(
            TInput input,
            Guid lastCommitTag,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
