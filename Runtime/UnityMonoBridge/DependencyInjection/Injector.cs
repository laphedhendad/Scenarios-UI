using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Laphed.ScenariosUI.DependencyInjection
{
    class Injector : IController
    {
        private static readonly Type BaseMonoBehaviourType = typeof(MonoBehaviour);

        private readonly Dictionary<Type, object> injections;

        internal Injector(Dictionary<Type, object> injections)
        {
            this.injections = injections;
        }

        internal void SelfBind()
        {
            injections.Add(typeof(IController), this);
        }
        
        void IController.Inject(MonoBehaviour root)
        {
            var monoComponents = new List<MonoBehaviour>();
            root.GetComponents(monoComponents);
            monoComponents.Add(root);

            foreach (MonoBehaviour component in monoComponents)
            {
                Type componentType = component.GetType();
                FieldInfo[] fieldInfos = CollectTargetFields(componentType);

                foreach (FieldInfo fieldInfo in fieldInfos)
                {
                    Type requiredInjectionType = fieldInfo.FieldType;

                    if (!injections.TryGetValue(requiredInjectionType, out object dependency))
                    {
                        throw new Exception("Injection not found")
                        {
                            Data =
                            {
                                { "ObjectType", componentType },
                                { "RequiredInjectionType", requiredInjectionType }
                            }
                        };
                    }
                    
                    fieldInfo.SetValue(component, dependency);
                }
            }
        }

        private FieldInfo[] CollectTargetFields(Type type)
        {
            const BindingFlags FieldBindingFlagsFilter = BindingFlags.Instance | BindingFlags.NonPublic;

            var fieldInfos = new List<FieldInfo>();

            for (Type t = type; t != BaseMonoBehaviourType; t = t.BaseType)
            {
                fieldInfos.AddRange(
                    t.GetFields(FieldBindingFlagsFilter)
                       .Where(fieldInfo => fieldInfo.GetCustomAttribute<InjectionAttribute>() != null)
                );
            }

            return fieldInfos.ToArray();
        }
    }
}
