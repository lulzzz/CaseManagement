﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using CaseManagement.HumanTask.AspNetCore;
using CaseManagement.HumanTask.Builders;
using CaseManagement.HumanTask.Domains;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace CaseManagement.HumanTask.Host
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _configuration;

        public Startup(IHostingEnvironment env, IConfiguration configuration) 
        {
            _env = env;
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var dressAppropriateForm = HumanTaskDefBuilder.New("dressAppropriateForm")
                .SetTaskInitiatorUserIdentifiers(new List<string> { "businessanalyst" })
                .SetPotentialOwnerUserIdentifiers(new List<string> { "businessanalyst" })
                .AddPresentationParameter("degree", ParameterTypes.STRING, "context.GetInput(\"degree\")")
                .AddPresentationParameter("city", ParameterTypes.STRING, "context.GetInput(\"city\")")
                .AddName("fr", "Température à $city$")
                .AddName("en", "Temperature in $city$")
                .AddSubject("fr", "Il fait $degree$", "text/html")
                .AddSubject("en", "Degree : $degree$", "text/html")
                .AddInputOperationParameter("degree", ParameterTypes.STRING, true)
                .AddInputOperationParameter("city", ParameterTypes.STRING, true)
                .Build();
            var captureClaimDetails = HumanTaskDefBuilder.New("captureClaimDetails")
                .SetTaskInitiatorUserIdentifiers(new List<string> { "businessanalyst" })
                .SetPotentialOwnerUserIdentifiers(new List<string> { "businessanalyst" })
                .AddName("fr", "Capturer les détails de la réclamation")
                .AddName("en", "Capture claim details")
                .AddTxt("firstName", cb =>
                {
                    cb.AddLabel("fr", "Prénom");
                    cb.AddLabel("en", "Firstname");
                })
                .AddTxt("lastName", cb =>
                {
                    cb.AddLabel("fr", "Nom");
                    cb.AddLabel("en", "Lastname");
                })
                .AddTxt("claim", cb =>
                {
                    cb.AddLabel("fr", "Motif de la réclamation");
                    cb.AddLabel("en", "Claim");
                })
                .AddOutputOperationParameter("firstName", ParameterTypes.STRING, true)
                .AddOutputOperationParameter("lastName", ParameterTypes.STRING, true)
                .AddOutputOperationParameter("claim", ParameterTypes.STRING, true)
                .Build();
            var takeTemperatureForm = HumanTaskDefBuilder.New("temperatureForm")
                .SetTaskInitiatorUserIdentifiers(new List<string> { "businessanalyst" })
                .SetPotentialOwnerUserIdentifiers(new List<string> { "businessanalyst" })
                .AddName("fr", "Saisir la température")
                .AddName("en", "Enter degree")
                .AddTxt("degree", cb => cb.AddLabel("fr", "Température"))
                .AddOutputOperationParameter("degree", ParameterTypes.INT, true)
                .Build();
            services.AddMvc(opts => opts.EnableEndpointRouting = false).AddNewtonsoftJson();
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = ExtractKey("openid_puk.txt"),
                    ValidAudiences = new List<string>
                    {
                        "http://localhost:60000",
                        "http://simpleidserver.northeurope.cloudapp.azure.com/openid"
                    },
                    ValidIssuers = new List<string>
                    {
                        "http://localhost:60000",
                        "http://simpleidserver.northeurope.cloudapp.azure.com/openid"
                    }
                };
            })
            .AddJwtBearer("OAuthScheme", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = ExtractKey("oauth_puk.txt"),
                    ValidAudiences = new List<string>
                    {
                        "bpmnClient",
                        "cmmnClient"
                    },
                    ValidIssuers = new List<string>
                    {
                        "http://localhost:60001",
                        "http://simpleidserver.northeurope.cloudapp.azure.com/oauth"
                    }
                };
            });
            services.AddAuthorization(_ => _.AddDefaultHumanTaskAuthorizationPolicy());
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));
            services.AddHostedService<HumanTaskJobServerHostedService>();
            services.AddHumanTasksApi();
            services.AddHumanTaskServer()
                .AddHumanTaskDefs(new List<HumanTaskDefinitionAggregate>
                {
                    captureClaimDetails,
                    dressAppropriateForm,
                    takeTemperatureForm
                });
            services.AddSwaggerGen();
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var pathBase = string.Empty;
            if (_configuration.GetChildren().Any(i => i.Key == "pathBase"))
            {
                pathBase = _configuration["pathBase"];
                app.UsePathBase(pathBase);
            }

            app.UseCulture();
            app.UseForwardedHeaders();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {				
                var edp = "/swagger/v1/swagger.json";
                if (!string.IsNullOrWhiteSpace(pathBase))
                {
                    edp = $"{pathBase}{edp}";
                }
				
                c.SwaggerEndpoint(edp, "WS-HumanTask API V1");
            });
            app.UseAuthentication();
            app.UseCors("AllowAll");
            app.UseMvc();
        }

        private RsaSecurityKey ExtractKey(string fileName)
        {
            var json = File.ReadAllText(Path.Combine(_env.ContentRootPath, fileName));
            var dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            var rsa = RSA.Create();
            var rsaParameters = new RSAParameters
            {
                Modulus = Convert.FromBase64String(dic["n"].ToString()),
                Exponent = Convert.FromBase64String(dic["e"].ToString())
            };
            rsa.ImportParameters(rsaParameters);
            return new RsaSecurityKey(rsa);
        }
    }
}