namespace SoftUniDI.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Attributes;
    using Contracts;

    public abstract class AbstractModule : IModule
    {
        private readonly IDictionary<Type, Dictionary<string, Type>> implementations;

        private readonly IDictionary<Type, object> instances;

        public AbstractModule()
        {
            this.implementations = new Dictionary<Type, Dictionary<string, Type>>();
            this.instances = new Dictionary<Type, object>();
        }

        public abstract void Configure();

        protected void CreateMapping<TInter, TImpl>()
        {
            Type interfaceType = typeof(TInter);
            Type implementatinType = typeof(TImpl);

            if (!implementations.ContainsKey(interfaceType))
            {
                implementations.Add(interfaceType , new Dictionary<string, Type>());
            }
            implementations[interfaceType].Add(implementatinType.Name, implementatinType);
        }

        public object GetInstance(Type type)
        {
            instances.TryGetValue(type, out object value);

            return value;
        }

        public Type GetMapping(Type currentInterface, object attribute)
        {
            Type result = null;

            var currImpl = implementations[currentInterface];

            if (attribute is InjectAttribute)
            {
                if (currImpl.Count == 1)
                {
                    result = currImpl.Values.First();
                }
                else
                {
                    throw new ArgumentException($"No implementaton found for type {currentInterface.Name}");
                }
            }
            else if(attribute is NamedAttribute named)
            {
                result = currImpl[named.Name];
            }

            return result;
        }

        public void SetInstance(Type implementation, object instance)
        {
            if (!instances.ContainsKey(implementation))
            {
                instances.Add(implementation, instance);
            }
        }
    }
}
