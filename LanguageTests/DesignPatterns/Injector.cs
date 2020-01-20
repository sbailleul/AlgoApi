using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoApi.LanguageTest.DesignPatterns
{
    public class Injector
    {
        private Dictionary<Type,object> providers = new Dictionary<Type, object>();

        public void Bind<TKey, TConcrete>() where TConcrete : TKey
        {
            providers[typeof(TKey)] = ResolveByType(typeof(TConcrete));
        }

        public void Bind<T>(T instance)
        {
            providers[typeof(T)] = instance;
        }

        private object ResolveByType(Type type)
        {
            var constructor = type.GetConstructors().Single();
            if (constructor != null)
            {
                var arguments = constructor.GetParameters().Select(p => Resolve(p.ParameterType)).ToArray();
                return constructor.Invoke(arguments);
            }

            return type.GetField("Instance").GetValue(null);
        }

        internal TKey Resolve<TKey>()
        {
            return (TKey) Resolve(typeof(TKey));
        }


        private object Resolve(Type type)
        {
            return providers.TryGetValue(type, out var provider) ? provider : ResolveByType(type);
        }
    }
}