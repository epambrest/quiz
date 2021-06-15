﻿using Lab.Quiz.BL.Services.OpenAnswerQuestionService;
using Lab.Quiz.BL.Services.OpenAnswerQuestionService.Mapping;
using Lab.Quiz.BL.Services.TestCardService;
using Lab.Quiz.BL.Services.TestCardService.Mapping;
using Lab.Quiz.Common.Mapping;
using Lab.Quiz.DAL.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab.Quiz.BL.DependencyInjection
{
    public static class BootstrapExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataLayer(configuration);
            services.AddScoped<ITestCardService, TestCardService>();
            services.AddScoped<IOpenAnswerQuestionService, OpenAnswerQuestionService>();
            services.AddScoped<IManualMapperProfile, TestCardMapperProfile>();
            services.AddScoped<IManualMapperProfile, TestCardCollectionMapperProfile>();
            services.AddScoped<IManualMapperProfile, OpenAnswerMapperProfile>();
            return services;
        }
    }
}
