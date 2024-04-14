using System;
using System.Collections.Generic;

namespace Laphed.ScenariosUI.DependencyInjection
{
    public class Builder
    {
        private readonly Dictionary<Type, object> injections;

        public Builder()
        {
            injections = new Dictionary<Type, object>();
        }

        public Builder Bind<T>(T injection)
        {
            injections.Add(typeof(T), injection);
            return this;
        }

        public IController Build()
        {
            var injector = new Injector(injections);
            injector.SelfBind();
            return new Injector(injections);
        }
    }
}
