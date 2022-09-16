using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace CoiNYC.Core.Helpers
{
    public static class ObjectFactory
    {
        public static Func<T> CreateObjectFactory<T>(Func<T> factory = null)
        {
            Type type = typeof(T);
            object createDelegate;

            if (factory != null)
            {
                createDelegate = factory;
            }
            else
            {
                var dynMethod = new DynamicMethod("DM$OBJ_FACTORY_" + type.Name, type, null, type);
                ILGenerator ilGen = dynMethod.GetILGenerator();

                ilGen.Emit(OpCodes.Newobj, type.GetConstructor(Type.EmptyTypes));
                ilGen.Emit(OpCodes.Ret);
                createDelegate = dynMethod.CreateDelegate(typeof(Func<T>));
            }
            return (Func<T>)createDelegate;
        }

        public static Func<object> CreateObjectFactory(Type type)
        {
            object createDelegate;

            var dynMethod = new DynamicMethod("DM$OBJ_FACTORY_" + type.Name, type, null, type);
            ILGenerator ilGen = dynMethod.GetILGenerator();

            ilGen.Emit(OpCodes.Newobj, type.GetConstructor(Type.EmptyTypes));
            ilGen.Emit(OpCodes.Ret);
            createDelegate = dynMethod.CreateDelegate(typeof(Func<object>));

            return (Func<object>)createDelegate;
        }
    }
}
