using Autofac;
using Hospital.Common.Utilities;
using System;

namespace Hospital.Common
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<DateTimeUtility>().As<IDateTimeUtility>()
                .InstancePerLifetimeScope();


            base.Load(builder);
        }
    }
}
