using AutoMapper;
using BookShelf.Application.Authors.v1.Queries.GetAuthorById;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookShelf.Application.Common.Behaviors;
using MediatR;
using BookShelf.Application.Authors.v1.Commands.CreateAuthor;
using BookShelf.Application.Authors.v1.Commands.UpdateAuthor;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        // Register AutoMapper
        services.AddAutoMapper(typeof(GetAuthorByIdQueryProfile));

        services.AddTransient(provider => new MapperConfiguration(cfg =>
        {
            cfg.AllowNullDestinationValues = true;
            
            cfg.AddMaps(typeof(GetAuthorByIdQueryProfile));
        }).CreateMapper());

        // Register MediatR
        services.AddMediatR(typeof(GetAuthorByIdQuery));

        // Register MediatR pipeline behaviors
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        // Registering MediatR handlers
        services.AddScoped<IRequestHandler<GetAuthorByIdQuery, AuthorPreviewDto>, GetAuthorByIdQueryHandler>();
        services.AddScoped<IRequestHandler<CreateAuthorCommand, Unit>, CreateAuthorCommandHandler>();
        services.AddScoped<IRequestHandler<UpdateAuthorCommand, Unit>, UpdateAuthorCommandHandler>();

        // Register FluentValidation
        services
        .AddValidatorsFromAssemblyContaining<GetAuthorByIdQueryValidator>()
        .AddFluentValidationAutoValidation((configuration) =>
        {
            configuration.DisableDataAnnotationsValidation = true;
        });

        return services;
    }
}
