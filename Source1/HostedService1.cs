﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using PostsRepository;

namespace Source1;

public class HostedService1 : IHostedService
{
    private readonly IPostsRepository _postsRepository;
    private int _index = 1000;

    public HostedService1(IPostsRepository postsRepository)
    {
        _postsRepository = postsRepository;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        Task.Run(() => SomeInfinityProcess(cancellationToken), cancellationToken);
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private void SomeInfinityProcess(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            Thread.Sleep(1000);
            _postsRepository.Add(_index++);
        }
    }
}