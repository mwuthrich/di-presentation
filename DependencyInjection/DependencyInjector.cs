using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjection
{
    public class DependencyInjector
    {
        private Dictionary<Type, Type> _registry = new Dictionary<Type, Type>();

        public void Register<T1, T2>() where T2 : class, T1
        {
            _registry[typeof(T1)] = typeof(T2);
        }

        public void Register(Type type)
        {
            _registry[type] = type;
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {
            if (!_registry.ContainsKey(type)) throw new Exception($"Type {type.FullName} not registered");

            var returnType = _registry[type];
            var constructor = returnType.GetConstructors().FirstOrDefault();

            if (constructor == null) throw new Exception($"type {returnType.FullName} does not have a public constructor");

            var parameters = constructor.GetParameters();

            var resolvedParameters = parameters
                .Select(p => Resolve(p.ParameterType))
                .ToArray();

            return constructor.Invoke(resolvedParameters);
        }
    }
}
