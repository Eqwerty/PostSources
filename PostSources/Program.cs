using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PostsRepository;
using Source1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPostsRepository, PostsRepository.PostsRepository>();
builder.Services.AddHostedService<HostedService1>();
builder.Services.AddHostedService<HostedService2>();

var app = builder.Build();

app.MapGet("/posts", (IPostsRepository postRepository) => postRepository.GetPosts());

app.MapGet("/posts/1", (IPostsRepository postRepository) => postRepository.GetPosts().Where(p => p < 2000));

app.MapGet("/posts/2", (IPostsRepository postRepository) => postRepository.GetPosts().Where(p => p >= 2000));

app.Run();