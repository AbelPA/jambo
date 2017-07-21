﻿using Autofac;
using Jambo.Application.Queries;
using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Infrastructure.Repositories;

namespace Jambo.API.IoC
{
    public class ApplicationModule : Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new BlogQueries(QueriesConnectionString))
                .As<IBlogQueries>();

            builder.RegisterType<BlogWriteOnlyRepository>()
                .As<IBlogWriteOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BlogReadOnlyRepository>()
                .As<IBlogReadOnlyRepository>()
                .InstancePerLifetimeScope();
        }
    }
}