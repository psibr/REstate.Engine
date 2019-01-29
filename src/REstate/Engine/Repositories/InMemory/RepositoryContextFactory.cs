﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace REstate.Engine.Repositories.InMemory
{
    public class InMemoryRepositoryContextFactory<TState, TInput>
        : IRepositoryContextFactory<TState, TInput>
    {
        private Lazy<IEngineRepositoryContext<TState, TInput>> repositoryContextLazy 
            = new Lazy<IEngineRepositoryContext<TState, TInput>>(() 
                => new EngineRepositoryContext<TState, TInput>(), true);

        public IMachineStatusStore<TState, TInput> GetMachineStatusStore(string machineId)
        {
            return new InMemoryMachineStatusStore<TState, TInput>(this, machineId);
        }

        public Task<IEngineRepositoryContext<TState, TInput>> OpenContextAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(repositoryContextLazy.Value);
        }
    }
}
